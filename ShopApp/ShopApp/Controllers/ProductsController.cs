using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApp.Dtos;
using ShopApp.Services;
using System.Collections.Generic;

namespace ShopApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<ProductDto> result = _productService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ProductDto result = _productService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add(ProductDto product)
        {
            int id = _productService.Create(product);
            return Created($"~/Products/{id}", _productService.GetById(id));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ProductDto product)
        {
            _productService.Update(id, product);
            return Ok("Product updated.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            return NoContent();
        }
    }
}
