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
using Microsoft.AspNetCore.Authorization;

namespace gavl_api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ApiResponseBuilder _response;
        private readonly RoleManager<IdentityRole> _manager;
        //[Roles("Admin, BusinessAdmin")]
        public RolesController (AppDbContext context, IMapper mapper, IHttpContextAccessor httpContext, RoleManager<IdentityRole> manager)
        {
            _context = context;
            _mapper = mapper;
            _response = new ApiResponseBuilder(httpContext.HttpContext.Request);
            _manager = manager;
        }
        [HttpPost]
        public async Task<ApiResponse> AddRole(IdentityRole model)
        {
            try
            {
                var result = await _manager.CreateAsync(model);
                if(result.Succeeded)
                {
                    var role = await _manager.FindByNameAsync(model.Name);
                    _response.AddData(new List<IdentityRole> { role });
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
                        message = $"Could not create role - {errorMsg}",
                        url = "/roles/"
                    });
                }
            }
            catch(Exception ex)
            {
                _response.AddError(new ApiError{
                        code = "500",
                        message = $"Error creating role: {ex.Message}",
                        url = "/roles/"
                    });
            }
            return _response.GenerateReponse();
        }
    }
}