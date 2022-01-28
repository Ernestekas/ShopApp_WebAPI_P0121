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

        public async Task<List<ProductDto>> GetAll()
        {
            List<Product> products = await _productRepository.GetAllIncluded();
            List<ProductDto> result = MapProducts(products);

            return result;
        }

        public async Task<ProductDto> GetById(int id)
        {
            ProductDto result = new ProductDto();
            Product product = await _productRepository.GetByIdIncluded(id);

            _productValidator.TryValidateGet(product);
            
            result.ShopName = product.Shop.Name;
            
            return _mapper.Map(product, result);
        }

        public async Task<int> Create(ProductDto product)
        {
            Product newProduct = new Product();
            Shop shop = await _shopRepository.GetById(product.ShopId);

            product.Id = 0;
            _mapper.Map(product, newProduct);

            _productValidator.TryValidateProduct(newProduct, false);
            _shopValidator.TryValidateGet(shop);

            newProduct.Shop = shop;

            return await _productRepository.Create(newProduct);
        }

        public async void Update(int id, ProductDto product)
        {
            Product updated = new Product();

            _mapper.Map(product, updated);
            updated.Id = id;
            updated.Shop = await _shopRepository.GetById(product.ShopId);

            _productValidator.TryValidateProduct(updated, true);
            _shopValidator.TryValidateGet(updated.Shop);

            _productRepository.Update(updated);
        }

        public async void Delete(int id)
        {
            Product product = await _productRepository.GetById(id);

            _productValidator.TryValidateGet(product);

            _productRepository.Remove(id);
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
