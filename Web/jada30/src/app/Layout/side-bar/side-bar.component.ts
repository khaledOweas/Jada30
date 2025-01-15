import { Component, OnInit } from "@angular/core";
import { RouterLink, RouterLinkActive } from "@angular/router";

@Component({
  selector: "app-side-bar",
  standalone: true,
  imports: [RouterLink, RouterLinkActive],
  templateUrl: "./side-bar.component.html",
  styleUrl: "./side-bar.component.css"
})
export class SideBarComponent implements OnInit {
  constructor() {}
  ngOnInit(): void {
    this.getUserName();
  }
  username: string = "";

  getUserName() {
    if (typeof localStorage != "undefined") {
      this.username = JSON.parse(localStorage.getItem("user")!).nameAr;
    }
  }
}
