import { Component, Injector, OnInit, Input } from "@angular/core";

import { Observable, takeUntil } from "rxjs";
import { BaseComponent } from "src/app/core/Components/base/base.component";
import { ApplicationRole, BooleanBaseResponse } from "src/app/services/IdentityService";
import { CoreService } from "src/app/services/CoreService";
import { RouterLink, RouterLinkActive } from "@angular/router";
import Swal from "sweetalert2";
import { ColumnManager, ListColumnType } from "src/app/data/DataTableColumnData";

import { CardModule } from 'primeng/card';
import { ButtonModule } from "primeng/button";
import { CommonModule } from "@angular/common";
import { HttpClient } from "@angular/common/http";


@Component({
  selector: "app-main-page-available-package",
  standalone: true,
  imports: [ RouterLink, RouterLinkActive,  CommonModule,
    // JadaCardSystemServiceComponent, 
    CardModule, ButtonModule],
  templateUrl: "./main-page-available-package.component.html",
  styleUrl: "./main-page-available-package.component.scss",
  providers: [CoreService]
})
export class MainPageAvailablePackageComponent extends BaseComponent  {

  apiurl= 'http://localhost:5000/api/Data/Endpoint2'

  @Input() name: string="الباقة الأساسية";
  @Input() price:number=300;
  

  constructor(private injector: Injector, private service: CoreService, private http: HttpClient) {
    super(injector);
  }

}
