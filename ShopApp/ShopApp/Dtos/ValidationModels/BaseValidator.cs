using FluentValidation;
using FluentValidation.Results;
using ShopApp.Dtos.ErrorModels;
using ShopApp.Dtos.ErrorModels.CustomExceptions;
using ShopApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShopApp.Dtos.ValidationModels
{
    public class BaseValidator<T> : AbstractValidator<T> where T : Entity
    {
        public void TryValidateGet(T obj)
        {
            if (obj == null)
            {
                throw new ObjectNotFoundException($"No {typeof(T).Name} with this 'Id' found.");
            }
        }

        public void TryValidateBase(T obj, ErrorModel error)
        {
            ValidationResult validation = Validate(obj);
            error.ErrorMessages.AddRange(validation.Errors.Select(x => x.ErrorMessage).ToList());

            if(error.ErrorMessages.Count > 0)
            {
                throw new ObjectDataException(string.Join("; ", error.ErrorMessages));
            }
        }

        public ErrorModel CheckIdIsZero(T obj, ErrorModel errorModel)
        {
            if (obj.Id > 0)
            {
                errorModel.ErrorMessages.Add("You can't enter 'Id' when creating new object.");
            }

            return errorModel;
        }

        public ErrorModel TryValidateUniqueName(string oldName, T obj, List<string> namesToCompareTo, ErrorModel error)
        {
            if (oldName == obj.Name || namesToCompareTo == null)
            {
                return error;
            }

            List<string> matching = namesToCompareTo.Where(x => x == obj.Name).ToList();

            if (matching.Count > 0)
            {
                error.ErrorMessages.Add($"{typeof(T).Name} with this name {obj.Name} already exists.");
            }

            return error;
        }
    }
}
