using Microsoft.AspNetCore.Mvc;
using ShopApp.Dtos;
using ShopApp.Dtos.ErrorModels.CustomExceptions;
using ShopApp.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopsController : ControllerBase
    {
        private readonly ShopService _shopService;

        public ShopsController(ShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<ShopDto> result = await _shopService.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                ShopDto result = await _shopService.GetByIdAsync(id);
                return Ok(result);
            }
            catch (ObjectNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(ShopDto shop)
        {
            try
            {
                int id = await _shopService.CreateAsync(shop);
                ShopDto shopDto = await _shopService.GetByIdAsync(id);

                return Created($"~/Api/Shops/{id}", shopDto);
            }
            catch (ObjectDataException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] string shopName)
        {
            try
            {
                _shopService.UpdateAsync(id, shopName);
                return Ok("Shop updated.");
            }
            catch (ObjectNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ObjectDataException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _shopService.DeleteAsync(id);
                return NoContent();
            }
            catch (ObjectNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}