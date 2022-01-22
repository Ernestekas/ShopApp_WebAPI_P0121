using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Dtos.ErrorModels.ShopExceptions
{
    public class ShopUpdateException : Exception
    {
        public ShopUpdateException() { }

        public ShopUpdateException(string message) 
            :base(message) { }
    }
}
