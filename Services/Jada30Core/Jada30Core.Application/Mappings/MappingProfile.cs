using AutoMapper;
using Jada30Core.Common.Facility;
using Jada30Core.Common.Branch;
using Domain;
using Jada30Core.Common.SupportingServiceProvider;
using Jada30Core.Common.Perk;


namespace Identity.Application.Mappings;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateFacilityDto, Domain.Facilities>().ReverseMap();
        CreateMap<FacilityDto, Domain.Facilities>()
             .ForPath(dest => dest.Category.Name, opt => opt.MapFrom(src => src.CategoryName))
             .ForPath(dest => dest.Destination.Name, opt => opt.MapFrom(src => src.DestinationName))
             .ForPath(dest => dest.PricingUnit.Name, opt => opt.MapFrom(src => src.PricingUnitName))
             .ForPath(dest => dest.Subscription.Name, opt => opt.MapFrom(src => src.SubscriptionName))
             .ForPath(dest => dest.Type.Name, opt => opt.MapFrom(src => src.TypeName))
             .ReverseMap()
             .ForPath(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
             .ForPath(dest => dest.DestinationName, opt => opt.MapFrom(src => src.Destination.Name))
             .ForPath(dest => dest.PricingUnitName, opt => opt.MapFrom(src => src.PricingUnit.Name))
             .ForPath(dest => dest.SubscriptionName, opt => opt.MapFrom(src => src.Subscription.Name))
             .ForPath(dest => dest.TypeName, opt => opt.MapFrom(src => src.Type.Name));



        CreateMap<GetBranchDto, Branch>().ReverseMap();
        CreateMap<CreateBranchDto, Branch>().ReverseMap();
        CreateMap<CreateBranchComponentDto, BranchComponent>().ReverseMap();
        CreateMap<GetBranchComponentDto, BranchComponent>()
            .ForPath(dest => dest.Branch.Name, opt => opt.MapFrom(src => src.BranchName))
            .ForPath(dest => dest.Component.Name, opt => opt.MapFrom(src => src.ComponentName))
            .ReverseMap()
            .ForPath(dest => dest.BranchName, opt => opt.MapFrom(src => src.Branch.Name))
            .ForPath(dest => dest.ComponentName, opt => opt.MapFrom(src => src.Component.Name));


        CreateMap<CreateSupportingServiceProviderDto, Domain.SupportingServiceProvider>().ReverseMap();
        CreateMap<SupportingServiceProviderDto, Domain.SupportingServiceProvider>()
             .ForPath(dest => dest.Nationality.Name, opt => opt.MapFrom(src => src.NationalityName))
             .ForPath(dest => dest.Specialization.Name, opt => opt.MapFrom(src => src.SpecializationName))
             .ReverseMap()
             .ForPath(dest => dest.NationalityName, opt => opt.MapFrom(src => src.Nationality.Name))
             .ForPath(dest => dest.SpecializationName, opt => opt.MapFrom(src => src.Specialization.Name));

        CreateMap<GetPerkDto, Perk>().ReverseMap();
        CreateMap<CreatePerkDto, Perk>().ReverseMap();
        CreateMap<CreatePerkLicenseDto, PerkLicense>().ReverseMap();
        CreateMap<GetPerkLicenseDto, PerkLicense>()
            .ForPath(dest => dest.Perk.Name, opt => opt.MapFrom(src => src.PerkName))
            .ForPath(dest => dest.License.Name, opt => opt.MapFrom(src => src.LicenseName))
            .ReverseMap()
            .ForPath(dest => dest.LicenseName, opt => opt.MapFrom(src => src.Perk.Name))
            .ForPath(dest => dest.LicenseName, opt => opt.MapFrom(src => src.License.Name));

    }
}