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
  selector: "app-main-page-workspace",
  standalone: true,
  imports: [ RouterLink, RouterLinkActive,  CommonModule,
    // JadaCardSystemServiceComponent, 
    CardModule, ButtonModule],
  templateUrl: "./main-page-workspace.component.html",
  styleUrl: "./main-page-workspace.component.scss",
  providers: [CoreService]
})
export class MainPageWorkspaceComponent extends BaseComponent  {

  apiurl= 'http://localhost:5000/api/Data/Endpoint2'

  @Input() name:string= "الخطوة الأساسية";
  @Input() details:string= "هذا النص هو مثال لنص يمكن أن يستبدل في نفس المساحة، لقد تم توليده هذا النص من مولمن مولد النص العربي، حيث يمكن لهذا النص";

  constructor(private injector: Injector, private service: CoreService, private http: HttpClient) {
    super(injector);
  }

}
