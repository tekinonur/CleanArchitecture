using AutoMapper;
using CA.Core.Domain.Entities;
using CA.Core.Application.DTOs;

namespace CA.Core.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Item, ItemDTO>();
            CreateMap<ItemDTO, Item>();
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}