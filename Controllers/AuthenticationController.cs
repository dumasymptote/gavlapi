using Microsoft.AspNetCore.Mvc;
using gavl_api.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using Microsoft.Extensions.Options;
using gavl_api.Services;

namespace gavl_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JwtSettings _jwtSettings;
        public AuthenticationController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IOptionsSnapshot<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtSettings = jwtSettings.Value;
        }
        
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(LoginViewModel model)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == model.Username);
            if(user is null)
            {
                return BadRequest("username or password incorrect");
            }
            var userSigninResult = await _userManager.CheckPasswordAsync(user, model.Password);
            if(userSigninResult){
                var roles = await _userManager.GetRolesAsync(user);
                var tokenGenerator = new JwtService(_jwtSettings);
                return Ok(tokenGenerator.GenerateJwt(user, roles));
            }
            
            return BadRequest("username or password incorrect");
        }
        
        //TODO: THIS ENDPOINT NEEDS TO BE UPDATED TO ONLY ALLOW LOGGED IN USERS IN SPECIFIC ROLES TO CREATE A USER
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(UserViewModel model)
        {
            var result = await _userManager.CreateAsync(new AppUser{ UserName = model.Username, PhoneNumber = model.PhoneNumber, Email = model.Email}, model.Password);
            if(result.Succeeded){
                return Created(string.Empty, string.Empty);
            }
            return Problem(result.Errors.First().Description, null, 500);
        }
    }
}