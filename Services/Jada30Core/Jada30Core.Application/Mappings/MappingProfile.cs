using AutoMapper;
using Jada30Core.Domain.Entities.Facility;
using Jada30Core.Common.Facility;
using Jada30Core.Common.BranchComponents;
using Jada30Core.Domain.Entities;
using Jada30Core.Common.Branch;


namespace Identity.Application.Mappings;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateFacilityDto, Facilities>().ReverseMap();
        CreateMap<FacilityDto, Facilities>().ReverseMap();


        CreateMap<GetBranchComponentDto, BranchComponents>().ReverseMap();
        CreateMap<CreateBranchComponentDto, BranchComponents>().ReverseMap();

        CreateMap<GetBranchDto, Branch>().ReverseMap();
        CreateMap<CreateBranchDto, Branch>().ReverseMap();

    }
}