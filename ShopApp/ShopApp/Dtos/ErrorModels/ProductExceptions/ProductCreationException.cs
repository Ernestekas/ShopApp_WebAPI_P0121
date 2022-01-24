using System;

namespace ShopApp.Dtos.ErrorModels.ProductExceptions
{
    public class ProductCreationException : Exception
    {
        public ProductCreationException() { }

        public ProductCreationException(string message)
            : base(message) { }

    }
}
