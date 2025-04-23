import { Component, Injector, Input, input, OnInit } from "@angular/core";

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
  selector: "app-main-page-package",
  standalone: true,
  imports: [RouterLink, RouterLinkActive, CommonModule,

    // JadaCardSystemServiceComponent, 
    CardModule, ButtonModule],
  templateUrl: "./main-page-package.component.html",
  styleUrl: "./main-page-package.component.scss",
  providers: [CoreService]
})
export class MainPagePackageComponent extends BaseComponent {
  @Input() name: string = "باقة أسُس";
  @Input() cityOptions: { cityName: string, price: number }[] ;
    // [{ cityName: "فرع الرياض", price: 340 },
    // { cityName: "فرع جدة", price: 550 },
    // { cityName: "فرع الدمام", price: 250 }];

  isDetailsVisible: boolean = false;
  apiurl = 'http://localhost:5000/api/Data/Endpoint2'


  constructor(private injector: Injector, private service: CoreService, private http: HttpClient) {
    super(injector);
  }

  toggleDetails() {
    this.isDetailsVisible = !this.isDetailsVisible;
  }


}
