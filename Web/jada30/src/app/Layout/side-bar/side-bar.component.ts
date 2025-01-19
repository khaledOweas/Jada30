import { NgClass } from "@angular/common";
import { Component, OnInit } from "@angular/core";
import { Router, NavigationEnd, RouterLinkActive, RouterLink } from "@angular/router";
import { filter } from "rxjs/operators";
import { GetLookupDtoListBaseResponse, LookupService } from "../../Services/LookupService";

@Component({
  selector: "app-side-bar",
  standalone: true,
  imports: [RouterLink, RouterLinkActive, NgClass],
  providers: [LookupService],
  templateUrl: "./side-bar.component.html",
  styleUrl: "./side-bar.component.css"
})
export class SideBarComponent implements OnInit {
  currentRoute: string = "";
  username: string = "";
  lang: string = "";
  menuObj: any[] = [];

  constructor(private router: Router, private service: LookupService) {
    this.router.events
      .pipe(filter((event): event is NavigationEnd => event instanceof NavigationEnd))
      .subscribe((event: NavigationEnd) => {
        this.currentRoute = event.url;
      });
  }

  ngOnInit(): void {
    this.getUserName();
    this.initializeMenu();
    this.loadAllCategories();
  }

  initializeMenu(): void {
    this.menuObj = [
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
      },
      {
        PageNameAr: "إدارة التعريفات",
        PageNameEng: "Lookups",
        PageUrl: "/lookups",
        PageType: "Accordion",
        Icon: `<i class="ki-duotone ki-user fs-2">
              <span class="path1"></span>
              <span class="path2"></span>
            </i>`,
        Children: []
      }
    ];
  }

  loadAllCategories(): void {
    this.service.getAllCategory().subscribe({
      next: (res: GetLookupDtoListBaseResponse) => {
        if (res.responseData) {
          const item = this.menuObj.filter((x) => x.PageNameEng === "Lookups")[0];
          res.responseData.forEach((element) => {
            const child: any = {
              PageNameAr: element.nameAr,
              PageNameEng: element.name,
              PageUrl: "/lookup/lookup-list/" + element.internalCode
            };
            item.Children.push(child);
          });
        }
      },
      error: (err) => {
        console.error("Failed to load categories:", err);
      }
    });
  }

  getUserName(): void {
    if (typeof localStorage !== "undefined") {
      const user = localStorage.getItem("user");
      if (user) {
        this.username = JSON.parse(user).nameAr;
      }
      this.lang = localStorage.getItem("dir") || "";
    }
  }

  checkActiveChildren(item: any): boolean {
    if (item.Children) {
      return item.Children.some((child: any) => this.currentRoute === child.PageUrl);
    }
    return false;
  }
}
