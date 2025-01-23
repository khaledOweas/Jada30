import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { AuthService } from "./auth.service";
import { jwtDecode } from "jwt-decode";

@Injectable({ providedIn: "root" })
export class AuthGuard {
  constructor(private authService: AuthService) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    try {
      let token = localStorage.getItem("token");
      const tokenPayload = JSON.parse(JSON.stringify(jwtDecode(token!)));
      const nowInSeconds = Math.floor(Date.now() / 1000);
      if (nowInSeconds < tokenPayload.exp) {
        return true;
      }
      this.authService.logout();
      return false;
    } catch (error) {
      localStorage.removeItem("user");
      this.authService.logout();
      return false;
    }
  }
}
