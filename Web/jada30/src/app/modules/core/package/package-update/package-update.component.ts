import { Component, Injector, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, FormArray, Validators, ReactiveFormsModule } from "@angular/forms";
import { ActivatedRoute } from "@angular/router";
import { NgIf } from "@angular/common";
import { TranslatePipe } from "@ngx-translate/core";

import { BaseComponent } from "src/app/core/Components/base/base.component";
import { ValidationAlertsComponent } from "src/app/core/Components/validation-alerts/validation-alerts.component";
import { AddPackageDto, AddPackageFacilityDto, CoreService, GetPackageDto } from "src/app/services/CoreService";
import { TranslationModule } from "src/app/modules/i18n";

@Component({
  selector: "app-package-update",
  standalone: true,
  imports: [ReactiveFormsModule, TranslationModule, ValidationAlertsComponent, NgIf],
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
    this.packageId = +this.route.snapshot.params["id"];
    this.initForm();
    this.loadPackageData();
  }

  private initForm() {
    this.packageForm = this.fb.group({
      id: [null],
      name: ["", [Validators.required, Validators.minLength(2), Validators.maxLength(100)]],
      nameAr: ["", [Validators.required, Validators.minLength(2), Validators.maxLength(100)]],
      description: ["", [Validators.required, Validators.maxLength(300)]],
      descriptionAr: ["", [Validators.required, Validators.maxLength(300)]],
      defaultDiscount: [0, [Validators.required]],
      writtenServices: ["", [Validators.required]],
      maxBranchUsers: [0, [Validators.required]],
      maxMogdiPlatformUsage: [0, [Validators.required]],

      // FormArray for facilities
      packageFacilities: this.fb.array([])
    });
  }

  get facilitiesArray(): FormArray {
    return this.packageForm.get("packageFacilities") as FormArray;
  }

  // Utility to create a new facility form group
  private createFacilityGroup(fac?: any) {
    // 'fac' can be a facility from the API (GetPackageFacilityDto)
    return this.fb.group({
      facilityId: [fac?.facilityId || null, Validators.required],
      typeId: [fac?.typeId || null, Validators.required],
      quantity: [fac?.quantity || 0, Validators.required],
      percentageDicount: [fac?.percentageDicount || 0],
      price: [fac?.price || 0],
      isTaxIncluded: [fac?.isTaxIncluded || false]
    });
  }

  loadPackageData() {
    this.service.getPackage(this.packageId).subscribe({
      next: (res) => {
        if (res.isSuccess && res.responseData) {
          const pkg: GetPackageDto = res.responseData;
          // Patch base fields
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
          });

          // Clear existing facility rows (if any)
          this.facilitiesArray.clear();

          // Populate facility rows
          pkg.packageFacilities!.forEach((f) => {
            this.facilitiesArray.push(
              this.createFacilityGroup({
                facilityId: f.id,
                typeId: 0, //f.typeId,
                quantity: f.quantity,
                percentageDicount: f.percentageDicount,
                price: f.price,
                isTaxIncluded: f.isTaxIncluded
              })
            );
          });
        } else {
          this.ct.sendToaster("error", this.tr.get("SHARED.ServerDetails"), res.message);
        }
      },
      error: (err) => console.error(err)
    });
  }

  addFacilityRow() {
    this.facilitiesArray.push(this.createFacilityGroup());
  }

  removeFacilityRow(index: number) {
    this.facilitiesArray.removeAt(index);
  }

  onSubmit() {
    if (this.packageForm.valid) {
      const formValue = this.packageForm.value;

      // 1) Create an instance of AddPackageDto
      const updateDto = new AddPackageDto();
      updateDto.name = formValue.name;
      updateDto.nameAr = formValue.nameAr;
      updateDto.description = formValue.description;
      updateDto.descriptionAr = formValue.descriptionAr;
      updateDto.defaultDiscount = formValue.defaultDiscount;
      updateDto.writtenServices = formValue.writtenServices;
      updateDto.maxBranchUsers = formValue.maxBranchUsers;
      updateDto.maxMogdiPlatformUsage = formValue.maxMogdiPlatformUsage;

      // 2) Build the array of AddPackageFacilityDto
      const facilitiesArray = formValue.packageFacilities.map((f: any) => {
        const facility = new AddPackageFacilityDto();
        facility.packageId = this.packageId; // or 0, depending on your logic
        facility.facilityId = f.facilityId;
        facility.typeId = f.typeId;
        facility.quantity = f.quantity;
        facility.percentageDicount = f.percentageDicount;
        facility.price = f.price;
        facility.isTaxIncluded = f.isTaxIncluded;
        return facility;
      });

      updateDto.packageFacilities = facilitiesArray;

      // 3) Now call your service
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
