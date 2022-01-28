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

        public async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(int entityId)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == entityId);
        }

        public async Task<int> Create(T entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async void CreateRange(List<T> entities)
        {
            _context.AddRange(entities);
            await _context.SaveChangesAsync();
        }

        public async void Update(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async void Remove(int entityId)
        {
            var entity = await GetById(entityId);

            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async void RemoveRange(List<T> entities)
        {
            _context.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }
    }
}
