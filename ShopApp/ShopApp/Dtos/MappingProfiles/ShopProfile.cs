using AutoMapper;
using ShopApp.Models;

namespace ShopApp.Dtos.MappingProfiles
{
    public class ShopProfile : Profile
    {
        public ShopProfile()
        {
            CreateMap<Shop, ShopDto>().ReverseMap();
        }
    }
}
