using AutoMapper;
using ShopApp.Dtos;
using ShopApp.Dtos.ValidationModels;
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
        private readonly IMapper _mapper;
        private readonly ShopValidator _shopValidator;

        public ShopService(ShopRepository shopRepository, IMapper mapper, ShopValidator shopValidator)
        {
            _shopRepository = shopRepository;
            _mapper = mapper;
            _shopValidator = shopValidator;
        }

        public List<ShopDto> GetAll()
        {
            List<ShopDto> result = new List<ShopDto>();
            List<Shop> shops = _shopRepository.GetAllIncluded();

            foreach(var shop in shops)
            {
                ShopDto shopDto = new ShopDto();

                _mapper.Map(shop, shopDto);
                shopDto.Products = MapProducts(shop.Products);

                result.Add(shopDto);
            }

            return result;
        }

        public ShopDto GetById(int id)
        {
            ShopDto result = new ShopDto();
            Shop shop = _shopRepository.GetByIdIncluded(id);

            _shopValidator.TryValidateGet(shop);

            _mapper.Map(shop, result);
            result.Products = MapProducts(shop.Products);

            return result;
        }

        public int Create(ShopDto shop)
        {
            Shop newShop = new Shop()
            {
                Name = shop.Name
            };

            _shopValidator.TryValidateShopCreation(newShop);

            return _shopRepository.Create(newShop);
        }

        public void Update(int id, string newName)
        {
            Shop shop = _shopRepository.GetById(id);
            _shopValidator.TryValidateGet(shop);

            shop.Name = newName;
            _shopValidator.TryValidateShopUpdate(id, shop);

            _shopRepository.Update(shop);
        }

        public void Delete(int id)
        {
            Shop shop = _shopRepository.GetById(id);
            
            _shopValidator.TryValidateGet(shop);

            _shopRepository.Remove(id);
        }

        private List<ProductDto> MapProducts(List<Product> products)
        {
            List<ProductDto> result = new List<ProductDto>();

            foreach(var product in products)
            {
                ProductDto productDto = new ProductDto();
                _mapper.Map(product, productDto);
                result.Add(productDto);
            }

            return result;
        }
    }
}
