using FluentValidation;
using FluentValidation.Results;
using ShopApp.Dtos.ErrorModels;
using ShopApp.Dtos.ErrorModels.ProductExceptions;
using ShopApp.Models;
using System.Linq;

namespace ShopApp.Dtos.ValidationModels
{
    public class ProductValidator : BaseValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Price).GreaterThan(0);
        }

        //public void TryValidateGet(Product product)
        //{
        //    if (product == null)
        //    {
        //        throw new ProductNotFoundException("Product with inputed 'Id' doesn't exist.");
        //    }
        //}

        public void TryValidateProductCreation(Product product)
        {
            var error = new ErrorModel();

            ValidationResult validation = Validate(product);
            error.ErrorMessages.AddRange(validation.Errors.Select(x => x.ErrorMessage).ToList());
            error = CheckIdIsZero(product, error);

            if(error.ErrorMessages.Count > 0)
            {
                throw new ProductCreationException(string.Join("; ", error.ErrorMessages));
            }
        }

        public void TryValidateProductUpdate(int id, Product productUpdated)
        {
            var error = new ErrorModel();

            ValidationResult validation = Validate(productUpdated);
            error.ErrorMessages.AddRange(validation.Errors.Select(x => x.ErrorMessage).ToList());
            //error = CheckIdIsSame(id, productUpdated , error);

            if( error.ErrorMessages.Count > 0)
            {
                throw new ProductUpdateException(string.Join("; ", error.ErrorMessages));
            }
        }
    }
}
