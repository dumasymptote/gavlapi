using System;
using AutoMapper;
using gavl_api.Data;
using gavl_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using gavl_api.Models;
using gavl_api.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gavl_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ApiResponseBuilder _response;
        private readonly UserManager<AppUser> _manager;
        //[Roles("Admin, BusinessAdmin")]
        public UsersController (AppDbContext context, IMapper mapper, IHttpContextAccessor httpContext, UserManager<AppUser> manager)
        {
            _context = context;
            _mapper = mapper;
            _response = new ApiResponseBuilder(httpContext.HttpContext.Request);
            _manager = manager;
        }
        [HttpPost]
        public async Task<ApiResponse> AddUser(AppUser model)
        {
            try
            {
                var result = await _manager.CreateAsync(model, "Testpass1@1");
                if(result.Succeeded)
                {
                    var user = await _manager.FindByEmailAsync(model.Email);
                    var userResource = _mapper.Map<AppUser, UserResource>(user);
                    _response.AddData(new List<UserResource> { userResource});
                }
                else
                {
                    var errorMsg ="";
                    foreach(var e in result.Errors)
                    {
                        errorMsg += $"{e.Description} ";
                    }
                    _response.AddError(new ApiError{
                        code = "400",
                        message = $"Could not create user - {errorMsg}",
                        url = "/users/"
                    });
                }
            }
            catch(Exception ex)
            {
                _response.AddError(new ApiError{
                        code = "500",
                        message = $"Error creating user: {ex.Message}",
                        url = "/users/"
                    });
            }
            return _response.GenerateReponse();
        }
    }
}