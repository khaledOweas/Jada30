import { Component, Injector, OnInit } from "@angular/core";
import { RouterLink, RouterLinkActive } from "@angular/router";
import { TranslateDirective } from "@ngx-translate/core";
import { takeUntil } from "rxjs";
import { BaseComponent } from "src/app/core/Components/base/base.component";
import { SharedDatatableComponent } from "src/app/core/shared/shared-datatable/shared-datatable.component";
import { SharedDataTableColumn } from "src/app/core/shared/shared-datatable/sharedDatatablesModels";
import { CoreService, FacilityDto, FacilityDtoListBaseResponse } from "src/app/services/CoreService";

@Component({
  selector: "app-facilities",
  standalone: true,
  imports: [TranslateDirective, SharedDatatableComponent, RouterLink, RouterLinkActive],
  templateUrl: "./facilities.component.html",
  styleUrl: "./facilities.component.scss",
  providers: [CoreService]
})
export class FacilitiesComponent extends BaseComponent implements OnInit {
  Cols!: SharedDataTableColumn[];
  Data: FacilityDto[] | undefined;

  constructor(private injector: Injector, private service: CoreService) {
    super(injector);

    this.Cols = [
      SharedDataTableColumn.fromJS({
        id: 1,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "id",
        header: this.tr.get("SHARED.Id"),
        type: "text"
      }),
      SharedDataTableColumn.fromJS({
        id: 2,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "name",
        header: this.tr.get("Facility.Name"),
        type: "text"
      }),

      SharedDataTableColumn.fromJS({
        id: 3,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "categoryName",
        header: this.tr.get("Facility.CategoryId"),
        type: "text"
      }),
      SharedDataTableColumn.fromJS({
        id: 4,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "typeName",
        header: this.tr.get("Facility.TypeId"),
        type: "text"
      }),
      SharedDataTableColumn.fromJS({
        id: 5,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "destinationName",
        header: this.tr.get("Facility.DestinationId"),
        type: "text"
      }),
      SharedDataTableColumn.fromJS({
        id: 6,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "pricingUnitName",
        header: this.tr.get("Facility.PricingUnitId"),
        type: "text"
      }),
      SharedDataTableColumn.fromJS({
        id: 7,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "subscriptionName",
        header: this.tr.get("Facility.SubscriptionId"),
        type: "text"
      }),
      SharedDataTableColumn.fromJS({
        id: 8,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "basePrice",
        header: this.tr.get("Facility.BasePrice"),
        type: "text"
      }),
      SharedDataTableColumn.fromJS({
        id: 9,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "isTaxIncluded",
        header: this.tr.get("Facility.IsTaxIncluded"),
        type: "bool"
      }),
      SharedDataTableColumn.fromJS({
        id: 10,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "basicContract",
        header: this.tr.get("Facility.BasicContract"),
        type: "text"
      }),
      SharedDataTableColumn.fromJS({
        id: 11,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "isPublish",
        header: this.tr.get("Facility.IsPublish"),
        type: "bool"
      })
    ];
  }
  ngOnInit(): void {
    this.loadAll();
  }

  loadAll() {
    this.service
      .getFacilities()
      .pipe(takeUntil(this.destroyed$))
      .subscribe({
        next: (res: FacilityDtoListBaseResponse) => {
          this.ct.sendToaster("info", this.tr.get("SHARED.ServerDetails"), res.message);
          this.Data = res.responseData;
        }
      });
  }
}
