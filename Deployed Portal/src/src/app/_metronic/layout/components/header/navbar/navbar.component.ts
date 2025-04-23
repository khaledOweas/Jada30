import { NgClass, NgIf } from "@angular/common";
import { AfterViewInit, Component, Input, OnInit } from "@angular/core";
import { menuReinitialization } from "src/app/_metronic/kt/kt-helpers";
import { NotificationsInnerComponent } from "src/app/_metronic/partials/layout/extras/dropdown-inner/notifications-inner/notifications-inner.component";
import { QuickLinksInnerComponent } from "src/app/_metronic/partials/layout/extras/dropdown-inner/quick-links-inner/quick-links-inner.component";
import { SearchResultInnerComponent } from "src/app/_metronic/partials/layout/extras/dropdown-inner/search-result-inner/search-result-inner.component";
import { UserInnerComponent } from "src/app/_metronic/partials/layout/extras/dropdown-inner/user-inner/user-inner.component";
import { ThemeModeSwitcherComponent } from "src/app/_metronic/partials/layout/theme-mode-switcher/theme-mode-switcher.component";
import { KeeniconComponent } from "src/app/_metronic/shared/keenicon/keenicon.component";

@Component({
  selector: "app-navbar",
  templateUrl: "./navbar.component.html",
  styleUrls: ["./navbar.component.scss"],
  standalone: true,
  imports: [
    NgClass,
    KeeniconComponent,
    SearchResultInnerComponent,
    NotificationsInnerComponent,
    QuickLinksInnerComponent,
    ThemeModeSwitcherComponent,
    UserInnerComponent,
    NgIf
  ]
})
export class NavbarComponent implements OnInit, AfterViewInit {
  @Input() appHeaderDefaulMenuDisplay: boolean;
  @Input() isRtl: boolean;

  itemClass: string = "ms-1 ms-lg-3";
  btnClass: string =
    "btn btn-icon btn-custom btn-icon-muted btn-active-light btn-active-color-primary w-35px h-35px w-md-40px h-md-40px";
  userAvatarClass: string = "symbol-35px symbol-md-40px";
  btnIconClass: string = "fs-2 fs-md-1";

  constructor() {}

  ngAfterViewInit(): void {
    menuReinitialization();
  }

  ngOnInit(): void {}
}
