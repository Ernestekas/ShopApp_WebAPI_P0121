using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Dtos.ErrorModels.CustomExceptions
{
    public class ObjectDataException : Exception
    {
        public ObjectDataException() { }

        public ObjectDataException(string message)
            : base(message) { }
    }
}
