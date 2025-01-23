import { Component, Injector, OnInit } from "@angular/core";
import { TranslateDirective } from "@ngx-translate/core";

import { ActivatedRoute } from "@angular/router";

import {
  BooleanBaseResponse,
  GetLookupDto,
  GetLookupDtoListBaseResponse,
  LookupService
} from "src/app/services/LookupService";
import { SharedDataTableColumn } from "src/app/core/shared/shared-datatable/sharedDatatablesModels";
import { SharedDatatableComponent } from "src/app/core/shared/shared-datatable/shared-datatable.component";
import { BaseComponent } from "src/app/core/Components/base/base.component";
import Swal from "sweetalert2";

@Component({
  selector: "app-lookup-list",
  imports: [TranslateDirective, SharedDatatableComponent],
  providers: [LookupService],
  standalone: true,
  templateUrl: "./lookup-list.component.html",
  styleUrl: "./lookup-list.component.css"
})
export class LookupListComponent extends BaseComponent implements OnInit {
  GoToCreate() {
    this.router.navigate([this.createURL, this.code]);
  }

  Cols!: SharedDataTableColumn[];
  Data: GetLookupDto[] | undefined;
  code: string = "";
  createURL = "/lookups/lookup-create";
  updateURL = "/lookups/lookup-update";
  contentFirstBtn: string;
  contentSecondBtn: string;
  constructor(private injector: Injector, private service: LookupService, private route: ActivatedRoute) {
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
        field: this.lang == "ar" ? "nameAr" : "name",
        header: this.tr.get("Lookup.LookupName"),
        type: "text"
      })
    ];

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
  }

  ngOnInit(): void {
    this.code = this.route.snapshot.params["code"];
   this.load();
    this.route.params.subscribe((params) => {
      const newCode = params["code"];
      if (newCode !== this.code) {
        this.code = newCode;
        this.load();
      }
    });
  }
  load() {
    if (this.code === "All") {
      this.loadAllCategories();
    } else {
      this.loadAll();
    }
  }
  loadAllCategories(): void {
    this.service.getAllCategory().subscribe({
      next: (res: GetLookupDtoListBaseResponse) => {
        if (res.responseData) {
          this.Data = res.responseData;
        }
      },
      error: (err) => {
        console.error("Failed to load categories:", err);
      }
    });
  }
  loadAll() {
    this.service.getAll2(this.code).subscribe({
      next: (res: GetLookupDtoListBaseResponse) => {
        this.Data = res.responseData;
      },
      error: (err) => {
        console.error("Failed to load lookup data:", err);
      }
    });
  }

  edit(obj: any) {
    this.GoToUpdate(obj.internalCode);
  }

  GoToUpdate(miniCode: string) {
    this.router.navigate([this.updateURL, miniCode]);
  }
  delete(obj: any) {
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
          this.service.deleteLookup(obj.internalCode).subscribe({
            next: (res: BooleanBaseResponse) => {
              if (res.isSuccess) {
                this.ct.sendToaster("info", this.tr.get("SHARED.ServerDetails"), res.message);
                this.load();
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
