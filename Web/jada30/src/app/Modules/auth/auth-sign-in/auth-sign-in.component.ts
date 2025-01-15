import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { LoginService } from "../services/login.service";
import { FormsModule } from "@angular/forms";
import { jwtDecode } from "jwt-decode";

@Component({
  selector: "app-auth-sign-in",
  standalone: true,
  imports: [FormsModule],
  templateUrl: "./auth-sign-in.component.html",
  styleUrl: "./auth-sign-in.component.css"
})
export class AuthSignInComponent {
  email: string = "SuperAdmin";
  password: string = "P@ssw0rd";
  constructor(private router: Router, private loginService: LoginService) {}
  signIn() {
    if (!this.email || !this.password) {
      alert("Please enter email and password");
      return;
    }
    this.loginService.login(this.email, this.password).subscribe(
      (response) => {
        localStorage.setItem("token", response.access_token);
        localStorage.setItem(
          "user",
          JSON.stringify({
            nameAr: JSON.parse(JSON.parse(JSON.stringify(jwtDecode(response.access_token))).data).UserNameAr
          })
        );
        // this.router.navigate(["/home/test"]);
        window.location.href = "/home/test";
      },
      (error) => {
        console.error("Login failed:", error);
        alert("Invalid login credentials");
      }
    );
  }
}
