using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Dtos;
using ShopApp.Services;
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
            List<ShopDto> result = _shopService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ShopDto result = _shopService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add(ShopDto shop)
        {
            int id = _shopService.Create(shop);
            return Created($"~/Shop/{id}", _shopService.GetById(id));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] string shopName)
        {
            _shopService.Update(id, shopName);
            return Ok("Shop updated.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _shopService.Delete(id);
            return NoContent();
        }
    }
}
