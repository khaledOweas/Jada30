import { HttpClient } from "@angular/common/http";
import { Component, Injector, OnInit } from "@angular/core";
import { RouterLink, RouterLinkActive } from "@angular/router";
import { TranslateDirective } from "@ngx-translate/core";
import { Observable, takeUntil } from "rxjs";
import { BaseComponent } from "src/app/core/Components/base/base.component";
import { SharedDatatableComponent } from "src/app/core/shared/shared-datatable/shared-datatable.component";
import { SharedDataTableColumn } from "src/app/core/shared/shared-datatable/sharedDatatablesModels";
import { ColumnManager, ListColumnType } from "src/app/data/DataTableColumnData";
import { CardModule } from 'primeng/card';
import { CommonModule } from "@angular/common";


import {
  BooleanBaseResponse,
  CoreService,
  FacilityDto,
  FacilityDtoListBaseResponse,
} from "src/app/services/CoreService";
import Swal from "sweetalert2";

@Component({
  selector: "app-facilities",
  standalone: true,
  imports: [TranslateDirective, SharedDatatableComponent, RouterLink, RouterLinkActive,CommonModule, CardModule],
  templateUrl: "./facilities.component.html",
  styleUrl: "./facilities.component.scss",
  providers: [CoreService]
})
export class FacilitiesComponent extends BaseComponent implements OnInit {
  Cols!: SharedDataTableColumn[];
  Data: FacilityDto[] | undefined;
  
  apiurl= 'http://localhost:5000/api/Data/Endpoint6'


  constructor(private injector: Injector, private service: CoreService,  private http: HttpClient) {
    super(injector);

    this.Cols = ColumnManager.getCol(ListColumnType.Facility);
  }
  getData(): Observable<any>{
        return this.http.get(this.apiurl);
      }
  ngOnInit(): void {
   // this.loadAll();
   this.getData().subscribe({next:(res ) => {
    this.Data = res;
}});
  }

  loadAll() {
    this.service
      .getFacilities()
      .pipe(takeUntil(this.destroyed$))
      .subscribe({
        next: (res: FacilityDtoListBaseResponse) => {
          this.Data = res.responseData;
        }
      });
  }

  edit(id: number) {
    this.router.navigate(["/facility/facility-update/", id]);
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
          this.service.facility(id).subscribe({
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
