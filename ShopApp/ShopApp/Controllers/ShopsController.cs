using Microsoft.AspNetCore.Mvc;
using ShopApp.Dtos;
using ShopApp.Dtos.ErrorModels.CustomExceptions;
using ShopApp.Services;
using System;
using System.Collections.Generic;

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
        public IActionResult GetAll()
        {
            try
            {
                List<ShopDto> result = _shopService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                ShopDto result = _shopService.GetById(id);
                return Ok(result);
            }
            catch (ObjectNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Add(ShopDto shop)
        {
            try
            {
                int id = _shopService.Create(shop);
                return Created($"~/Api/Shops/{id}", _shopService.GetById(id));
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
                _shopService.Update(id, shopName);
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
        public IActionResult Delete(int id)
        {
            try
            {
                _shopService.Delete(id);
                return NoContent();
            }
            catch (ObjectNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}