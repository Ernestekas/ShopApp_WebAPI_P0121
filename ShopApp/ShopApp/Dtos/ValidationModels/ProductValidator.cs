using FluentValidation;
using FluentValidation.Results;
using ShopApp.Dtos.ErrorModels;
using ShopApp.Dtos.ErrorModels.ProductExceptions;
using ShopApp.Models;
using System.Linq;

namespace ShopApp.Dtos.ValidationModels
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Price).GreaterThan(0);
        }

        public void TryValidateGet(Product product)
        {
            if (product == null)
            {
                throw new ProductNotFoundException("Product with inputed 'Id' doesn't exist.");
            }
        }

        public void TryValidateProductCreation(Product product)
        {
            var error = new ErrorModel();

            ValidationResult validation = Validate(product);
            error.ErrorMessages.AddRange(validation.Errors.Select(x => x.ErrorMessage).ToList());
            error = CheckIdIsZero(product.Id, error);

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
            error = CheckIdIsSame(id, productUpdated.Id , error);

            if( error.ErrorMessages.Count > 0)
            {
                throw new ProductUpdateException(string.Join("; ", error.ErrorMessages));
            }
        }

        private ErrorModel CheckIdIsZero(int id, ErrorModel error)
        {
            if(id > 0)
            {
                error.ErrorMessages.Add("When creating new product property 'Id' must be 0.");
            }

            return error;
        }

        private ErrorModel CheckIdIsSame(int inputId, int productId, ErrorModel error)
        {
            if(inputId != productId)
            {
                error.ErrorMessages.Add("Inputed 'Id' and 'Id' from database must match.");
            }

            return error;
        }
    }
}
