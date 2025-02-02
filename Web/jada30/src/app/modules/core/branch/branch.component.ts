import { Component, Injector, OnInit } from "@angular/core";
import { TranslateDirective } from "@ngx-translate/core";
import { SharedDatatableComponent } from "../../../core/shared/shared-datatable/shared-datatable.component";

import { takeUntil } from "rxjs";
import { BaseComponent } from "src/app/core/Components/base/base.component";
import { ApplicationRole } from "src/app/services/IdentityService";
import { SharedDataTableColumn } from "src/app/core/shared/shared-datatable/sharedDatatablesModels";
import { CoreService, GetBranchDtoListBaseResponse } from "src/app/services/CoreService";
import { RouterLink, RouterLinkActive } from "@angular/router";
@Component({
  selector: "app-branch",
  standalone: true,
  imports: [TranslateDirective, SharedDatatableComponent, RouterLink, RouterLinkActive],
  templateUrl: "./branch.component.html",
  styleUrl: "./branch.component.scss",
  providers: [CoreService]
})
export class BranchComponent extends BaseComponent implements OnInit {
  Cols!: SharedDataTableColumn[];
  Data: ApplicationRole[] | undefined;

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
        header: this.tr.get("Branches.Name"),
        type: "text"
      }),

      SharedDataTableColumn.fromJS({
        id: 3,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "websiteBranchId",
        header: this.tr.get("Branches.WebsiteBranchId"),
        type: "text"
      }),

      SharedDataTableColumn.fromJS({
        id: 4,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "workingDays",
        header: this.tr.get("Branches.WorkingDays"),
        type: "text"
      }),

      SharedDataTableColumn.fromJS({
        id: 5,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "startTime",
        header: this.tr.get("Branches.StartTime"),
        type: "datetime"
      }),

      SharedDataTableColumn.fromJS({
        id: 6,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "endTime",
        header: this.tr.get("Branches.EndTime"),
        type: "datetime"
      }),

      SharedDataTableColumn.fromJS({
        id: 7,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "categoryBranchId",
        header: this.tr.get("Branches.CategoryBranchId"),
        type: "text"
      })
    ];
  }
  ngOnInit(): void {
    this.loadAll();
  }

  loadAll() {
    this.service
      .branchGET()
      .pipe(takeUntil(this.destroyed$))
      .subscribe({
        next: (res: GetBranchDtoListBaseResponse) => {
          this.ct.sendToaster("info", this.tr.get("SHARED.ServerDetails"), res.message);
          this.Data = res.responseData;
        }
      });
  }
}
