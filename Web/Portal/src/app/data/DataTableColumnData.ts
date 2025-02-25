import { SharedDataTableColumn } from "src/app/core/shared/shared-datatable/sharedDatatablesModels";
import { TranslationService } from "../core/services/translation.service";

export enum ListColumnType {
  Branch = "branch",
  User = "user",
  Facility = "Facility",
  Lookup = "Lookup",
  Package = "Package",
  PricingCategory = "PricingCategory"
}

export class ColumnManager {
  private static tr: TranslationService | null = null;

  public static setTranslationService(translationService: TranslationService): void {
    ColumnManager.tr! = translationService;
  }

  public static getCol(type: ListColumnType): SharedDataTableColumn[] {
    switch (type) {
      case ListColumnType.Branch:
        return this.getBranchColumns();
      case ListColumnType.User:
        return this.getUserColumns();
      case ListColumnType.Facility:
        return this.getFacilityColumns();
      case ListColumnType.Lookup:
        return this.getLookupColumns();
      case ListColumnType.Package:
        return this.getPackageColumns();
      case ListColumnType.PricingCategory:
        return this.getPricingCategoryColumns();
      default:
        return [];
    }
  }
  private static perLang(arKey: string, enKey: string): string {
    return ColumnManager.tr!.getSelectedLanguage() == "ar" ? arKey : enKey;
  }
  private static getBranchColumns(): SharedDataTableColumn[] {
    return [
      SharedDataTableColumn.fromJS({
        id: 1,
        sorted: true,
        filtered: true,
        hidden: true,
        field: "id",
        header: ColumnManager.tr!.get("SHARED.Id"),
        type: "text"
      }),
      SharedDataTableColumn.fromJS({
        id: 2,
        sorted: true,
        filtered: true,
        hidden: false,
        field: this.perLang("nameAr", "name"),
        header: ColumnManager.tr!.get("Branches.Name"),
        type: "text"
      }),

      SharedDataTableColumn.fromJS({
        id: 3,
        sorted: true,
        filtered: true,
        hidden: false,
        field: this.perLang("websiteBranchAr", "websiteBranch"),
        header: ColumnManager.tr!.get("Branches.WebsiteBranchId"),
        type: "text"
      }),

      SharedDataTableColumn.fromJS({
        id: 4,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "workingDays",
        header: ColumnManager.tr!.get("Branches.WorkingDays"),
        type: "text"
      }),

      SharedDataTableColumn.fromJS({
        id: 5,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "startTime",
        header: ColumnManager.tr!.get("Branches.StartTime"),
        type: "datetime"
      }),

      SharedDataTableColumn.fromJS({
        id: 6,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "endTime",
        header: ColumnManager.tr!.get("Branches.EndTime"),
        type: "datetime"
      }),

      SharedDataTableColumn.fromJS({
        id: 7,
        sorted: true,
        filtered: true,
        hidden: false,
        field: this.perLang("categoryBranchAr", "categoryBranch"),
        header: ColumnManager.tr!.get("Branches.CategoryBranchId"),
        type: "text"
      }),
      SharedDataTableColumn.fromJS({
        id: 8,
        sorted: true,
        filtered: true,
        hidden: false,
        field: this.perLang("administrativeRegionAr", "administrativeRegion"),
        header: ColumnManager.tr!.get("Branches.AdministrativeRegionId"),
        type: "text"
      })
    ];
  }

  private static getUserColumns(): SharedDataTableColumn[] {
    return [
      SharedDataTableColumn.fromJS({
        id: 1,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "id",
        header: ColumnManager.tr!.get("SHARED.Id"),
        type: "text"
      }),
      SharedDataTableColumn.fromJS({
        id: 4,
        sorted: true,
        filtered: true,
        hidden: false,
        field: this.perLang("userNameAr", "userName"),
        header: ColumnManager.tr!.get("Users.UserName"),
        type: "text"
      }),

      SharedDataTableColumn.fromJS({
        id: 5,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "email",
        header: ColumnManager.tr!.get("Users.Email"),
        type: "text"
      }),
      SharedDataTableColumn.fromJS({
        id: 5,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "roles",
        header: ColumnManager.tr!.get("Roles.Roles"),
        type: "roles"
      })
    ];
  }

  private static getFacilityColumns(): SharedDataTableColumn[] {
    return [
      SharedDataTableColumn.fromJS({
        id: 1,
        sorted: true,
        filtered: true,
        hidden: true,
        field: "id",
        header: ColumnManager.tr!.get("SHARED.Id"),
        type: "text"
      }),
      SharedDataTableColumn.fromJS({
        id: 2,
        sorted: true,
        filtered: true,
        hidden: false,
        field: this.perLang("nameAr", "name"),
        header: ColumnManager.tr!.get("Facility.Name"),
        type: "text"
      }),

      SharedDataTableColumn.fromJS({
        id: 3,
        sorted: true,
        filtered: true,
        hidden: false,
        field: this.perLang("categoryNameAr", "categoryName"),
        header: ColumnManager.tr!.get("Facility.CategoryId"),
        type: "text"
      }),
      SharedDataTableColumn.fromJS({
        id: 4,
        sorted: true,
        filtered: true,
        hidden: false,
        field: this.perLang("typeNameAr", "typeName"),
        header: ColumnManager.tr!.get("Facility.TypeId"),
        type: "text"
      }),
      SharedDataTableColumn.fromJS({
        id: 5,
        sorted: true,
        filtered: true,
        hidden: false,
        field: this.perLang("destinationNameAr", "destinationName"),
        header: ColumnManager.tr!.get("Facility.DestinationId"),
        type: "text"
      }),
      SharedDataTableColumn.fromJS({
        id: 6,
        sorted: true,
        filtered: true,
        hidden: false,
        field: this.perLang("pricingUnitNameAr", "pricingUnitName"),
        header: ColumnManager.tr!.get("Facility.PricingUnitId"),
        type: "text"
      }),
      SharedDataTableColumn.fromJS({
        id: 7,
        sorted: true,
        filtered: true,
        hidden: false,
        field: this.perLang("subscriptionNameAr", "subscriptionName"),
        header: ColumnManager.tr!.get("Facility.SubscriptionId"),
        type: "text"
      }),
      SharedDataTableColumn.fromJS({
        id: 8,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "basePrice",
        header: ColumnManager.tr!.get("Facility.BasePrice"),
        type: "text"
      }),
      SharedDataTableColumn.fromJS({
        id: 9,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "isTaxIncluded",
        header: ColumnManager.tr!.get("Facility.IsTaxIncluded"),
        type: "bool"
      }),
      SharedDataTableColumn.fromJS({
        id: 10,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "basicContract",
        header: ColumnManager.tr!.get("Facility.BasicContract"),
        type: "text"
      }),
      SharedDataTableColumn.fromJS({
        id: 11,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "isPublish",
        header: ColumnManager.tr!.get("Facility.IsPublish"),
        type: "bool"
      })
    ];
  }

  private static getLookupColumns(): SharedDataTableColumn[] {
    return [
      SharedDataTableColumn.fromJS({
        id: 1,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "id",
        header: ColumnManager.tr!.get("SHARED.Id"),
        type: "text"
      }),
      SharedDataTableColumn.fromJS({
        id: 4,
        sorted: true,
        filtered: true,
        hidden: false,
        field: ColumnManager.tr!.getSelectedLanguage() == "ar" ? "nameAr" : "name",
        header: ColumnManager.tr!.get("Lookup.LookupName"),
        type: "text"
      })
    ];
  }

  private static getPackageColumns(): SharedDataTableColumn[] {
    return [
      SharedDataTableColumn.fromJS({
        id: 1,
        sorted: true,
        filtered: true,
        hidden: true,
        field: "id",
        header: ColumnManager.tr!.get("SHARED.Id"),
        type: "text"
      }),
      SharedDataTableColumn.fromJS({
        id: 2,
        sorted: true,
        filtered: true,
        hidden: false,
        field: ColumnManager.tr!.getSelectedLanguage() == "ar" ? "nameAr" : "name",
        header: ColumnManager.tr!.get("Packages.Name"),
        type: "text"
      }),
      SharedDataTableColumn.fromJS({
        id: 2,
        sorted: true,
        filtered: true,
        hidden: false,
        field: ColumnManager.tr!.getSelectedLanguage() == "ar" ? "descriptionAr" : "description",
        header: ColumnManager.tr!.get("Packages.Description"),
        type: "text"
      }),
      SharedDataTableColumn.fromJS({
        id: 2,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "defaultDiscount",
        header: ColumnManager.tr!.get("Packages.DefaultDiscount"),
        type: "text"
      }),
      SharedDataTableColumn.fromJS({
        id: 2,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "writtenServices",
        header: ColumnManager.tr!.get("Packages.WrittenServices"),
        type: "text"
      }),
      SharedDataTableColumn.fromJS({
        id: 2,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "maxBranchUsers",
        header: ColumnManager.tr!.get("Packages.MaxBranchUsers"),
        type: "text"
      }),
      SharedDataTableColumn.fromJS({
        id: 2,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "maxMogdiPlatformUsage",
        header: ColumnManager.tr!.get("Packages.MaxMogdiPlatformUsage"),
        type: "text"
      })
    ];
  }
  private static getPricingCategoryColumns(): SharedDataTableColumn[] {
    return [
      SharedDataTableColumn.fromJS({
        id: 1,
        sorted: true,
        filtered: true,
        hidden: true,
        field: "id",
        header: ColumnManager.tr!.get("SHARED.Id"),
        type: "text"
      }),
      SharedDataTableColumn.fromJS({
        id: 2,
        sorted: true,
        filtered: true,
        hidden: false,
        field: ColumnManager.tr!.getSelectedLanguage() == "ar" ? "nameAr" : "name",
        header: ColumnManager.tr!.get("PricingCategory.Name"),
        type: "text"
      }),
      SharedDataTableColumn.fromJS({
        id: 2,
        sorted: true,
        filtered: true,
        hidden: false,
        field: ColumnManager.tr!.getSelectedLanguage() == "ar" ? "descriptionAr" : "description",
        header: ColumnManager.tr!.get("PricingCategory.Description"),
        type: "text"
      }),
      SharedDataTableColumn.fromJS({
        id: 2,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "price",
        header: ColumnManager.tr!.get("PricingCategory.Price"),
        type: "text"
      }),
    ];
  }
}
