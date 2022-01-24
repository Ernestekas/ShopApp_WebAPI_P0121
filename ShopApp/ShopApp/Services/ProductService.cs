using AutoMapper;
using ShopApp.Dtos;
using ShopApp.Dtos.ValidationModels;
using ShopApp.Models;
using ShopApp.Repositories;
using System.Collections.Generic;

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

        public List<ProductDto> GetAll()
        {
            List<ProductDto> result = MapProducts(_productRepository.GetAllIncluded());

            return result;
        }

        public ProductDto GetById(int id)
        {
            ProductDto result = new ProductDto();
            Product product = _productRepository.GetByIdIncluded(id);

            _productValidator.TryValidateGet(product);
            
            result.ShopName = product.Shop.Name;
            
            return _mapper.Map(product, result);
        }

        public int Create(ProductDto product)
        {
            Product newProduct = new Product();

            product.Id = 0;
            _mapper.Map(product, newProduct);

            _productValidator.TryValidateProductCreation(newProduct);
            _shopValidator.TryValidateGet(_shopRepository.GetById(product.ShopId));

            return _productRepository.Create(newProduct);
        }

        public void Update(int id, ProductDto product)
        {
            Product updated = new Product();

            _mapper.Map(product, updated);
            updated.Id = id;
            updated.Shop = _shopRepository.GetById(product.ShopId);

            _productValidator.TryValidateProductUpdate(id, updated);

            _productRepository.Update(updated);
        }

        public void Delete(int id)
        {
            Product product = _productRepository.GetById(id);

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
