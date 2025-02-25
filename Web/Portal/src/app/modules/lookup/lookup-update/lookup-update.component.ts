import { NgIf } from "@angular/common";
import { Component, Injector, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from "@angular/forms";
import { ActivatedRoute } from "@angular/router";
import { TranslateDirective } from "@ngx-translate/core";
import { ToastModule } from "primeng/toast";
import { BaseComponent } from "src/app/core/Components/base/base.component";
import { LookupService, UpdateLookupDto, GetLookupDtoBaseResponse } from "src/app/services/LookupService";

@Component({
  selector: "app-lookup-update",
  standalone: true,
  imports: [ToastModule, TranslateDirective, FormsModule, ReactiveFormsModule, NgIf],
  providers: [LookupService],
  templateUrl: "./lookup-update.component.html",
  styleUrl: "./lookup-update.component.css"
})
export class LookupUpdateComponent extends BaseComponent implements OnInit {
  lookupForm: FormGroup;
  code: string;
  refCode: string;

  constructor(
    private injector: Injector,
    private fb: FormBuilder,
    private service: LookupService,
    private route: ActivatedRoute
  ) {
    super(injector);
    this.lookupForm = this.fb.group({
      id: [null],
      name: ["", Validators.required],
      nameAr: ["", Validators.required],
      description: [""],
      descriptionAr: [""],
      internalCode: ["", Validators.required],
      internalRef: [""],
      isActive: []
    });
    this.code = this.route.snapshot.params["code"];
  }

  ngOnInit(): void {
    this.loadLookupData();
  }

  loadLookupData() {
    this.service.get(this.code).subscribe({
      next: (res: GetLookupDtoBaseResponse) => {
        if (res.isSuccess) {
          this.lookupForm.patchValue({
            id: res.responseData!.id,
            name: res.responseData!.name,
            nameAr: res.responseData!.nameAr,
            description: res.responseData!.description,
            descriptionAr: res.responseData!.descriptionAr,
            internalCode: res.responseData!.internalCode,
            internalRef: res.responseData!.internalRef,
            isActive: res.responseData!.isActive
          });

          this.refCode = res.responseData?.internalRef ?? "All";
        } else {
          this.ct.sendToaster("error", this.tr.get("SHARED.ServerDetails"), res.message!);
        }
      },
      error: () => {}
    });
  }

  onSubmit() {
    if (this.lookupForm.valid) {
      const data = this.lookupForm.value;
      const model: UpdateLookupDto = new UpdateLookupDto(data);
      this.service.updateLookup(this.code, model).subscribe({
        next: (res: GetLookupDtoBaseResponse) => {
          if (res.isSuccess) {
            this.ct.sendToaster("info", this.tr.get("SHARED.ServerDetails"), res.message);
            this.router.navigate(["/lookups/lookup-list", this.refCode]);
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

  onReturn() {
    this.router.navigate(["/lookups/lookup-list", this.refCode]);
  }
}
