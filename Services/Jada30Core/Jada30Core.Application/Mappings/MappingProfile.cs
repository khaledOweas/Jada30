using AutoMapper;
using Jada30Core.Domain.Entities.Facility;
using Jada30Core.Common.Facility;


namespace Identity.Application.Mappings;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateFacilityDto, Facilities>().ReverseMap();
        CreateMap<FacilityDto, Facilities>().ReverseMap();
    }
}