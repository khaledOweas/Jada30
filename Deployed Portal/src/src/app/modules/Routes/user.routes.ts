import { Routes } from "@angular/router";
import { UserListComponent } from "../user/user-list/user-list.component";
import { UserCreateComponent } from "../user/user-create/user-create.component";
import { UserUpdateComponent } from "../user/user-update/user-update.component";
import { RoleListComponent } from "../user/role-list/role-list.component";
import { AuthGuard } from "../auth/services/auth.guard";

export const USER_ROUTES: Routes = [
  { path: "user-list", canActivate: [], component: UserListComponent },
  { path: "user-create", canActivate: [], component: UserCreateComponent },
  { path: "user-update/:id", canActivate: [], component: UserUpdateComponent },
  { path: "role-list", canActivate: [], component: RoleListComponent }
];
