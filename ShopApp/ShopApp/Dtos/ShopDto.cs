using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Dtos
{
    public class ShopDto
    {
        public int ShopId { get; set; }
        public string ShopName { get; set; }
        public List<ProductDto> Products { get; set; }
        public DateTime Created { get; set; }
    }
}
