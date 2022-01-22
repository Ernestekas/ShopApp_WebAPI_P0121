using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
