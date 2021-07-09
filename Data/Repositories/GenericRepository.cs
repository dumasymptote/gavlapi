using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using gavl_api.Data.Repositories;
using gavl_api.Models;
using gavl_api.Data;

namespace gavl_api.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _table = null;
        public GenericRepository(AppDbContext context)
        {
            _context  = context;
            _table = _context.Set<T>();
        }
        public async Task<IEnumerable<T>> ListAsync()
        {
            return await _table.ToListAsync();
        }
        public async Task<T> GetById(object id)
        {
            return await _table.FindAsync(id);
        }
    }
}