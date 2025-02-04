import { Component, Injector, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule, FormsModule } from "@angular/forms";
import { TranslateDirective, TranslatePipe } from "@ngx-translate/core";
import { NgFor, NgIf } from "@angular/common";
import { ToastModule } from "primeng/toast";

import { BaseComponent } from "src/app/core/Components/base/base.component";
import { ValidationAlertsComponent } from "src/app/core/Components/validation-alerts/validation-alerts.component";

import { AddPackageDto, CoreService } from "src/app/services/CoreService";
import { LookupDropdownComponent } from "src/app/modules/shared/lookup-dropdown/lookup-dropdown.component";
import { LookupMultiSelectComponent } from "src/app/modules/shared/lookup-multi-select/lookup-multi-select.component";

@Component({
  selector: "app-package-create",
  standalone: true,
  imports: [
    FormsModule,
    ReactiveFormsModule,
    ToastModule,
    TranslateDirective,
    TranslatePipe,
    NgIf,
    NgFor,
    ValidationAlertsComponent,
    LookupDropdownComponent,
    LookupMultiSelectComponent
  ],
  templateUrl: "./package-create.component.html",
  providers: [CoreService]
})
export class PackageCreateComponent extends BaseComponent implements OnInit {
  packageForm!: FormGroup;

  constructor(private injector: Injector, private fb: FormBuilder, private service: CoreService) {
    super(injector);
  }

  ngOnInit(): void {
    this.initForm();
  }

  private initForm() {
    this.packageForm = this.fb.group({
      name: ["", [Validators.required, Validators.minLength(2), Validators.maxLength(100)]],
      nameAr: ["", [Validators.required, Validators.minLength(2), Validators.maxLength(100)]],
      description: ["", [Validators.required, Validators.minLength(2), Validators.maxLength(300)]],
      descriptionAr: ["", [Validators.required, Validators.minLength(2), Validators.maxLength(300)]],
      defaultDiscount: [0, [Validators.required, Validators.pattern(/^\d+(\.\d{1,2})?$/)]],
      writtenServices: ["", Validators.required],
      maxBranchUsers: [0, [Validators.required, Validators.pattern(/^[0-9]+$/)]],
      maxMogdiPlatformUsage: [0, [Validators.required, Validators.pattern(/^[0-9]+$/)]],

      packageFacilities: [[], Validators.required]
    });
  }

  onSubmit(action: "new" | "redirect") {
    if (this.packageForm.valid) {
      const formValue = this.packageForm.value;

      const createDto: any = {
        name: formValue.name,
        nameAr: formValue.nameAr,
        description: formValue.description,
        descriptionAr: formValue.descriptionAr,
        defaultDiscount: formValue.defaultDiscount,
        writtenServices: formValue.writtenServices,
        maxBranchUsers: formValue.maxBranchUsers,
        maxMogdiPlatformUsage: formValue.maxMogdiPlatformUsage,
        packageFacilities: formValue.packageFacilities
      };

      this.service.createPackage(createDto).subscribe({
        next: (res) => {
          if (res.isSuccess) {
            this.ct.sendToaster("info", this.tr.get("SHARED.ServerDetails"), res.message);
            this.handlePostSubmit(action);
          } else {
            this.ct.sendToaster("error", this.tr.get("SHARED.ServerDetails"), res.message);
          }
        },
        error: (err) => {
          console.error(err);
          this.ct.sendToaster("error", this.tr.get("SHARED.ServerDetails"), err.message);
        }
      });
    } else {
      this.logValidationErrors();
    }
  }

  private handlePostSubmit(action: "new" | "redirect") {
    switch (action) {
      case "new":
        this.packageForm.reset();
        break;
      case "redirect":
        this.router.navigate(["/package/package-list"]);
        break;
    }
  }

  logValidationErrors() {
    Object.keys(this.packageForm.controls).forEach((key) => {
      const control = this.packageForm.get(key);
      if (control?.errors) {
        console.error(`Validation errors for ${key}:`, control.errors);
      }
    });
  }

  onReset() {
    this.packageForm.reset();
  }
}
