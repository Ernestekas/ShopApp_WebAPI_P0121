using System;

namespace ShopApp.Dtos.ErrorModels.ProductExceptions
{
    public class ProductUpdateException : Exception
    {
        public ProductUpdateException() { }

        public ProductUpdateException(string message)
            : base(message) { }
    }
}
