using System;

namespace ShopApp.Dtos.ErrorModels.ShopExceptions
{
    [Serializable]
    public class ShopNotFoundException : Exception
    {
        public ShopNotFoundException() { }

        public ShopNotFoundException(string message)
            : base(message) { }

    }
}
