using System;

namespace ShopApp.Dtos.ErrorModels.ProductExceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException() { }

        public ProductNotFoundException(string message)
            : base(message) { }

    }
}
