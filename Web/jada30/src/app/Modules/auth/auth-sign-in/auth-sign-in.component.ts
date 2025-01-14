import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { LoginService } from "../services/login.service";
import { FormsModule } from "@angular/forms";
import { HttpClient } from "@angular/common/http";

@Component({
  selector: "app-auth-sign-in",
  standalone: true,
  imports: [FormsModule],
  templateUrl: "./auth-sign-in.component.html",
  styleUrl: "./auth-sign-in.component.css"
})
export class AuthSignInComponent {
  email: string = "newuser";
  password: string = "P@ssw0rd";
  constructor(private router: Router, private loginService: LoginService) {}
  signIn() {
    if (!this.email || !this.password) {
      alert("Please enter email and password");
      return;
    }

    this.loginService.login(this.email, this.password).subscribe(
      (response) => {
        console.log("Login successful:", response);
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
