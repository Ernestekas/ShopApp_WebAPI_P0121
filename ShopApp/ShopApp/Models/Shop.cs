using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Models
{
    public class Shop : Entity
    {
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
