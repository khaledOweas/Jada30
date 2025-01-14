using AutoMapper;

using Identity.Common.Role;
using Identity.Common.User;
using Identity.Infrastructure.Models;

namespace Identity.Application.Mappings;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateUserDto, ApplicationUser>().ReverseMap();
        CreateMap<UpdateUserDto, ApplicationUser>().ReverseMap();
        CreateMap<CreateRoleDto, ApplicationRole>().ReverseMap();

    }
}