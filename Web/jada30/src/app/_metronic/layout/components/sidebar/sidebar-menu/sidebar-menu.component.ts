import { CommonModule } from "@angular/common";
import { Component, OnInit } from "@angular/core";
import { Router, NavigationEnd, RouterLink, RouterLinkActive } from "@angular/router";
import { filter } from "rxjs";
import { GetLookupDtoListBaseResponse, LookupService } from "src/app/services/LookupService";

@Component({
  selector: "app-sidebar-menu",
  templateUrl: "./sidebar-menu.component.html",
  styleUrls: ["./sidebar-menu.component.scss"],
  standalone: true,
  providers: [LookupService],
  imports: [CommonModule, RouterLink, RouterLinkActive]
})
export class SidebarMenuComponent implements OnInit {
  currentRoute: string = "";
  menuObj: any[] = [];
  lang: string = "en";
  username: string = "";

  constructor(private router: Router, private service: LookupService) {
    this.router.events
      .pipe(filter((event): event is NavigationEnd => event instanceof NavigationEnd))
      .subscribe((event: NavigationEnd) => {
        this.currentRoute = event.url;
      });
  }

  ngOnInit(): void {
    this.lang = localStorage.getItem("language") || "";
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
        PageNameEng: "Managements"
      },
      {
        PageNameAr: "إدارة المستخدمين",
        PageNameEng: "User Managements",
        PageType: "Accordion",
        Icon: `  <i class="ki-duotone ki-user fs-2">
                  <span class="path1"></span>
                  <span class="path2"></span>
                </i>`,
        Children: [
          {
            PageNameAr: "قائمة المستخدمين",
            PageNameEng: "User List",
            PageUrl: "/user/user-list"
          },
          {
            PageNameAr: "الصلاحيات",
            PageNameEng: "Roles",
            PageUrl: "/user/role-list"
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
      },
      {
        PageNameAr: "إدارة الفروع",
        PageNameEng: "Branch Managements",
        PageType: "Accordion",
        Icon: `  <i class="ki-duotone ki-user fs-2">
                  <span class="path1"></span>
                  <span class="path2"></span>
                </i>`,
        Children: [
          {
            PageNameAr: "قائمة الفروع",
            PageNameEng: "Branch List",
            PageUrl: "/branch/branch-list"
          },
          {
            PageNameAr: "قائمة المرافق",
            PageNameEng: "Facility List",
            PageUrl: "/facility/facility-list"
          },
          {
            PageNameAr: "قائمة الباقات",
            PageNameEng: "Package List",
            PageUrl: "/package/package-list"
          }
        ]
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
              PageUrl: "/lookups/lookup-list/" + element.internalCode
            };
            item.Children.push(child);
          });
          item.Children.unshift({
            PageNameAr: "الكل",
            PageNameEng: "All",
            PageUrl: "/lookups/lookup-list/All"
          });
        }
      },
      error: (err) => {
        console.error("Failed to load categories:", err);
      }
    });
  }
  checkActiveChildren(item: any): boolean {
    if (item.Children) {
      return item.Children.some((child: any) => this.currentRoute === child.PageUrl);
    }
    return false;
  }

  getUserName(): void {
    if (typeof localStorage !== "undefined") {
      const user = localStorage.getItem("user");
      if (user) {
        this.username = JSON.parse(user).nameAr;
      }
    }
  }
}
