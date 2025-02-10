import { Component, Injector, OnInit } from "@angular/core";
import { TranslateDirective } from "@ngx-translate/core";
import { SharedDatatableComponent } from "../../../../core/shared/shared-datatable/shared-datatable.component";
import { takeUntil } from "rxjs";
import { BaseComponent } from "src/app/core/Components/base/base.component";
import { ApplicationRole, BooleanBaseResponse } from "src/app/services/IdentityService";
import { SharedDataTableColumn } from "src/app/core/shared/shared-datatable/sharedDatatablesModels";
import { CoreService, GetPriceCategoryListBaseResponse } from "src/app/services/CoreService";
import { RouterLink, RouterLinkActive } from "@angular/router";
import Swal from "sweetalert2";
import { ColumnManager, ListColumnType } from "src/app/data/DataTableColumnData";

@Component({
  selector: "app-pricing-categories-list",
  standalone: true,
  imports: [TranslateDirective, SharedDatatableComponent, RouterLink, RouterLinkActive],
  templateUrl: "./pricing-categories-list.component.html",
  styleUrl: "./pricing-categories-list.component.scss",
  providers: [CoreService]
})
export class PricingCategoriesListComponent extends BaseComponent implements OnInit {
  Cols!: SharedDataTableColumn[];
  Data: ApplicationRole[] | undefined;

  constructor(private injector: Injector, private service: CoreService) {
    super(injector);
    this.Cols = ColumnManager.getCol(ListColumnType.PricingCategory);
  }
  ngOnInit(): void {
    this.loadAll();
  }

  loadAll() {
    this.service
      .getPriceCategories()
      .pipe(takeUntil(this.destroyed$))
      .subscribe({
        next: (res: GetPriceCategoryListBaseResponse) => {
          this.Data = res.responseData;
        }
      });
  }

  edit(id: number) {
    this.router.navigate(["/pricing-category/pricing-category-update/", id]);
  }
  delete(id: number) {
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
          this.service.deletePriceCategory(id).subscribe({
            next: (res: BooleanBaseResponse) => {
              if (res.isSuccess) {
                this.loadAll();
                if (res.message) {
                  this.ct.sendToaster("info", this.tr.get("SHARED.ServerDetails"), res.message);
                }
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
