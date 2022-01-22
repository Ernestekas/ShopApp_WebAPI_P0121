using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Dtos.ErrorModels
{
    public class ErrorModel
    {
        public List<string> ErrorMessages { get; set; } = new List<string>();
    }
}
