using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using gavl_api.Models;
using gavl_api.Data;
using gavl_api.Data.Repositories;
using gavl_api.Models.DTO;
using Microsoft.AspNetCore.Authorization;

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
        //[Roles("Admin, BusinessAdmin")]
        public AccountsController (AppDbContext context, IMapper mapper)
        {
            _context = context;
            _accountRepo = new GenericRepository<Account>(context);
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            var accounts = await _accountRepo.ListAsync();
            //this is an example of using automapper but not super useful right now.
            //var accountResource = _mapper.Map<IEnumerable<Account>, IEnumerable<AccountResource>>(accounts);
            return accounts;
        }
    }
}