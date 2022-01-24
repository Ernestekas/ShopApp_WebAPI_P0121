using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Dtos.ErrorModels.ProductExceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException() { }

        public ProductNotFoundException(string message)
            : base(message) { }

    }
}
