import { UserListComponent } from "../Modules/user/user-list/user-list.component";
import { LayoutComponent } from "../Layout/layout/layout.component";
import { Routes } from "@angular/router";
import { RoleListComponent } from "../Modules/user/role-list/role-list.component";
import { UserCreateComponent } from "../Modules/user/user-create/user-create.component";
import { UserUpdateComponent } from "../Modules/user/user-update/user-update.component";

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
