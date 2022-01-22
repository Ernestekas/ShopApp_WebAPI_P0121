using FluentValidation;
using FluentValidation.Results;
using ShopApp.Dtos.ErrorModels;
using ShopApp.Dtos.ErrorModels.ShopExceptions;
using ShopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Dtos.ValidationModels
{
    public class ShopValidator : AbstractValidator<Shop>
    {
        public ShopValidator()
        {
            RuleFor(s => s.Name).NotEmpty();
            RuleFor(s => s.Name).MinimumLength(5);
        }

        public void TryValidateGet(Shop shop)
        {
            if(shop == null)
            {
                throw new ShopNotFoundException($"No shops with this 'Id' exists.");
            }
        }
        public void TryValidateShopCreation(Shop shop, List<string> existingShopNames)
        {
            var error = new ErrorModel();

            ValidationResult validation = Validate(shop);
            error.ErrorMessages.AddRange(validation.Errors.Select(x => x.ErrorMessage).ToList());
            error = CheckIdIsZero(shop.Id, error);
            error = TryValidateUniqueName(null, shop, existingShopNames, error);

            if(error.ErrorMessages.Count > 0)
            {
                throw new ShopCreationException(string.Join("; ", error.ErrorMessages));
            }
        }

        public void TryValidateShopUpdate(int id, string oldName, Shop shop, List<string> existingShopsNames)
        {
            var error = new ErrorModel();

            ValidationResult validation = Validate(shop);
            error.ErrorMessages.AddRange(validation.Errors.Select(x => x.ErrorMessage).ToList());
            error = CheckIdIsSame(id, shop, error);
            error = TryValidateUniqueName(oldName, shop, existingShopsNames, error);

            if(error.ErrorMessages.Count > 0)
            {
                throw new ShopUpdateException(string.Join("; ", error.ErrorMessages));
            }
        }

        private ErrorModel TryValidateUniqueName(string oldName, Shop shop, List<string> existingShopsNames, ErrorModel errorModel)
        {
            if(oldName == shop.Name || existingShopsNames == null)
            {
                return errorModel;
            }

            List<string> matching = existingShopsNames.Where(s => s == shop.Name).ToList();

            if (matching.Count > 0)
            {
                errorModel.ErrorMessages.Add($"Shop with this name: '{shop.Name}' already exists.");
            }

            return errorModel;
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
