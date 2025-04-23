import { Component, Injector, OnInit } from "@angular/core";

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

import { MainPageImageComponent } from "../main-page-image/main-page-image.component";
import { MainPageWorkspacesComponent } from "../main-page-workspaces/main-page-workspaces.component";
import { MainPagePackagesComponent } from "../main-page-packages/main-page-packages.component";
import { MainPageAvailablePackagesComponent } from "../main-page-available-packages/main-page-available-packages.component";
@Component({
  selector: "app-main-page",
  standalone: true,
  imports: [ RouterLink, RouterLinkActive,  CommonModule,
    MainPageImageComponent,MainPageWorkspacesComponent,MainPagePackagesComponent,MainPageAvailablePackagesComponent,
    // JadaCardSystemServiceComponent, 
    CardModule, ButtonModule],
  templateUrl: "./main-page.component.html",
  styleUrl: "./main-page.component.scss",
  providers: [CoreService]
})
export class MainPageComponent extends BaseComponent  {

  apiurl= 'http://localhost:5000/api/Data/Endpoint2'


  constructor(private injector: Injector, private service: CoreService, private http: HttpClient) {
    super(injector);
  }

}
