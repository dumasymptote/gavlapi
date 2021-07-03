using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using gavl_api.Models;
using gavl_api.Data;
using gavl_api.Domain.Repositories;

namespace gavl_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly GenericRepository<Account> _accountRepo = null;

        public AccountsController (AppDbContext context)
        {
            _context = context;
            _accountRepo = new GenericRepository<Account>(context);
        }

        [HttpGet]
        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            var accounts = await _accountRepo.ListAsync();
            return accounts;
        }
    }
}