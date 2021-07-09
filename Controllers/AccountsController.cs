using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using gavl_api.Models;
using gavl_api.Data;
using gavl_api.Data.Repositories;
using gavl_api.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using gavl_api.Services;

namespace gavl_api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly GenericRepository<Account> _accountRepo = null;
        private readonly IMapper _mapper;
        private readonly ApiResponseBuilder _response;
        //[Roles("Admin, BusinessAdmin")]
        public AccountsController (AppDbContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _accountRepo = new GenericRepository<Account>(context);
            _mapper = mapper;
            _response = new ApiResponseBuilder(httpContext.HttpContext.Request);
        }
        [HttpGet]
        public async Task<ApiResponse> GetAllAsync()
        {     
            var accounts = await _accountRepo.ListAsync();
            //this is an example of using automapper but not super useful right now.
            //var accountResource = _mapper.Map<IEnumerable<Account>, IEnumerable<AccountResource>>(accounts);
            _response.AddData(accounts);
            return _response.GenerateReponse();
        }
        [HttpGet("{id}")]
        public async Task<ApiResponse> GetAccountById(int id)
        {
            var account = await _accountRepo.GetById(id);
            if(account != null)
                _response.AddData(new List<Account>{account});
            else
                _response.AddError(new ApiError{code="404",message="No Account Found for this ID", url=$"/accounts/{id}"});
            return _response.GenerateReponse();
        }
    }
}