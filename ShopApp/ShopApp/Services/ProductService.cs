using AutoMapper;
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
    public class ProductService
    {
        private readonly ProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(ProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public List<ProductDto> GetAll()
        {
            List<ProductDto> result = MapProducts(_productRepository.GetAll());

            return result;
        }

        public ProductDto GetById(int id)
        {
            ProductDto result = new ProductDto();
            Product product = _productRepository.GetByIdIncluded(id);

            result.ShopName = product.Shop.Name;
            
            return _mapper.Map(product, result);
        }

        public int Create(ProductDto product)
        {
            Product newProduct = new Product();

            product.Id = 0;
            _mapper.Map(product, newProduct);

            return _productRepository.Create(newProduct);
        }

        public void Update(int id, ProductDto product)
        {
            Product updated = new Product();
            
            _mapper.Map(product, updated);
            updated.Id = id;

            _productRepository.Update(updated);
        }

        public void Delete(int id)
        {
            _productRepository.Remove(id);
        }

        public int MyProperty { get; set; }

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
