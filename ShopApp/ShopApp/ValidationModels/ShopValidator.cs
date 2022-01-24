using FluentValidation;
using ShopApp.Models;

namespace ShopApp.ValidationModels
{
    public class ShopValidator : AbstractValidator<Shop>
    {
        public ShopValidator()
        {
            RuleFor(shop => shop.Name).MinimumLength(4);
        }
    }
}
