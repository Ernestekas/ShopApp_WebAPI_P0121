using AutoMapper;
using ShopApp.Dtos;
using ShopApp.Dtos.ValidationModels;
using ShopApp.Models;
using ShopApp.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopApp.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;
        private readonly ShopRepository _shopRepository;
        private readonly IMapper _mapper;
        private readonly ProductValidator _productValidator;
        private readonly ShopValidator _shopValidator;

        public ProductService(ProductRepository productRepository, ShopRepository shopRepository, IMapper mapper, ProductValidator productValidator, ShopValidator shopValidator)
        {
            _productRepository = productRepository;
            _shopRepository = shopRepository;
            _mapper = mapper;
            _productValidator = productValidator;
            _shopValidator = shopValidator;
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            List<Product> products = await _productRepository.GetAllIncluded();
            List<ProductDto> result = MapProducts(products);

            return result;
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            ProductDto result = new ProductDto();
            Product product = await _productRepository.GetByIdIncluded(id);

            _productValidator.TryValidateGet(product);
            
            result.ShopName = product.Shop.Name;
            
            return _mapper.Map(product, result);
        }

        public async Task<int> CreateAsync(ProductDto product)
        {
            Product newProduct = new Product();
            Shop shop = await _shopRepository.GetByIdAsync(product.ShopId);

            product.Id = 0;
            _mapper.Map(product, newProduct);

            _productValidator.TryValidateProduct(newProduct, false);
            _shopValidator.TryValidateGet(shop);

            newProduct.Shop = shop;

            return await _productRepository.CreateAsync(newProduct);
        }

        public async void UpdateAsync(int id, ProductDto product)
        {
            Product updated = new Product();

            _mapper.Map(product, updated);
            updated.Id = id;
            updated.Shop = await _shopRepository.GetByIdAsync(product.ShopId);

            _productValidator.TryValidateProduct(updated, true);
            _shopValidator.TryValidateGet(updated.Shop);

            _productRepository.UpdateAsync(updated);
        }

        public async Task DeleteAsync(int id)
        {
            Product product = await _productRepository.GetByIdAsync(id);

            _productValidator.TryValidateGet(product);

            await _productRepository.RemoveAsync(product);
        }

        private List<ProductDto> MapProducts(List<Product> products)
        {
            List<ProductDto> result = new List<ProductDto>();

            foreach (Product product in products)
            {
                ProductDto productDto = new ProductDto();
                _mapper.Map(product, productDto);
                result.Add(productDto);
            }

            return result;
        }
    }
}
