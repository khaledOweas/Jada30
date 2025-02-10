import { Component, OnInit, OnDestroy, ChangeDetectorRef } from "@angular/core";
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from "@angular/forms";
import { Subscription, Observable } from "rxjs";
import { first } from "rxjs/operators";
import { ActivatedRoute, Router } from "@angular/router";
import { AsyncPipe, NgClass, NgIf, NgTemplateOutlet } from "@angular/common";
import { AuthService } from "../../services/auth.service";
import { jwtDecode } from "jwt-decode";
import { TranslationModule } from "src/app/modules/i18n";
import { ValidationAlertsComponent } from "src/app/core/Components/validation-alerts/validation-alerts.component";
import { TranslationService } from "src/app/core/services/translation.service";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.scss"],
  standalone: true,
  imports: [
    NgClass,
    NgTemplateOutlet,
    FormsModule,
    ReactiveFormsModule,
    AsyncPipe,
    TranslationModule,
    ValidationAlertsComponent
  ]
})
export class LoginComponent implements OnInit, OnDestroy {
  // KeenThemes mock, change it to:
  defaultAuth: any = {
    email: "SuperAdmin",
    password: "P@ssw0rd"
  };
  loginForm: FormGroup;
  hasError: boolean;
  returnUrl: string;
  isLoading$: Observable<boolean>;

  // private fields
  private unsubscribe: Subscription[] = []; // Read more: => https://brianflove.com/2016/12/11/anguar-2-unsubscribe-observables/

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    public tr: TranslationService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.isLoading$ = this.authService.isLoading$;
    // redirect to home if already logged in
    if (this.authService.currentUserValue) {
      this.router.navigate(["/"]);
    }
  }

  ngOnInit(): void {
    this.initForm();
    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams["returnUrl".toString()] || "/";
  }

  // convenience getter for easy access to form fields
  get f() {
    return this.loginForm.controls;
  }

  initForm() {
    this.loginForm = this.fb.group({
      email: [
        this.defaultAuth.email,
        Validators.compose([
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(320) // https://stackoverflow.com/questions/386294/what-is-the-maximum-length-of-a-valid-email-address
        ])
      ],
      password: [
        this.defaultAuth.password,
        Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(100)])
      ]
    });
  }
  usernameError: boolean = false;
  passwordError: boolean = false;
  submit() {
    this.hasError = false;
    const loginSubscr = this.authService
      .login(this.f.email.value, this.f.password.value)
      .pipe(first())
      .subscribe(
        (response) => {
          localStorage.setItem("token", response.access_token);
          localStorage.setItem(
            "user",
            JSON.stringify({
              nameAr: JSON.parse(JSON.parse(JSON.stringify(jwtDecode(response.access_token))).data).UserNameAr,
              nameEn: JSON.parse(JSON.parse(JSON.stringify(jwtDecode(response.access_token))).data).UserName
            })
          );
          this.authService.isLoadingSubject.next(false);
          this.router.navigate(["/dashboard"]);
        },
        (e) => {
          this.usernameError = false;
          this.passwordError = false;
          if (e.error.error_description === "USER_NOT_EXIST") {
            this.usernameError = true;
          }

          if (e.error.error_description === "PASSWORD_INCORRECT") {
            this.passwordError = true;
          }

          this.hasError = false;
          this.authService.isLoadingSubject.next(false);
        }
      );
    this.unsubscribe.push(loginSubscr);
  }

  ngOnDestroy() {
    this.unsubscribe.forEach((sb) => sb.unsubscribe());
  }
}
