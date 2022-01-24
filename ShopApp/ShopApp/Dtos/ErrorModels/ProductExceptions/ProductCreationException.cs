using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Dtos.ErrorModels.ProductExceptions
{
    public class ProductCreationException : Exception
    {
        public ProductCreationException() { }

        public ProductCreationException(string message)
            : base(message) { }

    }
}
