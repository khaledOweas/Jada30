import { Component, Injector, OnInit } from "@angular/core";

import { ToastModule } from "primeng/toast";
import { BaseComponent } from "../../../Core/Components/base/base.component";
import { TranslateDirective } from "@ngx-translate/core";
import { SharedDatatableComponent } from "../../../Core/shared/shared-datatable/shared-datatable.component";
import { SharedDataTableColumn } from "../../../Core/shared/shared-datatable/sharedDatatablesModels";
import { ApplicationUser, ApplicationUserListBaseResponse, IdentityService } from "../../../Services/IdentityService";
import { takeUntil } from "rxjs";

@Component({
  selector: "app-user-list",
  standalone: true,
  imports: [ToastModule, TranslateDirective, SharedDatatableComponent],
  providers: [IdentityService],
  templateUrl: "./user-list.component.html",
  styleUrl: "./user-list.component.css"
})
export class UserListComponent extends BaseComponent implements OnInit {
  Cols!: SharedDataTableColumn[];
  Data: ApplicationUser[] | undefined;

  constructor(private injector: Injector, private service: IdentityService) {
    super(injector);

    this.Cols = [
      SharedDataTableColumn.fromJS({
        id: 1,
        sorted: true,
        filtered: true,
        hidden: true,
        field: "id",
        header: this.tr.get("SHARED.Id"),
        type: "text"
      }),
      SharedDataTableColumn.fromJS({
        id: 4,
        sorted: true,
        filtered: true,
        hidden: false,
        field: this.lang == "ar" ? "userNameAr" : "userName",
        header: this.tr.get("Users.UserName"),
        type: "text"
      }),

      SharedDataTableColumn.fromJS({
        id: 5,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "phoneNumber",
        header: this.tr.get("Users.Mobile"),
        type: "text"
      })
    ];
  }
  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers() {
    this.service
      .usersGET()
      .pipe(takeUntil(this.destroyed$))
      .subscribe({
        next: (res: ApplicationUserListBaseResponse) => {
          this.ct.sendToaster("info", "Retrieve Data ", res.message);
          this.Data = res.responseData;
        }
      });
  }
}
