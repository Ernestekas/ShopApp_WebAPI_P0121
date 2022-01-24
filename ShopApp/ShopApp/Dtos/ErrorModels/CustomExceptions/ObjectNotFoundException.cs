using System;

namespace ShopApp.Dtos.ErrorModels.CustomExceptions
{
    [Serializable]
    public class ObjectNotFoundException : Exception
    {
        public ObjectNotFoundException(string message)
            : base(message) { }
    }
}
