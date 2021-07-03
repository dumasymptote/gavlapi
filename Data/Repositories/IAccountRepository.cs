using System.Collections.Generic;
using System.Threading.Tasks;
using gavl_api.Models;

namespace gavl_api.Data.Repositories
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> ListAsync();
    }
}