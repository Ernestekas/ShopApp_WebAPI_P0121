using Microsoft.EntityFrameworkCore;
using ShopApp.Data;
using ShopApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Repositories
{
    public class ProductRepository : RepositoryBase<Product>
    {
        public ProductRepository(DataContext context) : base(context) { }

        public async Task<List<Product>> GetAllIncluded()
        {
            return await _context.Products.Include(x => x.Shop).ToListAsync();
        }
        public async Task<Product> GetByIdIncluded(int id)
        {
            return await _context.Products.Include(x => x.Shop).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
