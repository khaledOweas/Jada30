import { Component, Injector, OnInit } from "@angular/core";
import { TranslateDirective } from "@ngx-translate/core";
// import { SharedDatatableComponent } from "../../../../core/shared/shared-datatable/shared-datatable.component";

import { Observable, takeUntil } from "rxjs";
import { BaseComponent } from "src/app/core/Components/base/base.component";
import { ApplicationRole, BooleanBaseResponse } from "src/app/services/IdentityService";
import { SharedDataTableColumn } from "src/app/core/shared/shared-datatable/sharedDatatablesModels";
import { CoreService, GetEventDto, GetEventDtoListBaseResponse } from "src/app/services/CoreService";
// import { RouterLink, RouterLinkActive } from "@angular/router";
import Swal from "sweetalert2";
import { ColumnManager, ListColumnType } from "src/app/data/DataTableColumnData";

// import { JadaCardDataComponent } from "src/app/core/Components/jada-card-data/jada-card-data.component";
import { CardModule } from 'primeng/card';
import { ButtonModule } from "primeng/button";
import { DataViewModule } from 'primeng/dataview';
import { SelectButtonModule } from 'primeng/selectbutton';
import { TagModule } from 'primeng/tag';
import { CommonModule } from "@angular/common";
import { signal } from '@angular/core';
import { FormsModule } from '@angular/forms'; // Import FormsModule
import { HttpClient } from "@angular/common/http";




@Component({
  selector: "app-event",
  standalone: true,
  imports: [ TranslateDirective, CommonModule, 
    CardModule, ButtonModule, DataViewModule, SelectButtonModule, TagModule, FormsModule],
  templateUrl: "./event.component.html",
  styleUrl: "./event.component.scss",
  providers: [CoreService]
})
export class EventComponent extends BaseComponent implements OnInit {
  Cols!: SharedDataTableColumn[];
  Data: any;
  DataEvents: GetEventDto[] | undefined;
  isLoading = true;
  // products = signal<any>([]);
  // layout: string = 'grid';
  // options = ['list', 'grid'];

  apiurl= 'http://localhost:5000/api/Data/Endpoint5'


  products = [
    { id: 1, name: 'Product 1', price: 100 },
    { id: 2, name: 'Product 2', price: 200 },
    // Add more products
  ];

  layout: 'list' | 'grid' = 'list'; // Default layout
  options = ['list', 'grid'];






  constructor(private injector: Injector, private service: CoreService,  private http: HttpClient) {
    super(injector);
    this.Cols = ColumnManager.getCol(ListColumnType.Event);
  }
  getData(): Observable<any>{
      return this.http.get(this.apiurl);
    }
  ngOnInit(): void {
    // this.loadAll();
    this.getData().subscribe({next:(res ) => {
      this.DataEvents = res;
  }});
  }

  loadAll() {
    this.service
      .eventGET()
      .pipe(takeUntil(this.destroyed$))
      .subscribe({
        next: (res: GetEventDtoListBaseResponse) => {
          this.Data = res.responseData;
          this.DataEvents= this.Data;
          console.log("this.Data: "+ JSON.stringify(this.DataEvents))
          this.isLoading = false;
        }
      });
  }

  details(id: number) {
    console.log("Id: "+id)
    this.router.navigate(["/event/event-details/", id]);
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
