using AutoMapper;
using NorthwindApp.DTOs;
using NorthwindApp.Entities;

namespace NorthwindApp.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
