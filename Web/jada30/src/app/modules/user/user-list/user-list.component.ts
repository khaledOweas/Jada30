import { Component, OnInit, Injector } from "@angular/core";
import { RouterLink, RouterLinkActive } from "@angular/router";
import { TranslateDirective } from "@ngx-translate/core";
import { ToastModule } from "primeng/toast";
import { takeUntil } from "rxjs";
import { BaseComponent } from "src/app/core/Components/base/base.component";
import { SharedDatatableComponent } from "src/app/core/shared/shared-datatable/shared-datatable.component";
import { SharedDataTableColumn } from "src/app/core/shared/shared-datatable/sharedDatatablesModels";
import { IdentityService, UserDto, UserDtoListBaseResponse } from "src/app/services/IdentityService";
import { BooleanBaseResponse } from "src/app/services/LookupService";
import Swal from "sweetalert2";

@Component({
  selector: "app-user-list",
  standalone: true,
  imports: [ToastModule, RouterLink, RouterLinkActive, TranslateDirective, SharedDatatableComponent],
  providers: [IdentityService],
  templateUrl: "./user-list.component.html",
  styleUrl: "./user-list.component.css"
})
export class UserListComponent extends BaseComponent implements OnInit {
  Cols!: SharedDataTableColumn[];
  Data: UserDto[] | undefined;
  contentFirstBtn: string;
  contentSecondBtn: string;

  constructor(private injector: Injector, private service: IdentityService) {
    super(injector);
    this.contentFirstBtn =
      this.lang === "ar"
        ? `<i class="ki-duotone ki-tablet-delete">
 <span class="path1"></span>
 <span class="path2"></span>
 <span class="path3"></span>
</i> تعديل`
        : `<i class="ki-duotone ki-tablet-delete ">
 <span class="path1"></span>
 <span class="path2"></span>
 <span class="path3"></span>
</i> Edit`;

    this.contentSecondBtn =
      this.lang === "ar"
        ? `<i class="ki-duotone ki-tablet-delete">
 <span class="path1"></span>
 <span class="path2"></span>
 <span class="path3"></span>
</i> حذف`
        : `<i class="ki-duotone ki-tablet-delete ">
 <span class="path1"></span>
 <span class="path2"></span>
 <span class="path3"></span>
</i> Delete`;

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
        type: "roles"
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

  editUser(id: number) {
    this.router.navigate(["/user/user-update/", id]);
  }
  deleteUser(id: number) {
    Swal.fire({
      title: this.tr.get("DELETE_CONFIRMATION.TITLE"),
      text: this.tr.get("DELETE_CONFIRMATION.TEXT"),
      icon: "warning",
      showCancelButton: true,
      confirmButtonColor: "#3085d6",
      cancelButtonColor: "#d33",
      confirmButtonText: this.tr.get("SHARED.Delete"),
      cancelButtonText: this.tr.get("SHARED.Cancel")
    }).then((result) => {
      if (result.isConfirmed) {
        try {
          this.service.usersDELETE(id).subscribe({
            next: (res: BooleanBaseResponse) => {
              if (res.isSuccess) {
                this.ct.sendToaster("info", this.tr.get("SHARED.ServerDetails"), res.message);
              } else {
                res.errors!.forEach((element) => {
                  this.ct.sendToaster("error", this.tr.get("SHARED.ServerDetails"), res.message! + element.value!);
                });
              }
            },
            error: (error) => {
              Swal.showValidationMessage(`Request failed: ${error}`);
            }
          });
        } catch (error) {
          Swal.showValidationMessage(`Request failed: ${error}`);
        }
      }
      return;
    });
  }
}
