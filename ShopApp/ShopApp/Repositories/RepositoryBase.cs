using Microsoft.EntityFrameworkCore;
using ShopApp.Data;
using ShopApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Repositories
{
    public abstract class RepositoryBase<T> where T : Entity
    {
        protected DataContext _context;
        private DbSet<T> _dbSet;

        protected RepositoryBase(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int entityId)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == entityId);
        }

        public async Task<int> CreateAsync(T entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
