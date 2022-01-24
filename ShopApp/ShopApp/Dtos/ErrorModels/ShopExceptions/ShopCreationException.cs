using System;

namespace ShopApp.Dtos.ErrorModels.ShopExceptions
{
    [Serializable]
    public class ShopCreationException : Exception
    {
        public ShopCreationException() { }

        public ShopCreationException(string message) 
            : base(message) { }
    }
}
