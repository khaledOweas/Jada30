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
    },
    {
      PageNameAr: "الأدوار",
      PageNameEng: "Roles",
      PageUrl: "/roles",
      PageType: "Accordion",
      Icon: `<i class="ki-duotone ki-user fs-2">
              <span class="path1"></span>
              <span class="path2"></span>
            </i>`,
      Children: [
        {
          PageNameAr: "إدارة الأدوار",
          PageNameEng: "Manage Roles",
          PageUrl: "/roles/manage"
        },
        {
          PageNameAr: "صلاحيات المستخدمين",
          PageNameEng: "User Permissions",
          PageUrl: "/roles/permissions"
        }
      ]
    },
    {
      PageNameAr: "أنواع العقود",
      PageNameEng: "Contract Types",
      PageUrl: "/contracts",
      PageType: "Accordion",
      Icon: `<i class="ki-duotone ki-briefcase fs-2">
              <span class="path1"></span>
              <span class="path2"></span>
            </i>`,
      Children: [
        {
          PageNameAr: "إدارة العقود",
          PageNameEng: "Manage Contracts",
          PageUrl: "/contracts/manage"
        },
        {
          PageNameAr: "العقود طويلة الأجل",
          PageNameEng: "Long-Term Contracts",
          PageUrl: "/contracts/long-term"
        }
      ]
    },
    {
      PageNameAr: "فئات التسعير",
      PageNameEng: "Pricing Categories",
      PageUrl: "/pricing",
      PageType: "Accordion",
      Icon: `<i class="ki-duotone ki-wallet fs-2">
              <span class="path1"></span>
              <span class="path2"></span>
            </i>`,
      Children: [
        {
          PageNameAr: "إدارة الفئات",
          PageNameEng: "Manage Categories",
          PageUrl: "/pricing/manage"
        },
        {
          PageNameAr: "العروض الموسمية",
          PageNameEng: "Seasonal Offers",
          PageUrl: "/pricing/seasonal-offers"
        }
      ]
    },
    {
      PageNameAr: "الباقات",
      PageNameEng: "Packages",
      PageUrl: "/packages",
      PageType: "Accordion",
      Icon: `<i class="ki-duotone ki-package fs-2">
              <span class="path1"></span>
              <span class="path2"></span>
            </i>`,
      Children: [
        {
          PageNameAr: "الباقة الرئيسية",
          PageNameEng: "Main Package",
          PageUrl: "/packages/main"
        },
        {
          PageNameAr: "مكتب افتراضي",
          PageNameEng: "Virtual Office",
          PageUrl: "/packages/virtual-office"
        }
      ]
    },
    {
      PageNameAr: "فئات مساحات العمل",
      PageNameEng: "Workspace Categories",
      PageUrl: "/workspace",
      PageType: "Accordion",
      Icon: `<i class="ki-duotone ki-home fs-2">
              <span class="path1"></span>
              <span class="path2"></span>
            </i>`,
      Children: [
        {
          PageNameAr: "مساحات العمل المشترك",
          PageNameEng: "Co-Working Space",
          PageUrl: "/workspace/co-working"
        },
        {
          PageNameAr: "المكاتب الخاصة",
          PageNameEng: "Private Offices",
          PageUrl: "/workspace/private"
        }
      ]
    },
    {
      PageNameAr: "الفعاليات",
      PageNameEng: "Events",
      PageUrl: "/events",
      PageType: "Accordion",
      Icon: `<i class="ki-duotone ki-calendar fs-2">
              <span class="path1"></span>
              <span class="path2"></span>
            </i>`,
      Children: [
        {
          PageNameAr: "ورش العمل",
          PageNameEng: "Workshops",
          PageUrl: "/events/workshops"
        },
        {
          PageNameAr: "إطلاق المنتجات",
          PageNameEng: "Product Launches",
          PageUrl: "/events/product-launch"
        }
      ]
    },
    {
      PageNameAr: "الخدمات الداعمة",
      PageNameEng: "Supporting Services",
      PageUrl: "/services",
      PageType: "Accordion",
      Icon: `<i class="ki-duotone ki-support fs-2">
              <span class="path1"></span>
              <span class="path2"></span>
            </i>`,
      Children: [
        {
          PageNameAr: "الدعم الفني",
          PageNameEng: "IT Support",
          PageUrl: "/services/it-support"
        },
        {
          PageNameAr: "الاستشارات القانونية",
          PageNameEng: "Legal Consultation",
          PageUrl: "/services/legal"
        }
      ]
    },
    {
      PageNameAr: "أنواع المحتوى",
      PageNameEng: "Content Types",
      PageUrl: "/content",
      PageType: "Accordion",
      Icon: `<i class="ki-duotone ki-file-text fs-2">
              <span class="path1"></span>
              <span class="path2"></span>
            </i>`,
      Children: [
        {
          PageNameAr: "الأخبار",
          PageNameEng: "News",
          PageUrl: "/content/news"
        },
        {
          PageNameAr: "المدونات",
          PageNameEng: "Blogs",
          PageUrl: "/content/blogs"
        }
      ]
    }
  ];
}
