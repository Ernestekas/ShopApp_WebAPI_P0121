using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Models
{
    public class Shop : Entity
    {
        public DateTime DateCreated { get; set; }
        public List<Product> Products { get; set; }
    }
}
