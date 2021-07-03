using System.Collections.Generic;
using System.Threading.Tasks;
using gavl_api.Data.Repositories;
using gavl_api.Data.Services;
using gavl_api.Models;

namespace gavl_api.Domain.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository) => _accountRepository = accountRepository;
        public async Task<IEnumerable<Account>> ListAsync() => await _accountRepository.ListAsync();
    }
}