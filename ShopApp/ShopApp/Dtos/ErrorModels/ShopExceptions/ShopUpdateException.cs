using System;

namespace ShopApp.Dtos.ErrorModels.ShopExceptions
{
    public class ShopUpdateException : Exception
    {
        public ShopUpdateException() { }

        public ShopUpdateException(string message) 
            :base(message) { }
    }
}
