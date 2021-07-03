using System.Collections.Generic;
using System.Threading.Tasks;
using gavl_api.Models;

namespace gavl_api.Data.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> ListAsync();
    }
}