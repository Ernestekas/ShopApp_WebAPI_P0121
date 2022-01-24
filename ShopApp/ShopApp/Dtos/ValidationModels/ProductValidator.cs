using FluentValidation;
using ShopApp.Dtos.ErrorModels;
using ShopApp.Models;

namespace ShopApp.Dtos.ValidationModels
{
    public class ProductValidator : BaseValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Price).GreaterThan(0);
        }

        public void TryValidateProduct(Product product, bool updating)
        {
            var error = new ErrorModel();
            
            if (!updating)
            {
                error = CheckIdIsZero(product, error);
            }

            TryValidateBase(product, error);
        }
    }
}
