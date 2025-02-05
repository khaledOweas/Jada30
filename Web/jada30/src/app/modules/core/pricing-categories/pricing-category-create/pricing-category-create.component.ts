import { NgIf } from "@angular/common";
import { Component, Injector, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from "@angular/forms";
import { ActivatedRoute } from "@angular/router";
import { TranslateDirective, TranslatePipe } from "@ngx-translate/core";
import { MultiSelectModule } from "primeng/multiselect";
import { PasswordModule } from "primeng/password";
import { ToastModule } from "primeng/toast";
import { BaseComponent } from "src/app/core/Components/base/base.component";
import { AddPriceCategory, CoreService, GetPriceCategoryBaseResponse } from "src/app/services/CoreService";
import { LookupService, AddLookupDto, GetLookupDtoBaseResponse } from "src/app/services/LookupService";

@Component({
  selector: "app-pricing-category-create",
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
  templateUrl: "./pricing-category-create.component.html",
  styleUrl: "./pricing-category-create.component.scss",
  providers: [CoreService]
})
export class PricingCategoryCreateComponent extends BaseComponent implements OnInit {
  pricingCategoryForm: FormGroup;

  constructor(
    private injector: Injector,
    private fb: FormBuilder,
    private service: CoreService,
    private route: ActivatedRoute
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.pricingCategoryForm = this.fb.group({
      name: ["", Validators.required],
      nameAr: ["", Validators.required],
      description: [""],
      descriptionAr: [""],
      price: [null, Validators.required],
      isActive: [true]
    });
  }

  onSubmit(action: "new" | "redirect") {
    if (this.pricingCategoryForm.valid) {
      const data = this.pricingCategoryForm.value;
      const model: AddPriceCategory = new AddPriceCategory(data);
      this.service.addPriceCategory(model).subscribe({
        next: (res: GetPriceCategoryBaseResponse) => {
          if (res.isSuccess) {
            this.ct.sendToaster("info", this.tr.get("SHARED.ServerDetails"), res.message);
            switch (action) {
              case "new":
                this.onReset();
                break;
              case "redirect":
                this.router.navigate(["/pricing-category/pricing-category-list"]);
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
    }
  }

  onReset() {
    this.pricingCategoryForm = this.fb.group({
      name: ["", Validators.required],
      nameAr: ["", Validators.required],
      description: [""],
      descriptionAr: [""],
      price: [null, Validators.required],
      isActive: [true]
    });
  }
}
