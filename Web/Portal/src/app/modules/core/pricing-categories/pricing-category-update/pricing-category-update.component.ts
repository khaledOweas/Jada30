import { NgIf } from "@angular/common";
import { Component, Injector, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { TranslateDirective, TranslatePipe } from "@ngx-translate/core";
import { MultiSelectModule } from "primeng/multiselect";
import { PasswordModule } from "primeng/password";
import { ToastModule } from "primeng/toast";
import { BaseComponent } from "src/app/core/Components/base/base.component";
import { LookupMultiSelectComponent } from "src/app/modules/shared/lookup-multi-select/lookup-multi-select.component";
import { AddPriceCategory, CoreService, GetPriceCategoryBaseResponse } from "src/app/services/CoreService";

@Component({
  selector: "app-pricing-category-update",
  standalone: true,
  imports: [
    FormsModule,
    ReactiveFormsModule,
    ToastModule,
    TranslateDirective,
    NgIf,
    MultiSelectModule,
    TranslatePipe,
    PasswordModule,
    LookupMultiSelectComponent
  ],
  templateUrl: "./pricing-category-update.component.html",
  styleUrl: "./pricing-category-update.component.scss",
  providers: [CoreService]
})
export class PricingCategoryUpdateComponent extends BaseComponent implements OnInit {
  pricingCategoryForm: FormGroup;
  id: number;

  constructor(
    private injector: Injector,
    private fb: FormBuilder,
    private service: CoreService,
    private route: ActivatedRoute
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.initializeForm();
    this.route.paramMap.subscribe((params) => {
      this.id = +params.get("id")!;
      if (this.id) {
        this.loadPricingCategory();
      }
    });
  }

  initializeForm(): void {
    this.pricingCategoryForm = this.fb.group({
      name: ["", Validators.required],
      nameAr: ["", Validators.required],
      description: [""],
      descriptionAr: [""],
      price: [null, Validators.required],
      categoryAdministrativeRegionIds: [[], Validators.required],
      isActive: [true]
    });
  }

  loadPricingCategory(): void {
    this.service.getPriceCategory(this.id).subscribe({
      next: (res: GetPriceCategoryBaseResponse) => {
        if (res.isSuccess) {
          this.pricingCategoryForm.patchValue({
            ...res.responseData,
            isActive: res.responseData!.isPublish,
            categoryAdministrativeRegionIds: res.responseData!.categoryAdministrativeRegions?.map((x) => x.administrativeRegionId!)!
          });
          debugger;
        } else {
          this.ct.sendToaster("error", this.tr.get("SHARED.ServerDetails"), res.message!);
        }
      },
      error: (err) => {
        this.ct.sendToaster("error", this.tr.get("SHARED.ServerDetails"), this.tr.get("SHARED.ErrorOccurred"));
      }
    });
  }

  onSubmit(): void {
    debugger;
    if (this.pricingCategoryForm.valid) {
      const data = this.pricingCategoryForm.value;
      const model: AddPriceCategory = new AddPriceCategory(data);

      this.service.updatePriceCategory(this.id, model).subscribe({
        next: (res: GetPriceCategoryBaseResponse) => {
          if (res.isSuccess) {
            this.ct.sendToaster("info", this.tr.get("SHARED.ServerDetails"), res.message);
            this.router.navigate(["/pricing-category/pricing-category-list"]);
          } else {
            res.errors!.forEach((element) => {
              this.ct.sendToaster("error", this.tr.get("SHARED.ServerDetails"), res.message! + element.value!);
            });
          }
        },
        error: (err) => {
          this.ct.sendToaster("error", this.tr.get("SHARED.ServerDetails"), this.tr.get("SHARED.ErrorOccurred"));
        }
      });
    }
  }

  onCancel(): void {
    this.router.navigate(["/pricing-category/pricing-category-list"]);
  }
}
