using AutoMapper;
using ShopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Dtos.MappingProfiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Shop, ShopDto>().ReverseMap();
        }
    }
}
