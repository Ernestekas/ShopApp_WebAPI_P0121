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
    public class ShopRepository : RepositoryBase<Shop>
    {
        public ShopRepository(DataContext context) : base(context) { }

        public List<Shop> GetAllIncluded()
        {
            return _context.Shops.Include(s => s.Products).ToList();
        }

        public Shop GetByIdIncluded(int id)
        {
            return _context.Shops.Include(x => x.Products).FirstOrDefault(x => x.Id == id);
        }
    }
}
