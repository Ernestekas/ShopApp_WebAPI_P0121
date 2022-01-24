using System.Collections.Generic;

namespace ShopApp.Dtos.ErrorModels
{
    public class ErrorModel
    {
        public List<string> ErrorMessages { get; set; } = new List<string>();
    }
}
