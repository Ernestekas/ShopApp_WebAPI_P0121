using System;

namespace ShopApp.Dtos.ErrorModels.ShopExceptions
{
    public class ShopNotUniqueException : Exception
    {
        public ShopNotUniqueException() { }

        public ShopNotUniqueException(string message) 
            :base(message){ }
    }
}
