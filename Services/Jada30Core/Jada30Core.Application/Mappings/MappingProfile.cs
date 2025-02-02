﻿using AutoMapper;
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
             .ForPath(dest => dest.Destination.Name, opt => opt.MapFrom(src => src.DestinationName))
             .ForPath(dest => dest.PricingUnit.Name, opt => opt.MapFrom(src => src.PricingUnitName))
             .ForPath(dest => dest.Subscription.Name, opt => opt.MapFrom(src => src.SubscriptionName))
             .ForPath(dest => dest.Type.Name, opt => opt.MapFrom(src => src.TypeName))
             .ReverseMap()
             .ForPath(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
             .ForPath(dest => dest.DestinationName, opt => opt.MapFrom(src => src.Destination.Name))
             .ForPath(dest => dest.PricingUnitName, opt => opt.MapFrom(src => src.PricingUnit.Name))
             .ForPath(dest => dest.SubscriptionName, opt => opt.MapFrom(src => src.Subscription.Name))
             .ForPath(dest => dest.TypeName, opt => opt.MapFrom(src => src.Type.Name)).ReverseMap();



        CreateMap<GetBranchDto, Branch>().ReverseMap();
        CreateMap<CreateBranchDto, Branch>().ReverseMap();
        CreateMap<CreateBranchComponentDto, BranchComponent>().ReverseMap();
        CreateMap<GetBranchComponentDto, BranchComponent>()
            .ForPath(dest => dest.Branch.Name, opt => opt.MapFrom(src => src.BranchName))
            .ForPath(dest => dest.Component.Name, opt => opt.MapFrom(src => src.ComponentName))
            .ReverseMap()
            .ForPath(dest => dest.BranchName, opt => opt.MapFrom(src => src.Branch.Name))
            .ForPath(dest => dest.ComponentName, opt => opt.MapFrom(src => src.Component.Name));


        CreateMap<AddPackageDto, Package>().ReverseMap();
        CreateMap<GetPackageDto, Package>().ReverseMap();
        CreateMap<GetPackageFacilityDto, PackageFacility>()
            .ForPath(dest => dest.Facility.Name, opt => opt.MapFrom(src => src.FacilityName))
            .ForPath(dest => dest.Package.Name, opt => opt.MapFrom(src => src.PackageName))
            .ForPath(dest => dest.Type.Name, opt => opt.MapFrom(src => src.TypeName))
            .ReverseMap()
            .ForPath(dest => dest.FacilityName, opt => opt.MapFrom(src => src.Facility.Name))
            .ForPath(dest => dest.PackageName, opt => opt.MapFrom(src => src.Package.Name))
            .ForPath(dest => dest.TypeName, opt => opt.MapFrom(src => src.Type.Name));

        CreateMap<AddPackageFacilityDto, PackageFacility>().ReverseMap();




    }
}