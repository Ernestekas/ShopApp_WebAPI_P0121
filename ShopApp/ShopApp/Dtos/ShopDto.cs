using System;
using System.Collections.Generic;

namespace ShopApp.Dtos
{
    public class ShopDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductDto> Products { get; set; } = new List<ProductDto>();
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
