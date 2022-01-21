using ShopApp.Dtos;
using ShopApp.Models;
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

        public List<ShopDto> GetAll()
        {
            List<Shop> shops = _shopRepository.GetAllIncluded();

            foreach(var shop in shops)
            {
                ShopDto shopDto = new ShopDto()
                {
                    ShopId = shop.Id,
                    ShopName = shop.Name,
                    Created = shop.DateCreated
                };
            }
        }
    }
}
