import { Component, Injector, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, FormArray, Validators, FormControl, ReactiveFormsModule } from "@angular/forms";
import { ActivatedRoute } from "@angular/router";
import { NgFor, NgIf } from "@angular/common";
import { TranslatePipe } from "@ngx-translate/core";

import { BaseComponent } from "src/app/core/Components/base/base.component";
import { ValidationAlertsComponent } from "src/app/core/Components/validation-alerts/validation-alerts.component";
import {
  AddPackageDto,
  AddPackageFacilityDto,
  CoreService,
  GetPackageDto,
  GetPackageFacilityDto
} from "src/app/services/CoreService";
import { TranslationModule } from "src/app/modules/i18n";
import { LookupDropdownComponent } from "src/app/modules/shared/lookup-dropdown/lookup-dropdown.component";
import { FacilityDropdownComponent } from "../../facilities/facility-dropdown/facility-dropdown.component";

interface FacilityForm {
  facilityId: FormControl<number | null>;
  typeId: FormControl<number | null>;
  quantity: FormControl<number | null>;
  percentageDicount: FormControl<number | null>;
  price: FormControl<number | null>;
  isTaxIncluded: FormControl<boolean | null>;
}

interface PackageFormModel {
  id: FormControl<number | null>;
  name: FormControl<string>;
  nameAr: FormControl<string>;
  description: FormControl<string>;
  descriptionAr: FormControl<string>;
  defaultDiscount: FormControl<number>;
  writtenServices: FormControl<string>;
  maxBranchUsers: FormControl<number>;
  maxMogdiPlatformUsage: FormControl<number>;
  packageFacilities: FormArray<FormGroup<FacilityForm>>;
}

@Component({
  selector: "app-package-update",
  standalone: true,
  imports: [
    ReactiveFormsModule,
    TranslationModule,
    ValidationAlertsComponent,
    NgIf,
    NgFor,
    TranslatePipe,
    LookupDropdownComponent,
    FacilityDropdownComponent
  ],
  templateUrl: "./package-update.component.html",
  providers: [CoreService]
})
export class PackageUpdateComponent extends BaseComponent implements OnInit {
  packageForm!: FormGroup<PackageFormModel>;
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
    // 1) Grab ID from URL
    this.packageId = +this.route.snapshot.params["id"];
    this.initForm();
    this.loadPackageData();
  }

  private initForm() {
    // 2) Typed form group
    this.packageForm = this.fb.group<PackageFormModel>({
      id: this.fb.control<number | null>(null),
      name: this.fb.control<string>("", {
        validators: [Validators.required, Validators.minLength(2), Validators.maxLength(100)],
        nonNullable: true
      }),
      nameAr: this.fb.control<string>("", {
        validators: [Validators.required, Validators.minLength(2), Validators.maxLength(100)],
        nonNullable: true
      }),
      description: this.fb.control<string>("", {
        validators: [Validators.required, Validators.maxLength(300)],
        nonNullable: true
      }),
      descriptionAr: this.fb.control<string>("", {
        validators: [Validators.required, Validators.maxLength(300)],
        nonNullable: true
      }),
      defaultDiscount: this.fb.control<number>(0, {
        validators: [Validators.required],
        nonNullable: true
      }),
      writtenServices: this.fb.control<string>("", {
        validators: [Validators.required],
        nonNullable: true
      }),
      maxBranchUsers: this.fb.control<number>(0, {
        validators: [Validators.required],
        nonNullable: true
      }),
      maxMogdiPlatformUsage: this.fb.control<number>(0, {
        validators: [Validators.required],
        nonNullable: true
      }),
      // 3) FormArray of facility subgroups
      packageFacilities: this.fb.array<FormGroup<FacilityForm>>([])
    });
  }

  // Convenient getter for packageFacilities array
  get facilitiesArray(): FormArray<FormGroup<FacilityForm>> {
    return this.packageForm.controls.packageFacilities;
  }

  // 4) Create a facility row from an optional GetPackageFacilityDto
  private createFacilityGroup(fac?: Partial<GetPackageFacilityDto>): FormGroup<FacilityForm> {
    return this.fb.group<FacilityForm>({
      facilityId: this.fb.control<number | null>(fac?.facilityId ?? null, [Validators.required]),
      typeId: this.fb.control<number | null>(fac?.typeId ?? null, [Validators.required]),
      quantity: this.fb.control<number | null>(fac?.quantity ?? 0, [Validators.required]),
      percentageDicount: this.fb.control<number | null>(fac?.percentageDicount ?? 0),
      price: this.fb.control<number | null>(fac?.price ?? 0),
      isTaxIncluded: this.fb.control<boolean | null>(fac?.isTaxIncluded ?? false)
    });
  }

  // 5) Load data from backend
  loadPackageData() {
    this.service.getPackage(this.packageId).subscribe({
      next: (res) => {
        if (res.isSuccess && res.responseData) {
          const pkg: GetPackageDto = res.responseData;

          // 6) Patch main package data
          this.packageForm.patchValue({
            id: pkg.id,
            name: pkg.name ?? "",
            nameAr: pkg.nameAr ?? "",
            description: pkg.description ?? "",
            descriptionAr: pkg.descriptionAr ?? "",
            defaultDiscount: pkg.defaultDiscount ?? 0,
            writtenServices: pkg.writtenServices ?? "",
            maxBranchUsers: pkg.maxBranchUsers ?? 0,
            maxMogdiPlatformUsage: pkg.maxMogdiPlatformUsage ?? 0
          });

          // 7) Clear existing array
          this.facilitiesArray.clear();

          // 8) Insert each facility into the form array
          pkg.packageFacilities?.forEach((f: GetPackageFacilityDto) => {
            // Make sure to use the actual "facilityId" & "typeId" from your API
            debugger;
            this.facilitiesArray.push(
              this.createFacilityGroup({
                facilityId: f.facilityId,
                typeId: f.typeId,
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

  // 9) Add or remove facility rows
  addFacilityRow() {
    this.facilitiesArray.push(this.createFacilityGroup());
  }

  removeFacilityRow(index: number) {
    this.facilitiesArray.removeAt(index);
  }

  // 10) Submit updates
  onSubmit() {
    if (this.packageForm.valid) {
      const formValue = this.packageForm.value;

      // 11) Build final update DTO
      const updateDto = new AddPackageDto({
        name: formValue.name,
        nameAr: formValue.nameAr,
        description: formValue.description,
        descriptionAr: formValue.descriptionAr,
        defaultDiscount: formValue.defaultDiscount,
        writtenServices: formValue.writtenServices,
        maxBranchUsers: formValue.maxBranchUsers,
        maxMogdiPlatformUsage: formValue.maxMogdiPlatformUsage,
        packageFacilities: formValue.packageFacilities!.map((f) => {
          return new AddPackageFacilityDto({
            packageId: this.packageId, // or 0 if your backend doesn't need it
            facilityId: f.facilityId ?? 0,
            typeId: f.typeId ?? 0,
            quantity: f.quantity ?? 0,
            percentageDicount: f.percentageDicount ?? 0,
            price: f.price ?? 0,
            isTaxIncluded: f.isTaxIncluded ?? false
          });
        })
      });

      // 12) Send to backend
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
