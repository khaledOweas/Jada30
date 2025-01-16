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

        CreateMap<ApplicationUser, UserDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.UserNameAr, opt => opt.MapFrom(src => src.UserNameAr))
            .ForMember(dest => dest.phoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Roles, opt => opt.Ignore());



        CreateMap<CreateRoleDto, ApplicationRole>().ReverseMap();
        CreateMap<UpdateRoleDto, ApplicationRole>().ReverseMap();
        CreateMap<ApplicationRole, RoleDto>().ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.RoleNameAr, opt => opt.MapFrom(src => src.RoleNameAr));

    }
}