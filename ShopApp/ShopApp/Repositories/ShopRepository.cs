using Microsoft.EntityFrameworkCore;
using ShopApp.Data;
using ShopApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Repositories
{
    public class ShopRepository : RepositoryBase<Shop>
    {
        public ShopRepository(DataContext context) : base(context) { }

        public async Task<List<Shop>> GetAllIncluded()
        {
            return await _context.Shops.Include(s => s.Products).ToListAsync();
        }

        public async Task<Shop> GetByIdIncluded(int id)
        {
            return await _context.Shops.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
