import { Component, ViewChild } from "@angular/core";
import { CardsWidget20Component } from "src/app/_metronic/partials/content/widgets/_new/cards/cards-widget20/cards-widget20.component";
import { CardsWidget7Component } from "src/app/_metronic/partials/content/widgets/_new/cards/cards-widget7/cards-widget7.component";
import { CardsWidget17Component } from "src/app/_metronic/partials/content/widgets/_new/cards/cards-widget17/cards-widget17.component";
import { ListsWidget26Component } from "src/app/_metronic/partials/content/widgets/_new/lists/lists-widget26/lists-widget26.component";
import { EngageWidget10Component } from "src/app/_metronic/partials/content/widgets/_new/engage/engage-widget10/engage-widget10.component";

@Component({
  selector: "app-dashboard",
  standalone: true, // Generated Stand-Alone Component
  templateUrl: "./dashboard.component.html",
  styleUrls: ["./dashboard.component.scss"],
  imports: [
    CardsWidget20Component,
    CardsWidget7Component,
    CardsWidget17Component,
    ListsWidget26Component,
    EngageWidget10Component
  ]
})
export class DashboardComponent {
  constructor() {}
}