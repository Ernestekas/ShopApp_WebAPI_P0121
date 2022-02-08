using Microsoft.AspNetCore.Mvc;
using ShopApp.Dtos;
using ShopApp.Dtos.ErrorModels.CustomExceptions;
using ShopApp.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<ProductDto> result = await _productService.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                ProductDto result = await _productService.GetByIdAsync(id);
                return Ok(result);
            }
            catch (ObjectNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductDto product)
        {
            try
            {
                int id = await _productService.CreateAsync(product);
                return Created($"~/Products/{id}", await _productService.GetByIdAsync(id));
            }
            catch (ObjectDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ObjectNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductDto product)
        {
            try
            {
                await _productService.UpdateAsync(id, product);
                return Ok("Product updated.");
            }
            catch (ObjectDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ObjectNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _productService.DeleteAsync(id);
                return NoContent();
            }
            catch (ObjectNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
