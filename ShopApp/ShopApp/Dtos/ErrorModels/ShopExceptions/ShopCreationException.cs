using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
