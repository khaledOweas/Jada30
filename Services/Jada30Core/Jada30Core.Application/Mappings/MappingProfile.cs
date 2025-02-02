using AutoMapper;
using Jada30Core.Common.Facility;
using Jada30Core.Common.Branch;
using Domain;
using Jada30Core.Common.Package;
using Jada30Core.Common.PackageFaclilty;


namespace Identity.Application.Mappings;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateFacilityDto, Domain.Facilities>().ReverseMap();
        CreateMap<FacilityDto, Domain.Facilities>()
             .ForPath(dest => dest.Category.Name, opt => opt.MapFrom(src => src.CategoryName))
             .ForPath(dest => dest.Category.NameAr, opt => opt.MapFrom(src => src.CategoryNameAr))

             .ForPath(dest => dest.Destination.Name, opt => opt.MapFrom(src => src.DestinationName))
             .ForPath(dest => dest.Destination.NameAr, opt => opt.MapFrom(src => src.DestinationNameAr))

             .ForPath(dest => dest.PricingUnit.Name, opt => opt.MapFrom(src => src.PricingUnitName))
             .ForPath(dest => dest.PricingUnit.NameAr, opt => opt.MapFrom(src => src.PricingUnitNameAr))

             .ForPath(dest => dest.Subscription.Name, opt => opt.MapFrom(src => src.SubscriptionName))
             .ForPath(dest => dest.Subscription.NameAr, opt => opt.MapFrom(src => src.SubscriptionNameAr))

             .ForPath(dest => dest.Type.Name, opt => opt.MapFrom(src => src.TypeName))
             .ForPath(dest => dest.Type.NameAr, opt => opt.MapFrom(src => src.TypeNameAr))

             .ReverseMap()
             .ForPath(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
             .ForPath(dest => dest.CategoryNameAr, opt => opt.MapFrom(src => src.Category.NameAr))

             .ForPath(dest => dest.DestinationName, opt => opt.MapFrom(src => src.Destination.Name))
             .ForPath(dest => dest.DestinationNameAr, opt => opt.MapFrom(src => src.Destination.NameAr))

             .ForPath(dest => dest.PricingUnitName, opt => opt.MapFrom(src => src.PricingUnit.Name))
             .ForPath(dest => dest.PricingUnitNameAr, opt => opt.MapFrom(src => src.PricingUnit.NameAr))

             .ForPath(dest => dest.SubscriptionName, opt => opt.MapFrom(src => src.Subscription.Name))
             .ForPath(dest => dest.SubscriptionNameAr, opt => opt.MapFrom(src => src.Subscription.NameAr))

             .ForPath(dest => dest.TypeName, opt => opt.MapFrom(src => src.Type.Name))
             .ForPath(dest => dest.TypeNameAr, opt => opt.MapFrom(src => src.Type.NameAr));



        CreateMap<GetBranchDto, Branch>().ReverseMap();
        CreateMap<CreateBranchDto, Branch>().ReverseMap();
        CreateMap<CreateBranchComponentDto, BranchComponent>().ReverseMap();
        CreateMap<GetBranchComponentDto, BranchComponent>()
            .ForPath(dest => dest.Branch.Name, opt => opt.MapFrom(src => src.BranchName))
            .ForPath(dest => dest.Branch.NameAr, opt => opt.MapFrom(src => src.BranchNameAr))

            .ForPath(dest => dest.Component.Name, opt => opt.MapFrom(src => src.ComponentName))
            .ForPath(dest => dest.Component.NameAr, opt => opt.MapFrom(src => src.ComponentNameAr))

            .ReverseMap()
            .ForPath(dest => dest.BranchName, opt => opt.MapFrom(src => src.Branch.Name))
            .ForPath(dest => dest.BranchNameAr, opt => opt.MapFrom(src => src.Branch.NameAr))

            .ForPath(dest => dest.ComponentName, opt => opt.MapFrom(src => src.Component.Name))
            .ForPath(dest => dest.ComponentNameAr, opt => opt.MapFrom(src => src.Component.NameAr));


        CreateMap<AddPackageDto, Package>().ReverseMap();
        CreateMap<GetPackageDto, Package>().ReverseMap();
        CreateMap<GetPackageFacilityDto, PackageFacility>()
            .ForPath(dest => dest.Facility.Name, opt => opt.MapFrom(src => src.FacilityName))
            .ForPath(dest => dest.Facility.NameAr, opt => opt.MapFrom(src => src.FacilityNameAr))

            .ForPath(dest => dest.Package.Name, opt => opt.MapFrom(src => src.PackageName))
            .ForPath(dest => dest.Package.NameAr, opt => opt.MapFrom(src => src.PackageNameAr))

            .ForPath(dest => dest.Type.Name, opt => opt.MapFrom(src => src.TypeName))
            .ForPath(dest => dest.Type.NameAr, opt => opt.MapFrom(src => src.TypeNameAr))
            .ReverseMap()
            .ForPath(dest => dest.FacilityName, opt => opt.MapFrom(src => src.Facility.Name))
            .ForPath(dest => dest.FacilityNameAr, opt => opt.MapFrom(src => src.Facility.NameAr))

            .ForPath(dest => dest.PackageName, opt => opt.MapFrom(src => src.Package.Name))
            .ForPath(dest => dest.PackageNameAr, opt => opt.MapFrom(src => src.Package.NameAr))

            .ForPath(dest => dest.TypeName, opt => opt.MapFrom(src => src.Type.Name))
            .ForPath(dest => dest.TypeNameAr, opt => opt.MapFrom(src => src.Type.NameAr));

        CreateMap<AddPackageFacilityDto, PackageFacility>().ReverseMap();




    }
}