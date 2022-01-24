using FluentValidation;
using FluentValidation.Results;
using ShopApp.Dtos.ErrorModels;
using ShopApp.Dtos.ErrorModels.CustomExceptions;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ShopApp.Dtos.ValidationModels
{
    public class BaseValidator<T> : AbstractValidator<T>

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
            PropertyInfo prop = obj.GetType().GetProperty("Id");
            int objId = (int)prop.GetValue(obj, null);

            if(objId > 0)
            {
                errorModel.ErrorMessages.Add("You can't enter 'Id' when creating new object.");
            }

            return errorModel;
        }

        public ErrorModel TryValidateUniqueName(string oldName, T obj, List<string> namesToCompareTo, ErrorModel error)
        {
            PropertyInfo prop = obj.GetType().GetProperty("Name");
            string objName = (string)prop.GetValue(obj, null);

            if(oldName == objName || namesToCompareTo == null)
            {
                return error;
            }

            List<string> matching = namesToCompareTo.Where(x => x == objName).ToList();

            if(matching.Count > 0)
            {
                error.ErrorMessages.Add($"Object with this name {objName} already exists.");
            }

            return error;
        }
    }
}
