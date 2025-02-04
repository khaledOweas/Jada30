import { Component, Injector, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { BaseComponent } from "src/app/core/Components/base/base.component";
import { CoreService, CreateFacilityDto } from "src/app/services/CoreService";
import { TranslateDirective, TranslateModule } from "@ngx-translate/core";
import { ToastModule } from "primeng/toast";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { NgIf } from "@angular/common";
import { LookupDropdownComponent } from "../../../shared/lookup-dropdown/lookup-dropdown.component";
import { ValidationAlertsComponent } from "src/app/core/Components/validation-alerts/validation-alerts.component";

@Component({
  selector: "app-facility-create",
  standalone: true,
  templateUrl: "./facility-create.component.html",
  imports: [
    FormsModule,
    ReactiveFormsModule,
    ToastModule,
    TranslateDirective,
    ValidationAlertsComponent,
    NgIf,
    LookupDropdownComponent,
    TranslateModule
  ],
  providers: [CoreService]
})
export class FacilityCreateComponent extends BaseComponent implements OnInit {
  facilityForm: FormGroup;

  constructor(private injector: Injector, private fb: FormBuilder, private service: CoreService) {
    super(injector);

    this.facilityForm = this.fb.group({
      name: ["", Validators.required],
      nameAr: ["", Validators.required],
      categoryId: [null, [Validators.required, Validators.pattern(/^[0-9]+$/)]],
      typeId: [null, [Validators.required, Validators.pattern(/^[0-9]+$/)]],
      destinationId: [null, [Validators.required, Validators.pattern(/^[0-9]+$/)]],
      pricingUnitId: [null, [Validators.required, Validators.pattern(/^[0-9]+$/)]],
      subscriptionId: [null, [Validators.required, Validators.pattern(/^[0-9]+$/)]],
      basePrice: [0, Validators.required],
      isTaxIncluded: [false],
      basicContract: [null, [Validators.required, Validators.pattern(/^[0-9]+$/)]],
      isPublish: [false]
    });
  }

  ngOnInit(): void {}

  onSubmit(action: "new" | "redirect") {
    if (this.facilityForm.valid) {
      const formValue = this.facilityForm.value;
      const createDto = CreateFacilityDto.fromJS({
        name: formValue.name,
        nameAr: formValue.nameAr,
        categoryId: +formValue.categoryId,
        typeId: +formValue.typeId,
        destinationId: +formValue.destinationId,
        pricingUnitId: +formValue.pricingUnitId,
        subscriptionId: +formValue.subscriptionId,
        basePrice: +formValue.basePrice,
        isTaxIncluded: formValue.isTaxIncluded,
        basicContract: +formValue.basicContract,
        isPublish: formValue.isPublish
      });

      this.service.createFacility(createDto).subscribe({
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
          this.ct.sendToaster("error", this.tr.get("SHARED.ServerDetails"), "Something went wrong!");
        }
      });
    } else {
      this.logValidationErrors();
    }
  }

  handlePostSubmit(action: "new" | "redirect") {
    switch (action) {
      case "new":
        this.facilityForm.reset();
        break;
      case "redirect":
        this.router.navigate(["/facility/facility-list"]);
        break;
    }
  }

  onReset() {
    this.facilityForm.reset();
  }

  logValidationErrors() {
    Object.keys(this.facilityForm.controls).forEach((key) => {
      const control = this.facilityForm.get(key);
      if (control?.errors) {
        console.error(`Validation errors for ${key}:`, control.errors);
      }
    });
  }

  objectKeys(obj: any): string[] {
    return Object.keys(obj);
  }

  trackByFn(index: number, item: any) {
    return index;
  }
}
