import { Component, Injector, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, FormArray, Validators, FormControl, ReactiveFormsModule } from "@angular/forms";
import { NgFor, NgIf } from "@angular/common";

import { BaseComponent } from "src/app/core/Components/base/base.component";
import { ValidationAlertsComponent } from "src/app/core/Components/validation-alerts/validation-alerts.component";
import {
  AddPackageDto,
  AddPackageFacilityDto,
  CoreService,
  FacilityDto,
  FacilityDtoListBaseResponse
} from "src/app/services/CoreService";
import { TranslationModule } from "src/app/modules/i18n";
import { DropdownModule } from "primeng/dropdown";
import { takeUntil } from "rxjs";
import { LookupDropdownComponent } from "../../../shared/lookup-dropdown/lookup-dropdown.component";
import { FacilityDropdownComponent } from "../../facilities/facility-dropdown/facility-dropdown.component";

// 1) Define interfaces for the typed form fields
interface FacilityForm {
  facilityId: FormControl<number | null>;
  typeId: FormControl<number | null>;
  quantity: FormControl<number | null>;
  percentageDicount: FormControl<number | null>;
  price: FormControl<number | null>;
  isTaxIncluded: FormControl<boolean | null>;
}

// The entire package form structure
interface PackageFormModel {
  name: FormControl<string>;
  nameAr: FormControl<string>;
  description: FormControl<string>;
  descriptionAr: FormControl<string>;
  defaultDiscount: FormControl<number>;
  writtenServices: FormControl<string>;
  maxBranchUsers: FormControl<number>;
  maxMogdiPlatformUsage: FormControl<number>;
  // A FormArray of FormGroup<FacilityForm>
  packageFacilities: FormArray<FormGroup<FacilityForm>>;
}

@Component({
  selector: "app-package-create",
  standalone: true,
  imports: [
    ReactiveFormsModule,
    ValidationAlertsComponent,
    TranslationModule,
    NgIf,
    NgFor,
    DropdownModule,
    LookupDropdownComponent,
    FacilityDropdownComponent
  ],
  templateUrl: "./package-create.component.html",
  providers: [CoreService]
})
export class PackageCreateComponent extends BaseComponent implements OnInit {
  // 2) Strongly-typed FormGroup
  packageForm!: FormGroup<PackageFormModel>;

  constructor(private injector: Injector, private fb: FormBuilder, private service: CoreService) {
    super(injector);
  }

  ngOnInit(): void {
    this.initForm();
  }

  private initForm() {
    // 3) Build the main form with typed controls
    this.packageForm = this.fb.group<PackageFormModel>({
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
      // 4) Start with an empty FormArray for facilities
      packageFacilities: this.fb.array<FormGroup<FacilityForm>>([])
    });
  }

  // 5) Getter for the FormArray of facility groups
  get facilitiesArray(): FormArray<FormGroup<FacilityForm>> {
    return this.packageForm.controls.packageFacilities;
  }

  // 6) Add a new facility row
  addFacilityRow() {
    const facilityGroup = this.fb.group<FacilityForm>({
      facilityId: this.fb.control<number | null>(null, {
        validators: [Validators.required]
      }),
      typeId: this.fb.control<number | null>(null, {
        validators: [Validators.required]
      }),
      quantity: this.fb.control<number | null>(null, { validators: [Validators.required] }),
      percentageDicount: this.fb.control<number>(0),
      price: this.fb.control<number>(0),
      isTaxIncluded: this.fb.control<boolean | null>(false)
    });

    this.facilitiesArray.push(facilityGroup);
  }

  removeFacilityRow(index: number) {
    this.facilitiesArray.removeAt(index);
  }

  onSubmit(action: "new" | "redirect") {
    // 7) Form is strongly-typed, so .value is also typed
    if (this.packageForm.valid) {
      const formValue = this.packageForm.value;

      // 8) Use the generated class approach if needed
      //    or pass a plain object if the backend doesn't require the class instance.
      //    Here we assume we need to instantiate AddPackageDto with a constructor:
      const createDto = new AddPackageDto({
        name: formValue.name,
        nameAr: formValue.nameAr,
        description: formValue.description,
        descriptionAr: formValue.descriptionAr,
        defaultDiscount: formValue.defaultDiscount,
        writtenServices: formValue.writtenServices,
        maxBranchUsers: formValue.maxBranchUsers,
        maxMogdiPlatformUsage: formValue.maxMogdiPlatformUsage,
        packageFacilities: formValue.packageFacilities!.map(
          (f) =>
            new AddPackageFacilityDto({
              packageId: 0, // The server usually overwrites or doesn't need it
              facilityId: f.facilityId ?? 0, // safe fallback if null
              typeId: f.typeId ?? 0, // safe fallback if null
              quantity: f.quantity ?? 0,
              percentageDicount: f.percentageDicount ?? 0,
              price: f.price ?? 0,
              isTaxIncluded: f.isTaxIncluded ?? false
            })
        )
      });

      // 9) Call your service
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
        // Reset entire form
        this.packageForm.reset();
        // Clear the facilities array
        this.facilitiesArray.clear();
        break;
      case "redirect":
        this.router.navigate(["/package/package-list"]);
        break;
    }
  }

  onReset() {
    this.packageForm.reset();
    this.facilitiesArray.clear();
  }

  logValidationErrors() {
    // Inspect form for validation errors
    Object.keys(this.packageForm.controls).forEach((key) => {
      const control = this.packageForm.get(key);
      if (control?.errors) {
        console.error(`Validation errors for ${key}:`, control.errors);
      }
    });
  }
}
