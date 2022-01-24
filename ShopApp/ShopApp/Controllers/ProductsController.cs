using Microsoft.AspNetCore.Mvc;
using ShopApp.Dtos;
using ShopApp.Dtos.ErrorModels.ProductExceptions;
using ShopApp.Dtos.ErrorModels.ShopExceptions;
using ShopApp.Services;
using System;
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
            try
            {
                List<ProductDto> result = _productService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                ProductDto result = _productService.GetById(id);
                return Ok(result);
            }
            catch (ProductNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Add(ProductDto product)
        {
            try
            {
                int id = _productService.Create(product);
                return Created($"~/Products/{id}", _productService.GetById(id));
            }
            catch (ProductCreationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ShopNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ProductDto product)
        {
            try
            {
                _productService.Update(id, product);
                return Ok("Product updated.");
            }
            catch (ProductUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ShopNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _productService.Delete(id);
                return NoContent();
            }
            catch (ProductNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
