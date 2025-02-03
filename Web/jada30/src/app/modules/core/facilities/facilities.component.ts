import { Component, Injector, OnInit } from "@angular/core";
import { RouterLink, RouterLinkActive } from "@angular/router";
import { TranslateDirective } from "@ngx-translate/core";
import { takeUntil } from "rxjs";
import { BaseComponent } from "src/app/core/Components/base/base.component";
import { SharedDatatableComponent } from "src/app/core/shared/shared-datatable/shared-datatable.component";
import { SharedDataTableColumn } from "src/app/core/shared/shared-datatable/sharedDatatablesModels";
import { ColumnManager, ListColumnType } from "src/app/data/DataTableColumnData";
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

    this.Cols = ColumnManager.getCol(ListColumnType.Facility);
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
