import { Routes } from "@angular/router";
import { LayoutComponent } from "./layout.component";
import { AuthGuard } from "src/app/modules/auth/services/auth.guard";

export const LAYOUT_ROUTES: Routes = [
  {
    path: "",
    canActivate: [AuthGuard],
    component: LayoutComponent,
    children: [
      {
        path: "dashboard",
        loadChildren: () => import("../../pages/dashboard/dashboard.routes").then((m) => m.DASHBOARD_ROUTES)
      },
      {
        path: "builder",
        loadChildren: () => import("../../pages/builder/builder.routes").then((m) => m.BUILDER_ROUTES)
      },
      {
        path: "crafted/pages/profile",
        loadChildren: () => import("../../modules/profile/profile.routes").then((m) => m.PROFILE_ROUTES)
        // data: { layout: 'light-sidebar' },
      },
      {
        path: "crafted/account",
        loadChildren: () => import("../../modules/account/account.routes").then((m) => m.ACCOUNT_ROUTES)
        // data: { layout: 'dark-header' },
      },
      // {
      //   path: "crafted/pages/wizards",
      //   loadChildren: () => import("../modules/wizards/wizards-routing.module").then((m) => m.WizardsRoutingModule)
      //   // data: { layout: 'light-header' },
      // },
      // {
      //   path: "crafted/widgets",
      //   loadChildren: () =>
      //     import("../modules/widgets-examples/widgets-examples.module").then((m) => m.WidgetsExamplesModule)
      //   // data: { layout: 'light-header' },
      // },
      // {
      //   path: "apps/chat",
      //   loadChildren: () => import("../modules/apps/chat/chat.module").then((m) => m.ChatModule)
      //   // data: { layout: 'light-sidebar' },
      // },
      {
        path: "user",
        loadChildren: () => import("../../modules/Routes/user.routes").then((m) => m.USER_ROUTES)
      },
      {
        path: "lookups",
        loadChildren: () => import("../../modules/Routes/lookup.routes").then((m) => m.LOOKUP_ROUTES)
      },
      // {
      //   path: "apps/roles",
      //   loadChildren: () => import("./role/role.module").then((m) => m.RoleModule)
      // },
      // {
      //   path: "apps/permissions",
      //   loadChildren: () => import("./permission/permission.module").then((m) => m.PermissionModule)
      // },
      {
        path: "",
        redirectTo: "/dashboard",
        pathMatch: "full"
      },
      {
        path: "**",
        redirectTo: "error/404"
      }
    ]
  }
];

// import { NgModule } from '@angular/core';
// import { CommonModule } from '@angular/common';
// import { InlineSVGModule } from 'ng-inline-svg-2';
// import { RouterModule, Routes } from '@angular/router';
// import {
//   NgbDropdownModule,
//   NgbProgressbarModule,
//   NgbTooltipModule,
// } from '@ng-bootstrap/ng-bootstrap';
// import { TranslateModule } from '@ngx-translate/core';
// import { TranslationModule } from '../../modules/i18n';
// import { LayoutComponent } from './layout.component';
// import { ExtrasModule } from '../partials/layout/extras/extras.module';
// import { Routing } from '../../pages/routing';
// import { HeaderComponent } from './components/header/header.component';
// import { ContentComponent } from './components/content/content.component';
// import { FooterComponent } from './components/footer/footer.component';
// import { ScriptsInitComponent } from './components/scripts-init/scripts-init.component';
// import { ToolbarComponent } from './components/toolbar/toolbar.component';
// import { TopbarComponent } from './components/topbar/topbar.component';
// import { PageTitleComponent } from './components/header/page-title/page-title.component';
// import { HeaderMenuComponent } from './components/header/header-menu/header-menu.component';
// import {
//   DrawersModule,
//   DropdownMenusModule,
//   ModalsModule,
//   EngagesModule,
// } from '../partials';
// import { EngagesComponent } from '../partials/layout/engages/engages.component';
// import { ThemeModeModule } from '../partials/layout/theme-mode-switcher/theme-mode.module';
// import { SidebarComponent } from './components/sidebar/sidebar.component';
// import { SidebarLogoComponent } from './components/sidebar/sidebar-logo/sidebar-logo.component';
// import { SidebarMenuComponent } from './components/sidebar/sidebar-menu/sidebar-menu.component';
// import { SidebarFooterComponent } from './components/sidebar/sidebar-footer/sidebar-footer.component';
// import { NavbarComponent } from './components/header/navbar/navbar.component';
// import { AccountingComponent } from './components/toolbar/accounting/accounting.component';
// import { ClassicComponent } from './components/toolbar/classic/classic.component';
// import { ExtendedComponent } from './components/toolbar/extended/extended.component';
// import { ReportsComponent } from './components/toolbar/reports/reports.component';
// import { SaasComponent } from './components/toolbar/saas/saas.component';
// import {SharedModule} from "../shared/shared.module";

// @NgModule({
//   declarations: [
//     LayoutComponent,
//     HeaderComponent,
//     ContentComponent,
//     FooterComponent,
//     ScriptsInitComponent,
//     ToolbarComponent,
//     TopbarComponent,
//     PageTitleComponent,
//     HeaderMenuComponent,
//     EngagesComponent,
//     SidebarComponent,
//     SidebarLogoComponent,
//     SidebarMenuComponent,
//     SidebarFooterComponent,
//     NavbarComponent,
//     AccountingComponent,
//     ClassicComponent,
//     ExtendedComponent,
//     ReportsComponent,
//     SaasComponent,
//   ],
//   imports: [
//     CommonModule,
//     RouterModule.forChild(routes),
//     TranslationModule,
//     InlineSVGModule,
//     NgbDropdownModule,
//     NgbProgressbarModule,
//     ExtrasModule,
//     ModalsModule,
//     DrawersModule,
//     EngagesModule,
//     DropdownMenusModule,
//     NgbTooltipModule,
//     TranslateModule,
//     ThemeModeModule,
//     SharedModule
//   ],
//   exports: [RouterModule],
// })
// export class LayoutModule {}
