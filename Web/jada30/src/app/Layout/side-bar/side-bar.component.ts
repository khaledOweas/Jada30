import { NgClass } from "@angular/common";
import { Component, OnChanges, OnInit, SimpleChanges } from "@angular/core";
import { Router, RouterLink, RouterLinkActive } from "@angular/router";

@Component({
  selector: "app-side-bar",
  standalone: true,
  imports: [RouterLink, NgClass, RouterLinkActive],
  templateUrl: "./side-bar.component.html",
  styleUrl: "./side-bar.component.css"
})
export class SideBarComponent implements OnInit, OnChanges {
  url: string = "";
  constructor(private router: Router) {}
  ngOnChanges(changes: SimpleChanges): void {
    this.url = this.router.url;
  }
  ngOnInit(): void {
    this.url = this.router.url;
  }
}
