﻿using AutoMapper;
using Jada30Core.Common.Facility;
using Jada30Core.Common.Branch;
using Domain;
using Jada30Core.Common.Package;
using Jada30Core.Common.PackageFaclilty;
using Jada30Core.Common.SupportingServiceProvider;
using Jada30Core.Common.Perk;
using Jada30Core.Common.AboutJada;
using Jada30Core.Common.Event;
using Jada30Core.Common.PriceCategories;
using Jada30Core.Common.categoryAdministrativeRegion;
using Jada30Core.Common.Workspace;
using Domain.WorkSpace;


namespace Identity.Application.Mappings;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateFacilityDto, Domain.Facilities>().ReverseMap();
        CreateMap<FacilityDto, Domain.Facilities>()
             .ForPath(dest => dest.Category.Name, opt => opt.MapFrom(src => src.CategoryName))
             .ForPath(dest => dest.Category.NameAr, opt => opt.MapFrom(src => src.CategoryNameAr))
             .ForPath(dest => dest.Category.Id, opt => opt.MapFrom(src => src.CategoryId))

             .ForPath(dest => dest.Destination.Name, opt => opt.MapFrom(src => src.DestinationName))
             .ForPath(dest => dest.Destination.NameAr, opt => opt.MapFrom(src => src.DestinationNameAr))
             .ForPath(dest => dest.Destination.Id, opt => opt.MapFrom(src => src.DestinationId))

             .ForPath(dest => dest.PricingUnit.Name, opt => opt.MapFrom(src => src.PricingUnitName))
             .ForPath(dest => dest.PricingUnit.NameAr, opt => opt.MapFrom(src => src.PricingUnitNameAr))
             .ForPath(dest => dest.PricingUnit.Id, opt => opt.MapFrom(src => src.PricingUnitId))

             .ForPath(dest => dest.Subscription.Name, opt => opt.MapFrom(src => src.SubscriptionName))
             .ForPath(dest => dest.Subscription.NameAr, opt => opt.MapFrom(src => src.SubscriptionNameAr))
             .ForPath(dest => dest.Subscription.Id, opt => opt.MapFrom(src => src.SubscriptionId))

             .ForPath(dest => dest.Type.Name, opt => opt.MapFrom(src => src.TypeName))
             .ForPath(dest => dest.Type.NameAr, opt => opt.MapFrom(src => src.TypeNameAr))
             .ForPath(dest => dest.Type.Id, opt => opt.MapFrom(src => src.TypeId))

             .ReverseMap()
             .ForPath(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
             .ForPath(dest => dest.CategoryNameAr, opt => opt.MapFrom(src => src.Category.NameAr))
             .ForPath(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category.Id))

             .ForPath(dest => dest.DestinationName, opt => opt.MapFrom(src => src.Destination.Name))
             .ForPath(dest => dest.DestinationNameAr, opt => opt.MapFrom(src => src.Destination.NameAr))
             .ForPath(dest => dest.DestinationId, opt => opt.MapFrom(src => src.Destination.Id))

             .ForPath(dest => dest.PricingUnitName, opt => opt.MapFrom(src => src.PricingUnit.Name))
             .ForPath(dest => dest.PricingUnitNameAr, opt => opt.MapFrom(src => src.PricingUnit.NameAr))
             .ForPath(dest => dest.PricingUnitId, opt => opt.MapFrom(src => src.PricingUnit.Id))

             .ForPath(dest => dest.SubscriptionName, opt => opt.MapFrom(src => src.Subscription.Name))
             .ForPath(dest => dest.SubscriptionNameAr, opt => opt.MapFrom(src => src.Subscription.NameAr))
             .ForPath(dest => dest.SubscriptionId, opt => opt.MapFrom(src => src.Subscription.Id))

             .ForPath(dest => dest.TypeName, opt => opt.MapFrom(src => src.Type.Name))
             .ForPath(dest => dest.TypeNameAr, opt => opt.MapFrom(src => src.Type.NameAr))
             .ForPath(dest => dest.TypeId, opt => opt.MapFrom(src => src.Type.Id))
             ;



        CreateMap<GetBranchDto, Branch>()
           .ForPath(dest => dest.AdministrativeRegion.NameAr, opt => opt.MapFrom(src => src.AdministrativeRegionAr))
           .ForPath(dest => dest.AdministrativeRegion.Name, opt => opt.MapFrom(src => src.AdministrativeRegion))
           .ForPath(dest => dest.AdministrativeRegion.Id, opt => opt.MapFrom(src => src.AdministrativeRegionId))

           .ForPath(dest => dest.CategoryBranch.NameAr, opt => opt.MapFrom(src => src.CategoryBranchAr))
           .ForPath(dest => dest.CategoryBranch.Name, opt => opt.MapFrom(src => src.CategoryBranch))
           .ForPath(dest => dest.CategoryBranch.Id, opt => opt.MapFrom(src => src.CategoryBranchId))

           .ForPath(dest => dest.WebsiteBranch.NameAr, opt => opt.MapFrom(src => src.WebsiteBranchAr))
           .ForPath(dest => dest.WebsiteBranch.Name, opt => opt.MapFrom(src => src.WebsiteBranch))
           .ForPath(dest => dest.WebsiteBranch.Id, opt => opt.MapFrom(src => src.WebsiteBranchId))
            .ReverseMap()

           .ForPath(dest => dest.AdministrativeRegionAr, opt => opt.MapFrom(src => src.AdministrativeRegion.NameAr))
           .ForPath(dest => dest.AdministrativeRegion, opt => opt.MapFrom(src => src.AdministrativeRegion.Name))
           .ForPath(dest => dest.AdministrativeRegionId, opt => opt.MapFrom(src => src.AdministrativeRegion.Id))

           .ForPath(dest => dest.CategoryBranchAr, opt => opt.MapFrom(src => src.CategoryBranch.NameAr))
           .ForPath(dest => dest.CategoryBranch, opt => opt.MapFrom(src => src.CategoryBranch.Name))
           .ForPath(dest => dest.CategoryBranchId, opt => opt.MapFrom(src => src.CategoryBranch.Id))

           .ForPath(dest => dest.WebsiteBranchAr, opt => opt.MapFrom(src => src.WebsiteBranch.NameAr))
           .ForPath(dest => dest.WebsiteBranch, opt => opt.MapFrom(src => src.WebsiteBranch.Name))
           .ForPath(dest => dest.WebsiteBranchId, opt => opt.MapFrom(src => src.WebsiteBranch.Id));

        CreateMap<CreateBranchDto, Branch>().ReverseMap();
        CreateMap<CreateBranchComponentDto, BranchComponent>().ReverseMap();
        CreateMap<GetBranchComponentDto, BranchComponent>()
            .ForPath(dest => dest.ComponentId, opt => opt.MapFrom(src => src.Id))
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
            .ForPath(dest => dest.Facility.Id, opt => opt.MapFrom(src => src.FacilityId))
            .ForPath(dest => dest.Facility.Name, opt => opt.MapFrom(src => src.FacilityName))
            .ForPath(dest => dest.Facility.NameAr, opt => opt.MapFrom(src => src.FacilityNameAr))

            .ForPath(dest => dest.Package.Id, opt => opt.MapFrom(src => src.PackageId))
            .ForPath(dest => dest.Package.Name, opt => opt.MapFrom(src => src.PackageName))
            .ForPath(dest => dest.Package.NameAr, opt => opt.MapFrom(src => src.PackageNameAr))

            .ForPath(dest => dest.Type.Id, opt => opt.MapFrom(src => src.TypeId))
            .ForPath(dest => dest.Type.Name, opt => opt.MapFrom(src => src.TypeName))
            .ForPath(dest => dest.Type.NameAr, opt => opt.MapFrom(src => src.TypeNameAr))
            .ReverseMap()
            .ForPath(dest => dest.FacilityId, opt => opt.MapFrom(src => src.Facility.Id))
            .ForPath(dest => dest.FacilityName, opt => opt.MapFrom(src => src.Facility.Name))
            .ForPath(dest => dest.FacilityNameAr, opt => opt.MapFrom(src => src.Facility.NameAr))

            .ForPath(dest => dest.PackageId, opt => opt.MapFrom(src => src.Package.Id))
            .ForPath(dest => dest.PackageName, opt => opt.MapFrom(src => src.Package.Name))
            .ForPath(dest => dest.PackageNameAr, opt => opt.MapFrom(src => src.Package.NameAr))

            .ForPath(dest => dest.TypeId, opt => opt.MapFrom(src => src.Type.Id))
            .ForPath(dest => dest.TypeName, opt => opt.MapFrom(src => src.Type.Name))
            .ForPath(dest => dest.TypeNameAr, opt => opt.MapFrom(src => src.Type.NameAr));

        CreateMap<AddPackageFacilityDto, PackageFacility>().ReverseMap();





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

        CreateMap<CreateAboutJadaDto, Domain.AboutJada>().ReverseMap();

        CreateMap<GetEventDto, Event>().ReverseMap();
        CreateMap<CreateEventDto, Event>().ReverseMap();
        CreateMap<CreateEventMediaFileDto, MediaFile>().ReverseMap();
        CreateMap<GetEventMediaFileDto, MediaFile>()
            .ForPath(dest => dest.Event.Title, opt => opt.MapFrom(src => src.EventTitle))
            .ForPath(dest => dest.Event.TitleAr, opt => opt.MapFrom(src => src.EventTitleAr))
            .ForPath(dest => dest.Type.Name, opt => opt.MapFrom(src => src.TypeName))
            .ReverseMap()
            .ForPath(dest => dest.EventTitle, opt => opt.MapFrom(src => src.Event.Title))
            .ForPath(dest => dest.EventTitleAr, opt => opt.MapFrom(src => src.Event.TitleAr))
            .ForPath(dest => dest.TypeName, opt => opt.MapFrom(src => src.Type.Name));



        CreateMap<AddPriceCategory, PricingCategories>().ReverseMap();
        CreateMap<GetPriceCategory, PricingCategories>().ReverseMap();
        CreateMap<GetCategoryAdministrativeRegionDto, CategoryAdministrativeRegion>()
            .ForPath(dest => dest.PricingCategory.Id, opt => opt.MapFrom(src => src.PricingCategoryId))
            .ForPath(dest => dest.PricingCategory.Name, opt => opt.MapFrom(src => src.PricingCategoryName))
            .ForPath(dest => dest.PricingCategory.NameAr, opt => opt.MapFrom(src => src.PricingCategoryNameAr))

            .ForPath(dest => dest.AdministrativeRegion.Id, opt => opt.MapFrom(src => src.AdministrativeRegionId))
            .ForPath(dest => dest.AdministrativeRegion.Name, opt => opt.MapFrom(src => src.AdministrativeRegionName))
            .ForPath(dest => dest.AdministrativeRegion.NameAr, opt => opt.MapFrom(src => src.AdministrativeRegionNameAr))
            .ReverseMap()
            .ForPath(dest => dest.PricingCategoryId, opt => opt.MapFrom(src => src.PricingCategory.Id))
            .ForPath(dest => dest.PricingCategoryName, opt => opt.MapFrom(src => src.PricingCategory.Name))
            .ForPath(dest => dest.PricingCategoryNameAr, opt => opt.MapFrom(src => src.PricingCategory.NameAr))
            .ForPath(dest => dest.IsPublish, opt => opt.MapFrom(src => src.PricingCategory.IsPublish))

            .ForPath(dest => dest.AdministrativeRegionId, opt => opt.MapFrom(src => src.AdministrativeRegion.Id))
            .ForPath(dest => dest.AdministrativeRegionName, opt => opt.MapFrom(src => src.AdministrativeRegion.Name))
            .ForPath(dest => dest.AdministrativeRegionNameAr, opt => opt.MapFrom(src => src.AdministrativeRegion.NameAr));



        CreateMap<AddWorkspaceDto, Workspace>().ReverseMap();
        CreateMap<AddWorkspaceSubcategoryDto, WorkspaceSubcategory>().ReverseMap();
        CreateMap<AddWorkspacePriceCategoryDto, WorkspacePriceCategory>().ReverseMap();

        CreateMap<GetWorkspaceDto, Workspace>()
           .ForPath(dest => dest.WorkspaceCategory.Id, opt => opt.MapFrom(src => src.WorkspaceCategoryId))
           .ForPath(dest => dest.WorkspaceCategory.Name, opt => opt.MapFrom(src => src.WorkspaceCategoryName))
           .ForPath(dest => dest.WorkspaceCategory.NameAr, opt => opt.MapFrom(src => src.WorkspaceCategoryNameAr))

           .ForPath(dest => dest.WorkspaceSubcategory.Id, opt => opt.MapFrom(src => src.WorkspaceSubcategoryId))
           .ForPath(dest => dest.WorkspaceSubcategory.Name, opt => opt.MapFrom(src => src.WorkspaceSubcategoryName))
           .ForPath(dest => dest.WorkspaceSubcategory.NameAr, opt => opt.MapFrom(src => src.WorkspaceSubcategoryNameAr))
            .ReverseMap()

            .ForPath(dest => dest.WorkspaceCategoryId, opt => opt.MapFrom(src => src.WorkspaceCategory.Id))
            .ForPath(dest => dest.WorkspaceCategoryName, opt => opt.MapFrom(src => src.WorkspaceCategory.Name))
            .ForPath(dest => dest.WorkspaceCategoryNameAr, opt => opt.MapFrom(src => src.WorkspaceCategory.NameAr))

            .ForPath(dest => dest.WorkspaceSubcategoryId, opt => opt.MapFrom(src => src.WorkspaceSubcategory.Id))
            .ForPath(dest => dest.WorkspaceSubcategoryName, opt => opt.MapFrom(src => src.WorkspaceSubcategory.Name))
            .ForPath(dest => dest.WorkspaceSubcategoryNameAr, opt => opt.MapFrom(src => src.WorkspaceSubcategory.NameAr));


        CreateMap<GetWorkspaceSubcategoryDto, WorkspaceSubcategory>()
            .ForPath(dest => dest.WorkspaceCategory.Id, opt => opt.MapFrom(src => src.WorkspaceCategoryId))
           .ForPath(dest => dest.WorkspaceCategory.Name, opt => opt.MapFrom(src => src.WorkspaceCategoryName))
           .ForPath(dest => dest.WorkspaceCategory.NameAr, opt => opt.MapFrom(src => src.WorkspaceCategoryNameAr))

            .ReverseMap()
            .ForPath(dest => dest.WorkspaceCategoryId, opt => opt.MapFrom(src => src.WorkspaceCategory.Id))
            .ForPath(dest => dest.WorkspaceCategoryName, opt => opt.MapFrom(src => src.WorkspaceCategory.Name))
            .ForPath(dest => dest.WorkspaceCategoryNameAr, opt => opt.MapFrom(src => src.WorkspaceCategory.NameAr));

        CreateMap<GetWorkspacePriceCategoryDto, WorkspacePriceCategory>()
             .ForPath(dest => dest.WorkspaceSubcategory.Id, opt => opt.MapFrom(src => src.WorkspaceSubcategoryId))
           .ForPath(dest => dest.WorkspaceSubcategory.Name, opt => opt.MapFrom(src => src.WorkspaceSubcategoryName))
           .ForPath(dest => dest.WorkspaceSubcategory.NameAr, opt => opt.MapFrom(src => src.WorkspaceSubcategoryNameAr))
           .ReverseMap()
           .ForPath(dest => dest.WorkspaceSubcategoryId, opt => opt.MapFrom(src => src.WorkspaceSubcategory.Id))
            .ForPath(dest => dest.WorkspaceSubcategoryName, opt => opt.MapFrom(src => src.WorkspaceSubcategory.Name))
            .ForPath(dest => dest.WorkspaceSubcategoryNameAr, opt => opt.MapFrom(src => src.WorkspaceSubcategory.NameAr));


    }
}