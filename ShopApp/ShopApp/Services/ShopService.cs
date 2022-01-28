using AutoMapper;
using ShopApp.Dtos;
using ShopApp.Dtos.ValidationModels;
using ShopApp.Models;
using ShopApp.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Services
{
    public class ShopService : ServiceBase<Shop, ShopRepository, ShopValidator>
    {
        private readonly ShopRepository _shopRepository;
        private readonly ShopValidator _shopValidator;

        public ShopService(ShopRepository shopRepository, IMapper mapper, ShopValidator shopValidator) : base(mapper, shopRepository, shopValidator)
        {
            _shopRepository = shopRepository;
            _mapper = mapper;
            _shopValidator = shopValidator;
        }

        public async Task<List<ShopDto>> GetAllAsync()
        {
            List<ShopDto> result = new();
            List<Shop> shops = await _shopRepository.GetAllIncluded();

            foreach(var shop in shops)
            {
                ShopDto shopDto = new();

                _mapper.Map(shop, shopDto);
                shopDto.Products = MapProducts(shop.Products);

                result.Add(shopDto);
            }

            return result;
        }

        public async Task<ShopDto> GetByIdAsync(int id)
        {
            ShopDto result = new();
            Shop shop = await _shopRepository.GetByIdIncluded(id);

            _shopValidator.TryValidateGet(shop);

            _mapper.Map(shop, result);
            result.Products = MapProducts(shop.Products);

            return result;
        }

        public async Task<int> CreateAsync(ShopDto shop)
        {
            Shop newShop = new()
            {
                Name = shop.Name
            };
            List<Shop> shops = await _shopRepository.GetAll();
            _shopValidator.TryValidateShop(newShop, shops.Select(s => s.Name).ToList());

            return await _shopRepository.Create(newShop);
        }

        public async void UpdateAsync(int id, string newName)
        {
            Shop shop = await _shopRepository.GetById(id);
            List<Shop> shops = await _shopRepository.GetAll();
            List<string> shopsNames = shops.Select(s => s.Name).ToList();
            string oldName = shop.Name;

            _shopValidator.TryValidateGet(shop);

            shop.Name = newName;

            _shopValidator.TryValidateShop(shop, shopsNames, oldName);

            _shopRepository.Update(shop);
        }

        private List<ProductDto> MapProducts(List<Product> products)
        {
            List<ProductDto> result = new();

            foreach(var product in products)
            {
                ProductDto productDto = new();
                _mapper.Map(product, productDto);
                result.Add(productDto);
            }

            return result;
        }
    }
}
