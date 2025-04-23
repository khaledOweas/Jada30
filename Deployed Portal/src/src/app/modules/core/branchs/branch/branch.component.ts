import { Component, Injector, OnInit } from "@angular/core";
import { TranslateDirective } from "@ngx-translate/core";
import { SharedDatatableComponent } from "../../../../core/shared/shared-datatable/shared-datatable.component";

import { Observable, takeUntil } from "rxjs";
import { BaseComponent } from "src/app/core/Components/base/base.component";
import { ApplicationRole, BooleanBaseResponse } from "src/app/services/IdentityService";
import { SharedDataTableColumn } from "src/app/core/shared/shared-datatable/sharedDatatablesModels";
import { CoreService, GetBranchDto, GetBranchDtoListBaseResponse } from "src/app/services/CoreService";
import { RouterLink, RouterLinkActive } from "@angular/router";
import Swal from "sweetalert2";
import { ColumnManager, ListColumnType } from "src/app/data/DataTableColumnData";

import { JadaCardDataComponent } from "src/app/core/Components/jada-card-data/jada-card-data.component";
import { CardModule } from 'primeng/card';
import { ButtonModule } from "primeng/button";
import { CommonModule } from "@angular/common";
import { JadaCardSystemServiceComponent } from "src/app/core/Components/Jada-card-system-service/Jada-card-system-service.component";
import { HttpClient } from "@angular/common/http";

@Component({
  selector: "app-branch",
  standalone: true,
  imports: [ JadaCardSystemServiceComponent, TranslateDirective, SharedDatatableComponent, RouterLink, RouterLinkActive, JadaCardDataComponent, CommonModule,
    // JadaCardSystemServiceComponent, 
    CardModule, ButtonModule],
  templateUrl: "./branch.component.html",
  styleUrl: "./branch.component.scss",
  providers: [CoreService]
})
export class BranchComponent extends BaseComponent implements OnInit {
  Cols!: SharedDataTableColumn[];
  Data: ApplicationRole[] | undefined;
  DataBranches: GetBranchDto[] | undefined;

  apiurl= 'http://localhost:5000/api/Data/Endpoint2'


  constructor(private injector: Injector, private service: CoreService, private http: HttpClient) {
    super(injector);
    this.Cols = ColumnManager.getCol(ListColumnType.Branch);
  }
  getData(): Observable<any>{
    return this.http.get(this.apiurl);
  }
  ngOnInit(): void {
    // this.loadAll();
    this.getData().subscribe({next:(res ) => {
        this.DataBranches = res;
    }});
  }

  loadAll() {
    this.service
      .branchGET()
      .pipe(takeUntil(this.destroyed$))
      .subscribe({
        next: (res: GetBranchDtoListBaseResponse) => {
          this.Data = res.responseData;
          this.DataBranches= this.Data;
        }
      });
  }

  details(id: number) {
    this.router.navigate(["/branch/branch-details/", id]);
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
          this.service.branchDELETE(id).subscribe({
            next: (res: BooleanBaseResponse) => {
              if (res.isSuccess) {
                this.loadAll();
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
