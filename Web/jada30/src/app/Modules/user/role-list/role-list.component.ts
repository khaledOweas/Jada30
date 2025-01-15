import { Component, Injector, OnInit } from "@angular/core";
import { ToastModule } from "primeng/toast";
import { BaseComponent } from "../../../Core/Components/base/base.component";
import { TranslateDirective } from "@ngx-translate/core";
import { SharedDatatableComponent } from "../../../Core/shared/shared-datatable/shared-datatable.component";
import { SharedDataTableColumn } from "../../../Core/shared/shared-datatable/sharedDatatablesModels";
import { ApplicationRole, ApplicationRoleListBaseResponse, IdentityService } from "../../../Services/IdentityService";

import { takeUntil } from "rxjs";
@Component({
  selector: "app-role-list",
  standalone: true,
  imports: [ToastModule, TranslateDirective, SharedDatatableComponent],
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
