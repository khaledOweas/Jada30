import { Component } from "@angular/core";
import { Router } from "@angular/router";

@Component({
  selector: "app-auth-sign-in",
  standalone: true,
  imports: [],
  templateUrl: "./auth-sign-in.component.html",
  styleUrl: "./auth-sign-in.component.css"
})
export class AuthSignInComponent {
  constructor(private router: Router) {}
  signIn() {
    // this.router.navigate(["/home/test"]);
    console.log("SignIn Clicked");
    window.location.href = "/home/test";
  }
}
