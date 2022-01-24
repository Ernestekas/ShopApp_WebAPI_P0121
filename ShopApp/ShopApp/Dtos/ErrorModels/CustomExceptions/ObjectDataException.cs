using System;

namespace ShopApp.Dtos.ErrorModels.CustomExceptions
{
    [Serializable]
    public class ObjectDataException : Exception
    {
        public ObjectDataException(string message)
            : base(message) { }
    }
}
