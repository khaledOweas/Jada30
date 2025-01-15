import { NgClass } from "@angular/common";
import { Component, OnInit } from "@angular/core";
import { Router, NavigationEnd, RouterLinkActive, RouterLink } from "@angular/router";
import { filter } from "rxjs/operators";

@Component({
  selector: "app-side-bar",
  standalone: true,
  imports: [RouterLink, RouterLinkActive, NgClass],
  templateUrl: "./side-bar.component.html",
  styleUrl: "./side-bar.component.css"
})
export class SideBarComponent implements OnInit {
  constructor(private router: Router) {
    // Subscribe to router events to get the current route
    this.router.events
      .pipe(
        filter((event): event is NavigationEnd => event instanceof NavigationEnd) // Type guard to ensure the event is NavigationEnd
      )
      .subscribe((event: NavigationEnd) => {
        this.currentRoute = event.url; // Now TypeScript knows `event` is of type NavigationEnd
      });
  }
  ngOnInit(): void {
    this.getUserName();
  }
  currentRoute: string = "";
  username: string = "";
  lang: string = "";
  getUserName() {
    if (typeof localStorage != "undefined") {
      this.username = JSON.parse(localStorage.getItem("user")!).nameAr;
      this.lang = localStorage.getItem("dir")!;
    }
  }
  checkActiveChildren(item: any): boolean {
    if (item.Children) {
      return item.Children.some((child: any) => this.currentRoute === child.PageUrl);
    }
    return false;
  }
  menuObj = [
    {
      PageNameAr: "إحصائيات",
      PageNameEng: "Dashboard",
      PageUrl: "/Statistics",
      PageType: "Accordion",
      Icon: ` <i class="ki-duotone ki-element-11 fs-2">
                <span class="path1"></span>
                <span class="path2"></span>
                <span class="path3"></span>
                <span class="path4"></span>
              </i>`,
      Children: [
        {
          PageNameAr: "إحصـائيات المستخدمين",
          PageNameEng: "User Statistics",
          PageUrl: "/User/UserStatistics"
        },
        {
          PageNameAr: "إحصائيات الفروع",
          PageNameEng: "Branches Statistics",
          PageUrl: "/Branch/BranchStatistics"
        }
      ]
    },
    {
      PageType: "Header",
      PageNameAr: "الإدارات",
      PageNameEng: "Managments"
    },
    {
      PageNameAr: "إدارة المستخدمين",
      PageNameEng: "User Managments",
      PageType: "Accordion",
      Icon: `  <i class="ki-duotone ki-user fs-2">
                <span class="path1"></span>
                <span class="path2"></span>
              </i>`,
      Children: [
        {
          PageNameAr: "قائمة المستخدمين",
          PageNameEng: "User List",
          PageUrl: "/user-list"
        },
        {
          PageNameAr: "الصلاحيات",
          PageNameEng: "Roles",
          PageUrl: "/role-list"
        }
      ]
    }
  ];
}
