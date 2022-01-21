using Microsoft.EntityFrameworkCore;
using ShopApp.Data;
using ShopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int entityId)
        {
            return _dbSet.FirstOrDefault(x => x.Id == entityId);
        }

        public int Create(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public void CreateRange(List<T> entities)
        {
            _context.AddRange(entities);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

        public void Remove(int entityId)
        {
            var entity = GetById(entityId);

            _context.Remove(entity);
            _context.SaveChanges();
        }

        public void RemoveRange(List<T> entities)
        {
            _context.RemoveRange(entities);
            _context.SaveChanges();
        }
    }
}
