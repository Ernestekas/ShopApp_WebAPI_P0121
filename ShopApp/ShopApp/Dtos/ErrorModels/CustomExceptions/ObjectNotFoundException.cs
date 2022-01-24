using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Dtos.ErrorModels.CustomExceptions
{
    [Serializable]
    public class ObjectNotFoundException : Exception
    {
        public ObjectNotFoundException(string message)
            : base(message) { }
    }
}
