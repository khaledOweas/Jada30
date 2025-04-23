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

import { AboutJadaSuccessStoriesComponent } from "../about-jada-success-stories/about-jada.-success-stories.component";
import { AboutJadaBlogsComponent } from "../about-jada-blogs/about-jada.-blogs.component";
import { AboutJadaNewsComponent } from "../about-jada-news/about-jada.-news.component";
import { AboutJadaEventsComponent } from "../about-jada-events/about-jada.-events.component";
@Component({
  selector: "app-about-jada",
  standalone: true,
  imports: [ RouterLink, RouterLinkActive,  CommonModule,
    AboutJadaSuccessStoriesComponent,AboutJadaBlogsComponent,AboutJadaNewsComponent, AboutJadaEventsComponent,
    // JadaCardSystemServiceComponent, 
    CardModule, ButtonModule],
  templateUrl: "./about-jada.component.html",
  styleUrl: "./about-jada.component.scss",
  providers: [CoreService]
})
export class AboutJadaComponent extends BaseComponent  {

  apiurl= 'http://localhost:5000/api/Data/Endpoint2'


  constructor(private injector: Injector, private service: CoreService, private http: HttpClient) {
    super(injector);
  }

}
