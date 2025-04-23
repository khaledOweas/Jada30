import { Component, Injector, Input, OnInit } from "@angular/core";

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

import { MainPagePackageComponent } from "../main-page-package/main-page-package.component";

@Component({
  selector: "app-main-page-packages",
  standalone: true,
  imports: [RouterLink, RouterLinkActive, CommonModule,
    MainPagePackageComponent,

    // JadaCardSystemServiceComponent, 
    CardModule, ButtonModule],
  templateUrl: "./main-page-packages.component.html",
  styleUrl: "./main-page-packages.component.scss",
  providers: [CoreService]
})
export class MainPagePackagesComponent extends BaseComponent {
  isDetailsVisible: boolean = false;
  apiurl = 'http://localhost:5000/api/Data/Endpoint2'

  // @Input() name: string = "باقة أسُس";
  //   @Input() cityOptions: { cityName: string, price: number }[] =
  //     [{ cityName: "فرع الرياض", price: 340 },
  //     { cityName: "فرع جدة", price: 550 },
  //     { cityName: "فرع الدمام", price: 250 }];
  @Input() packages: { name: string, cityOptions: { cityName: string, price: number }[] }[] =
    [{
      name: "باقة أسُس",
      cityOptions: [
        { cityName: "فرع الرياض", price: 340 },
        { cityName: "فرع جدة", price: 550 },
        { cityName: "فرع الدمام", price: 250 }]
    },
    {
      name: "باقة فكرة",
      cityOptions: [
        { cityName: "فرع المدينة", price: 200 },
        { cityName: "فرع مكة", price: 300 },
        { cityName: "فرع الطائف", price: 200 }]
    },
    {
      name: "الباقة الأساسية",
      cityOptions: [
        { cityName: "فرع الرياض", price: 340 },
        { cityName: "فرع جدة", price: 550 },
        { cityName: "فرع الدمام", price: 250 }]
    }];

  constructor(private injector: Injector, private service: CoreService, private http: HttpClient) {
    super(injector);
  }

  toggleDetails() {
    this.isDetailsVisible = !this.isDetailsVisible;
  }


}
