using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Dtos.ErrorModels.ProductExceptions
{
    public class ProductUpdateException : Exception
    {
        public ProductUpdateException() { }

        public ProductUpdateException(string message)
            : base(message) { }
    }
}
