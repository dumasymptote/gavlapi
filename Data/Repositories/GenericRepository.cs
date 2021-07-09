using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using gavl_api.Data.Repositories;
using gavl_api.Models;
using gavl_api.Data;
using System;

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
            try
            {
                return await _table.ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
            
        }
        public async Task<T> GetById(object id)
        {
            try
            {
                return await _table.FindAsync(id);
            }
            catch(Exception ex)
            {
                throw new Exception($"Couldn't retrieve entity: {ex.Message}");
            }           
        }
        public async Task<T> Update(object id, T obj)
        {
            if(obj == null)
            {
                throw new ArgumentNullException($"{nameof(obj)} entity must not be null");
            }
            try
            {
                _table.Update(obj);
                SaveData();
                return await GetById(id);
            }
            catch(Exception ex)
            {
                throw new Exception($"{nameof(obj)} could not be updated: {ex.Message}");
            }
        }
        private async void SaveData() => await _context.SaveChangesAsync();
    }
}