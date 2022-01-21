using ShopApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Services
{
    public class ShopService
    {
        private readonly ShopRepository _shopRepository;

        public ShopService(ShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }
    }
}
