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

import { MainPageWorkspaceComponent } from "../main-page-workspace/main-page-workspace.component";

@Component({
  selector: "app-main-page-workspaces",
  standalone: true,
  imports: [ RouterLink, RouterLinkActive,  CommonModule,MainPageWorkspaceComponent,
    // JadaCardSystemServiceComponent, 
    CardModule, ButtonModule],
  templateUrl: "./main-page-workspaces.component.html",
  styleUrl: "./main-page-workspaces.component.scss",
  providers: [CoreService]
})
export class MainPageWorkspacesComponent extends BaseComponent  {

  apiurl= 'http://localhost:5000/api/Data/Endpoint2'

  @Input() data: {name: string, details: string}[]=[
    {name:"الخطوة الأساسية", details:"هذا النص هو مثال لنص يمكن أن يستبدل في نفس المساحة، لقد تم توليده هذا النص من مولمن مولد النص العربي، حيث يمكن لهذا النص"},
    {name:"الخطوة الفرعية", details:"هذا النص هو مثال لنص يمكن أن يستبدل في نفس المساحة، لقد تم توليده هذا النص من مولمن مولد النص العربي، حيث يمكن لهذا النص"},
    {name:"الخطوة الثانوية", details:"هذا النص هو مثال لنص يمكن أن يستبدل في نفس المساحة، لقد تم توليده هذا النص من مولمن مولد النص العربي، حيث يمكن لهذا النص"}
  ]


  constructor(private injector: Injector, private service: CoreService, private http: HttpClient) {
    super(injector);
  }

}
