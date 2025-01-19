import { Routes } from "@angular/router";

export const routes: Routes = [
  {
    path: "auth",
    loadChildren: () => import("./Routes/login.routes").then((m) => m.LOGIN_ROUTES)
  },
  {
    path: "",
    loadChildren: () => import("./Routes/user.routes").then((m) => m.USER_ROUTES)
  },
  {
    path: "lookup",
    loadChildren: () => import("./Routes/lookup.routes").then((m) => m.LOOKUP_ROUTES)
  },
  { path: "**", redirectTo: "" }
];
