import { Component, Injector, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from "@angular/forms";
import { ActivatedRoute } from "@angular/router";
import { NgIf } from "@angular/common";
import { TranslatePipe } from "@ngx-translate/core";

import { BaseComponent } from "src/app/core/Components/base/base.component";
import { ValidationAlertsComponent } from "src/app/core/Components/validation-alerts/validation-alerts.component";
import { CoreService, GetPackageDto, GetPackageDtoBaseResponse } from "src/app/services/CoreService";

@Component({
  selector: "app-package-update",
  standalone: true,
  imports: [ReactiveFormsModule, TranslatePipe, NgIf, ValidationAlertsComponent],
  templateUrl: "./package-update.component.html",
  providers: [CoreService]
})
export class PackageUpdateComponent extends BaseComponent implements OnInit {
  packageForm!: FormGroup;
  packageId!: number;

  constructor(
    private injector: Injector,
    private fb: FormBuilder,
    private service: CoreService,
    private route: ActivatedRoute
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.packageId = this.route.snapshot.params["id"];
    this.initForm();
    this.loadPackageData();
  }

  private initForm() {
    this.packageForm = this.fb.group({
      id: [null],
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

  loadPackageData() {
    this.service.getPackage(this.packageId).subscribe({
      next: (res: GetPackageDtoBaseResponse) => {
        if (res.isSuccess && res.responseData) {
          const pkg: GetPackageDto = res.responseData;
          // Patch form
          this.packageForm.patchValue({
            id: pkg.id,
            name: pkg.name,
            nameAr: pkg.nameAr,
            description: pkg.description,
            descriptionAr: pkg.descriptionAr,
            defaultDiscount: pkg.defaultDiscount,
            writtenServices: pkg.writtenServices,
            maxBranchUsers: pkg.maxBranchUsers,
            maxMogdiPlatformUsage: pkg.maxMogdiPlatformUsage
            // If needed for facilities, map them
            // packageFacilities: pkg.packageFacilities.map(...)
          });
        } else {
          this.ct.sendToaster("error", this.tr.get("SHARED.ServerDetails"), res.message);
        }
      },
      error: (err) => console.error(err)
    });
  }

  onSubmit() {
    if (this.packageForm.valid) {
      const formValue = this.packageForm.value;
      const updateDto: any = {
        name: formValue.name,
        nameAr: formValue.nameAr,
        description: formValue.description,
        descriptionAr: formValue.descriptionAr,
        defaultDiscount: Number(formValue.defaultDiscount),
        writtenServices: formValue.writtenServices,
        maxBranchUsers: Number(formValue.maxBranchUsers),
        maxMogdiPlatformUsage: Number(formValue.maxMogdiPlatformUsage),
        packageFacilities: []
      };

      this.service.updatePackage(this.packageId, updateDto).subscribe({
        next: (res) => {
          if (res.isSuccess) {
            this.ct.sendToaster("info", this.tr.get("SHARED.ServerDetails"), res.message);
            this.router.navigate(["/package/package-list"]);
          } else {
            this.ct.sendToaster("error", this.tr.get("SHARED.ServerDetails"), res.message);
          }
        },
        error: (err) => console.error(err)
      });
    } else {
      this.logValidationErrors();
    }
  }

  onReturn() {
    this.router.navigate(["/package/package-list"]);
  }

  logValidationErrors() {
    Object.keys(this.packageForm.controls).forEach((key) => {
      const control = this.packageForm.get(key);
      if (control?.errors) {
        console.error(`Validation errors for ${key}:`, control.errors);
      }
    });
  }
}
