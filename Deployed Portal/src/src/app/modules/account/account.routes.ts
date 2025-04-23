import { Routes } from "@angular/router";
import { OverviewComponent } from "./overview/overview.component";
import { AccountComponent } from "./account.component";
import { SettingsComponent } from "./settings/settings.component";

export const ACCOUNT_ROUTES: Routes = [
  {
    path: "",
    component: AccountComponent,
    children: [
      {
        path: "overview",
        component: OverviewComponent
      },
      {
        path: "settings",
        component: SettingsComponent
      },
      { path: "", redirectTo: "overview", pathMatch: "full" },
      { path: "**", redirectTo: "overview", pathMatch: "full" }
    ]
  }
];
