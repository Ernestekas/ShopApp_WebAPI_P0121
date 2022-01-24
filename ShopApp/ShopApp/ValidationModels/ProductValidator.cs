using FluentValidation;
using ShopApp.Models;

namespace ShopApp.ValidationModels
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Price).GreaterThan(0);
        }
    }
}
