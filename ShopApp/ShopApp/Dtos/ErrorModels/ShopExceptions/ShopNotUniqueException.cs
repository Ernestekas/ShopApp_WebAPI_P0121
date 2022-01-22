using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Dtos.ErrorModels.ShopExceptions
{
    public class ShopNotUniqueException : Exception
    {
        public ShopNotUniqueException() { }

        public ShopNotUniqueException(string message) 
            :base(message){ }
    }
}
