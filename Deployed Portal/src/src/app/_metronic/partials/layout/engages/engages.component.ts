import { Component, OnInit } from "@angular/core";
import { ExploreMainDrawerComponent } from "./explore-main-drawer/explore-main-drawer.component";
import { HelpDrawerComponent } from "./help-drawer/help-drawer.component";
import { PurchaseToolbarComponent } from "./purchase-toolbar/purchase-toolbar.component";

@Component({
  selector: "app-engages",
  templateUrl: "./engages.component.html",
  styleUrls: ["./engages.component.scss"],
  standalone: true,
  imports: [ExploreMainDrawerComponent, HelpDrawerComponent, PurchaseToolbarComponent]
})
export class EngagesComponent implements OnInit {
  constructor() {}

  ngOnInit(): void {}
}
