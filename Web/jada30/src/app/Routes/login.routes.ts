import { AuthLayoutComponent } from "../Modules/auth/auth-layout/auth-layout.component";
import { AuthSignInComponent } from "../Modules/auth/auth-sign-in/auth-sign-in.component";

export const LOGIN_ROUTES = [
  {
    path: "",
    component: AuthLayoutComponent,
    children: [
      { path: "login", component: AuthSignInComponent },
      { path: "register", component: AuthSignInComponent }
    ]
  }
];
