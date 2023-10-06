
using API.Dtos.Rol;
using API.Dtos.User;
using AutoMapper;
using Core.Entities;

namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserxRolDto>().ReverseMap();

            CreateMap<Rol, RolDto>().ReverseMap();
        }
    }
}