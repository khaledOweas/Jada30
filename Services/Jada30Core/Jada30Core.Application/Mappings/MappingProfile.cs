using AutoMapper;
using Jada30Core.Common.Facility;
using Jada30Core.Common.BranchComponents;
using Jada30Core.Common.Branch;
using Domain;


namespace Identity.Application.Mappings;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateFacilityDto, Domain.Facilities>().ReverseMap();
        CreateMap<FacilityDto, Domain.Facilities>().ReverseMap();

        CreateMap<GetBranchDto, Branch>().ReverseMap();
        CreateMap<CreateBranchDto, Branch>().ReverseMap();

    }
}