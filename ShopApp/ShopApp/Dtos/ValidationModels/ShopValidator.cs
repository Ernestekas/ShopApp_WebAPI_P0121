using FluentValidation;
using ShopApp.Dtos.ErrorModels;
using ShopApp.Models;
using System.Collections.Generic;

namespace ShopApp.Dtos.ValidationModels
{
    public class ShopValidator : BaseValidator<Shop>
    {
        public ShopValidator()
        {
            RuleFor(s => s.Name).NotEmpty();
            RuleFor(s => s.Name).MinimumLength(5);
        }

        public void TryValidateShop(Shop shop, List<string> existingShopNames, string oldShopName = null)
        {
            var error = new ErrorModel();

            if (string.IsNullOrWhiteSpace(oldShopName))
            {
                error = CheckIdIsZero(shop, error);
            }

            error = TryValidateUniqueName(null, shop, existingShopNames, error);
            TryValidateBase(shop, error);
        }
    }
}
