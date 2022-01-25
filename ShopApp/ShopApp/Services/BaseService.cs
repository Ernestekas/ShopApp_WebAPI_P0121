using ShopApp.Dtos.ValidationModels;
using ShopApp.Models;
using ShopApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Services
{
    public class BaseService<T>
        where T : Entity
    {
        private readonly RepositoryBase<T> _repository;
        private readonly BaseValidator<T> _validator;

        public BaseService(RepositoryBase<T> repository, BaseValidator<T> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public void Delete(int id)
        {
            T obj = _repository.GetById(id);

            _validator.TryValidateGet(obj);

            _repository.Remove(id);
        }
    }
}
