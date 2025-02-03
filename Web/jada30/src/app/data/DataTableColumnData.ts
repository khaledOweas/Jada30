import { SharedDataTableColumn } from "src/app/core/shared/shared-datatable/sharedDatatablesModels";
import { TranslationService } from "../core/services/translation.service";

export enum ListColumnType {
  Branch = "branch",
  User = "user",
  Facility = "Facility",
  Lookup = "Lookup"
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
      default:
        return [];
    }
  }

  private static getBranchColumns(): SharedDataTableColumn[] {
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
        id: 2,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "name",
        header: ColumnManager.tr!.get("Branches.Name"),
        type: "text"
      }),

      SharedDataTableColumn.fromJS({
        id: 3,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "websiteBranchId",
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
        field: "categoryBranchId",
        header: ColumnManager.tr!.get("Branches.CategoryBranchId"),
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
        field: ColumnManager.tr!.getSelectedLanguage() == "ar" ? "userNameAr" : "userName",
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
        hidden: false,
        field: "id",
        header: ColumnManager.tr!.get("SHARED.Id"),
        type: "text"
      }),
      SharedDataTableColumn.fromJS({
        id: 2,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "name",
        header: ColumnManager.tr!.get("Facility.Name"),
        type: "text"
      }),

      SharedDataTableColumn.fromJS({
        id: 3,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "categoryName",
        header: ColumnManager.tr!.get("Facility.CategoryId"),
        type: "text"
      }),
      SharedDataTableColumn.fromJS({
        id: 4,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "typeName",
        header: ColumnManager.tr!.get("Facility.TypeId"),
        type: "text"
      }),
      SharedDataTableColumn.fromJS({
        id: 5,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "destinationName",
        header: ColumnManager.tr!.get("Facility.DestinationId"),
        type: "text"
      }),
      SharedDataTableColumn.fromJS({
        id: 6,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "pricingUnitName",
        header: ColumnManager.tr!.get("Facility.PricingUnitId"),
        type: "text"
      }),
      SharedDataTableColumn.fromJS({
        id: 7,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "subscriptionName",
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
}
