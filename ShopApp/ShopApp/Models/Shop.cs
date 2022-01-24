using System;
using System.Collections.Generic;

namespace ShopApp.Models
{
    public class Shop : Entity
    {
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
