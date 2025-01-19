import { Routes } from "@angular/router";
import { LayoutComponent } from "src/app/_metronic/layout/layout.component";
import { UserListComponent } from "../user/user-list/user-list.component";
import { UserCreateComponent } from "../user/user-create/user-create.component";
import { UserUpdateComponent } from "../user/user-update/user-update.component";
import { RoleListComponent } from "../user/role-list/role-list.component";

export const USER_ROUTES: Routes = [
  {
    path: "",
    component: LayoutComponent,
    children: [
      { path: "user-list", component: UserListComponent },
      { path: "user-create", component: UserCreateComponent },
      { path: "user-update/:id", component: UserUpdateComponent },
      { path: "role-list", component: RoleListComponent }
    ]
  }
];
