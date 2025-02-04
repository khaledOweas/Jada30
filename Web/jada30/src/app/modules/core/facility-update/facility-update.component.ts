import { Component, Injector, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute } from "@angular/router";
import { BaseComponent } from "src/app/core/Components/base/base.component";
import { CoreService, FacilityDto } from "src/app/services/CoreService";
import { LookupDropdownComponent } from "../../shared/lookup-dropdown/lookup-dropdown.component";
import { ValidationAlertsComponent } from "src/app/core/Components/validation-alerts/validation-alerts.component";
import { TranslateModule, TranslatePipe } from "@ngx-translate/core";
import { NgIf } from "@angular/common";
import { ToastModule } from "primeng/toast";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";

@Component({
  selector: "app-facility-update",
  standalone: true,
  imports: [
    FormsModule,
    ReactiveFormsModule,
    ToastModule,
    TranslatePipe,
    ValidationAlertsComponent,
    NgIf,
    LookupDropdownComponent,
    TranslateModule
  ],
  templateUrl: "./facility-update.component.html",
  styleUrl: "./facility-update.component.scss",
  providers: [CoreService]
})
export class FacilityUpdateComponent extends BaseComponent implements OnInit {
  facilityForm: FormGroup;
  facilityId: number;

  constructor(
    private injector: Injector,
    private fb: FormBuilder,
    private service: CoreService,
    private route: ActivatedRoute
  ) {
    super(injector);
    this.facilityForm = this.fb.group({
      id: [null],
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
    this.facilityId = this.route.snapshot.params["id"];
  }

  ngOnInit(): void {
    this.loadFacilityData();
  }

  loadFacilityData() {
    this.service.getFacility(this.facilityId).subscribe({
      next: (res) => {
        if (res.isSuccess) {
          const facility = res.responseData!;
          this.facilityForm.patchValue({
            id: facility.id,
            name: facility.name,
            nameAr: facility.nameAr,
            categoryId: facility.categoryId,
            typeId: facility.typeId,
            destinationId: facility.destinationId,
            pricingUnitId: facility.pricingUnitId,
            subscriptionId: facility.subscriptionId,
            basePrice: facility.basePrice,
            isTaxIncluded: facility.isTaxIncluded,
            basicContract: facility.basicContract,
            isPublish: facility.isPublish
          });
        }
      },
      error: (err) => console.error(err)
    });
  }

  onSubmit() {
    if (this.facilityForm.valid) {
      const formValue = this.facilityForm.value;
      const updateDto = FacilityDto.fromJS({
        id: this.facilityId,
        ...formValue,
        categoryId: +formValue.categoryId,
        typeId: +formValue.typeId,
        destinationId: +formValue.destinationId,
        pricingUnitId: +formValue.pricingUnitId,
        subscriptionId: +formValue.subscriptionId,
        basicContract: +formValue.basicContract
      });

      this.service.updateFacility(this.facilityId, updateDto).subscribe({
        next: (res) => {
          if (res.isSuccess) {
            this.ct.sendToaster("info", this.tr.get("SHARED.ServerDetails"), res.message);
            this.router.navigate(["/facility/facility-list"]);
          }
        },
        error: (err) => console.error(err)
      });
    } else {
      this.logValidationErrors();
    }
  }

  logValidationErrors() {
    Object.keys(this.facilityForm.controls).forEach((key) => {
      const control = this.facilityForm.get(key);
      if (control?.errors) {
        console.error(`Validation errors for ${key}:`, control.errors);
      }
    });
  }

  onReturn() {
    this.router.navigate(["/facility/facility-list"]);
  }
}
