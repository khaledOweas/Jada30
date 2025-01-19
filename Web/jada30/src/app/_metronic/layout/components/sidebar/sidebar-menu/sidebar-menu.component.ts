import { CommonModule } from "@angular/common";
import { Component, OnInit } from "@angular/core";
import { RouterLink } from "@angular/router";
import { TranslateModule } from "@ngx-translate/core";
import { KeeniconComponent } from "src/app/_metronic/shared/keenicon/keenicon.component";

@Component({
  selector: "app-sidebar-menu",
  templateUrl: "./sidebar-menu.component.html",
  styleUrls: ["./sidebar-menu.component.scss"],
  standalone: true,
  imports: [KeeniconComponent, CommonModule, TranslateModule, RouterLink]
})
export class SidebarMenuComponent implements OnInit {
  constructor() {}

  ngOnInit(): void {}
}
