using AutoMapper;
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
    public class ServiceBase<T, Y, U>
        where T : Entity
        where Y : RepositoryBase<T>
        where U : BaseValidator<T>
    {
        public IMapper _mapper;
        public Y _repository;
        public U _validator;

        public ServiceBase(IMapper mapper, Y repository, U validator)
        {
            _mapper = mapper;
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
