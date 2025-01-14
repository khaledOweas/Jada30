import { Routes } from "@angular/router";
import { LayoutComponent } from "./Layout/layout/layout.component";

export const routes: Routes = [
  {
    path: "auth",
    loadChildren: () => import("./Routes/login.routes").then((m) => m.LOGIN_ROUTES)
  },
  {
    path: "",
    loadChildren: () => import("./Routes/user.routes").then((m) => m.USER_ROUTES)
  },
  { path: "**", redirectTo: "" }
];
