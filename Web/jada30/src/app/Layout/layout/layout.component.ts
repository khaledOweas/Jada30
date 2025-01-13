import { Component } from "@angular/core";
import { SideBarComponent } from "../side-bar/side-bar.component";
import { HeaderBarComponent } from "../header-bar/header-bar.component";
import { ScrollToTopComponent } from "../scroll-to-top/scroll-to-top.component";
import { RouterOutlet } from "@angular/router";

@Component({
  selector: "app-layout",
  standalone: true,
  imports: [RouterOutlet, SideBarComponent, HeaderBarComponent, ScrollToTopComponent],
  templateUrl: "./layout.component.html",
  styleUrl: "./layout.component.css"
})
export class LayoutComponent {}
