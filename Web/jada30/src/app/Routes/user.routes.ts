import { UserListComponent } from "../Modules/user/user-list/user-list.component";
import { LayoutComponent } from "../Layout/layout/layout.component";
import { Routes } from "@angular/router";

export const USER_ROUTES: Routes = [
  {
    path: "",
    component: LayoutComponent, // Wraps main app routes
    children: [{ path: "user-list", component: UserListComponent }]
  }
];
