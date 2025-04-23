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

import { MainPageAvailablePackageComponent } from "../main-page-available-package/main-page-available-package.component";

@Component({
  selector: "app-main-page-available-packages",
  standalone: true,
  imports: [ RouterLink, RouterLinkActive,  CommonModule,MainPageAvailablePackageComponent,
    // JadaCardSystemServiceComponent, 
    CardModule, ButtonModule],
  templateUrl: "./main-page-available-packages.component.html",
  styleUrl: "./main-page-available-packages.component.scss",
  providers: [CoreService]
})
export class MainPageAvailablePackagesComponent extends BaseComponent  {

  apiurl= 'http://localhost:5000/api/Data/Endpoint2'

  @Input() data: {name: string, price: number}[]=[
    {name:"الباقة الأساسية", price:300},
    {name:"الباقة المتوسطة", price:450},
    {name:"الباقة الشاملة", price:600}
  ]


  constructor(private injector: Injector, private service: CoreService, private http: HttpClient) {
    super(injector);
  }

}
