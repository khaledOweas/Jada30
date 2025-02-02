import { NgIf } from "@angular/common";
import { Component, Injector, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from "@angular/forms";
import { ActivatedRoute } from "@angular/router";
import { TranslateDirective, TranslatePipe } from "@ngx-translate/core";
import { MultiSelectModule } from "primeng/multiselect";
import { PasswordModule } from "primeng/password";
import { ToastModule } from "primeng/toast";
import { BaseComponent } from "src/app/core/Components/base/base.component";
import { LookupService, AddLookupDto, GetLookupDtoBaseResponse } from "src/app/services/LookupService";

@Component({
  selector: "app-lookup-create",
  standalone: true,
  imports: [
    FormsModule,
    ReactiveFormsModule,
    ToastModule,
    TranslateDirective,
    NgIf,
    MultiSelectModule,
    TranslatePipe,
    PasswordModule
  ],
  providers: [LookupService],
  templateUrl: "./lookup-create.component.html",
  styleUrl: "./lookup-create.component.css"
})
export class LookupCreateComponent extends BaseComponent implements OnInit {
  lookupForm: FormGroup;
  code: string = "";

  constructor(
    private injector: Injector,
    private fb: FormBuilder,
    private service: LookupService,
    private route: ActivatedRoute
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.code = this.route.snapshot.params["code"];
    this.lookupForm = this.fb.group({
      name: ["", Validators.required],
      nameAr: ["", Validators.required],
      description: [""],
      descriptionAr: [""],
      internalCode: ["", Validators.required],
      internalRef: [this.code],
      isActive: [true]
    });
    this.subscribeToNameChange();
  }

  onSubmit(action: "new" | "redirect") {
    if (this.lookupForm.valid) {
      const data = this.lookupForm.value;
      const model: AddLookupDto = new AddLookupDto(data);
      model.internalRef = this.code === "all" ? undefined : this.code;
      this.service.createLookup(model).subscribe({
        next: (res: GetLookupDtoBaseResponse) => {
          if (res.isSuccess) {
            this.ct.sendToaster("info", this.tr.get("SHARED.ServerDetails"), res.message);
            switch (action) {
              case "new":
                this.onReset();
                break;
              case "redirect":
                this.router.navigate(["/lookups/lookup-list", this.code]);
                break;
              default:
                break;
            }
          } else {
            res.errors!.forEach((element) => {
              this.ct.sendToaster("error", this.tr.get("SHARED.ServerDetails"), res.message! + element.value!);
            });
          }
        },
        error: () => {}
      });
    } else {
      this.logValidationErrors();
    }
  }

  logValidationErrors() {
    Object.keys(this.lookupForm.controls).forEach((key) => {
      const controlErrors = this.lookupForm.get(key)?.errors;
      if (controlErrors) {
        console.error(`Validation errors for ${key}:`, controlErrors);
      }
    });
  }

  subscribeToNameChange() {
    this.lookupForm.get("name")?.valueChanges.subscribe((value) => {
      const internalCodeControl = this.lookupForm.get("internalCode");
      if (value) {
        internalCodeControl?.setValue(value.replace(/\s+/g, "_"), { emitEvent: false });
        internalCodeControl?.markAsTouched();
        internalCodeControl?.updateValueAndValidity();
      }
    });
  }
  onReset() {
    this.lookupForm = this.fb.group({
      name: ["", Validators.required],
      nameAr: ["", Validators.required],
      description: [""],
      descriptionAr: [""],
      internalCode: ["", Validators.required],
      internalRef: [this.code],
      isActive: [true]
    });
    this.subscribeToNameChange();
  }
}
