using System.Collections.Generic;
using System.Threading.Tasks;

namespace gavl_api.Data.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> ListAsync();
        Task<T> GetById(object id);
    }
}