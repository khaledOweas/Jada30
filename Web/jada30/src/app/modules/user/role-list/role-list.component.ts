import { Component, Injector, OnInit } from "@angular/core";
import { TranslateDirective } from "@ngx-translate/core";
import { SharedDatatableComponent } from "../../../core/shared/shared-datatable/shared-datatable.component";

import { takeUntil } from "rxjs";
import { BaseComponent } from "src/app/core/Components/base/base.component";
import { ApplicationRole, ApplicationRoleListBaseResponse, IdentityService } from "src/app/services/IdentityService";
import { SharedDataTableColumn } from "src/app/core/shared/shared-datatable/sharedDatatablesModels";
@Component({
  selector: "app-role-list",
  standalone: true,
  imports: [TranslateDirective, SharedDatatableComponent],
  providers: [IdentityService],
  templateUrl: "./role-list.component.html",
  styleUrl: "./role-list.component.css"
})
export class RoleListComponent extends BaseComponent implements OnInit {
  Cols!: SharedDataTableColumn[];
  Data: ApplicationRole[] | undefined;

  constructor(private injector: Injector, private service: IdentityService) {
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
        id: 4,
        sorted: true,
        filtered: true,
        hidden: false,
        field: this.lang == "ar" ? "roleNameAr" : "name",
        header: this.tr.get("Roles.RoleName"),
        type: "text"
      })
    ];
  }
  ngOnInit(): void {
    this.loadAll();
  }

  loadAll() {
    this.service
      .rolesGET()
      .pipe(takeUntil(this.destroyed$))
      .subscribe({
        next: (res: ApplicationRoleListBaseResponse) => {
          this.ct.sendToaster("info", this.tr.get("SHARED.ServerDetails"), res.message);
          this.Data = res.responseData;
        }
      });
  }
}
