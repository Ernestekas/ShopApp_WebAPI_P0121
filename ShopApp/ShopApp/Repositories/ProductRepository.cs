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
    public class ProductRepository : RepositoryBase<Product>
    {
        public ProductRepository(DataContext context) : base(context) { }

        public Product GetByIdIncluded(int id)
        {
            return _context.Products.Include(x => x.Shop).FirstOrDefault(x => x.Id == id);
        }
    }
}
