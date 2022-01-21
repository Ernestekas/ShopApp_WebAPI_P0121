using ShopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShopApp.Controllers.ProductsController;

namespace ShopApp.Repositories
{
    public class ShopRepository : RepositoryBase<Shop>
    {
        public ShopRepository(DataContext context) : base(context) { }
    }
}
