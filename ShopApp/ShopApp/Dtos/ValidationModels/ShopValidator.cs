using FluentValidation;
using FluentValidation.Results;
using ShopApp.Dtos.ErrorModels;
using ShopApp.Dtos.ErrorModels.ShopExceptions;
using ShopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Dtos.ValidationModels
{
    public class ShopValidator : AbstractValidator<Shop>
    {
        public ShopValidator()
        {
            RuleFor(s => s.Name).MinimumLength(5);
        }

        public void TryValidateGet(Shop shop)
        {
            if(shop == null)
            {
                throw new ShopNotFoundException($"No shops with this 'Id' exists.");
            }
        }
        public void TryValidateShopCreation(Shop shop)
        {
            var error = new ErrorModel();
            ValidationResult validation = Validate(shop);

            error.ErrorMessages.AddRange(validation.Errors.Select(x => x.ErrorMessage).ToList());
            error = CheckIdIsZero(shop.Id, error);
            
            if(error.ErrorMessages.Count > 0)
            {
                throw new ShopCreationException(string.Join("; ", error.ErrorMessages));
            }
        }

        public void TryValidateShopUpdate(int id, Shop shop)
        {
            TryValidateGet(shop);

            var error = new ErrorModel();
            ValidationResult validation = Validate(shop);
            
            error.ErrorMessages.AddRange(validation.Errors.Select(x => x.ErrorMessage).ToList());
        }

        private ErrorModel CheckIdIsZero(int id, ErrorModel errorModel)
        {
            if(id > 0)
            {
                errorModel.ErrorMessages.Add("ID - You can't enter custom Ids.");
            }

            return errorModel;
        }

        private ErrorModel CheckIdIsSame(int id, Shop shop, ErrorModel errorModel)
        {
            if(id != shop.Id)
            {
                errorModel.ErrorMessages.Add("Input 'Id' and 'Id' from database must match.");
            }

            return errorModel;
        }
    }
}
