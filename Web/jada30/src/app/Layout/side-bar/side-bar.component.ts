import { NgClass } from "@angular/common";
import { Component, OnChanges, OnInit, SimpleChanges } from "@angular/core";
import { RouterLink, RouterLinkActive } from "@angular/router";

@Component({
  selector: "app-side-bar",
  standalone: true,
  imports: [RouterLink, NgClass, RouterLinkActive],
  templateUrl: "./side-bar.component.html",
  styleUrl: "./side-bar.component.css"
})
export class SideBarComponent {
  constructor() {}
}
