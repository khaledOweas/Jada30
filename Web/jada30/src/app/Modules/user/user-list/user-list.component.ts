import { Component, Injector, OnInit } from "@angular/core";
import { ToastModule } from "primeng/toast";
import { BaseComponent } from "../../../Core/Components/base/base.component";
import { TranslateDirective } from "@ngx-translate/core";
import { SharedDatatableComponent } from "../../../Core/shared/shared-datatable/shared-datatable.component";
import { SharedDataTableColumn } from "../../../Core/shared/shared-datatable/sharedDatatablesModels";
import { IdentityService, UserDto, UserDtoListBaseResponse } from "../../../Services/IdentityService";
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
  Data: UserDto[] | undefined;

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
        field: this.lang == "ar" ? "userNameAr" : "userName",
        header: this.tr.get("Users.UserName"),
        type: "text"
      }),

      SharedDataTableColumn.fromJS({
        id: 5,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "email",
        header: this.tr.get("Users.Email"),
        type: "text"
      }),
      SharedDataTableColumn.fromJS({
        id: 5,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "roles",
        header: this.tr.get("Roles.Roles"),
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
        next: (res: UserDtoListBaseResponse) => {
          this.ct.sendToaster("info", this.tr.get("SHARED.ServerDetails"), res.message);
          this.Data = res.responseData;
        }
      });
  }
}
