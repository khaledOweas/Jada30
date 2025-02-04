import { Component, Injector, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from "@angular/forms";
import { ActivatedRoute } from "@angular/router";
import { TranslatePipe } from "@ngx-translate/core";
import { BaseComponent } from "src/app/core/Components/base/base.component";
import { CoreService, CreateBranchDto } from "src/app/services/CoreService";
import { LookupDropdownComponent } from "../../../shared/lookup-dropdown/lookup-dropdown.component";
import { LookupMultiSelectComponent } from "../../../shared/lookup-multi-select/lookup-multi-select.component";
import { ValidationAlertsComponent } from "src/app/core/Components/validation-alerts/validation-alerts.component";
import { NgIf } from "@angular/common";
import { TranslationModule } from "../../../i18n";

@Component({
  selector: "app-branch-update",
  standalone: true,
  imports: [
    LookupDropdownComponent,
    LookupMultiSelectComponent,
    ValidationAlertsComponent,
    TranslatePipe,
    ReactiveFormsModule,
    TranslationModule,
    NgIf
  ],
  providers: [CoreService],
  templateUrl: "./branch-update.component.html"
})
export class BranchUpdateComponent extends BaseComponent implements OnInit {
  branchForm: FormGroup;
  branchId: number;

  constructor(
    private injector: Injector,
    private fb: FormBuilder,
    private service: CoreService,
    private route: ActivatedRoute
  ) {
    super(injector);
    this.branchForm = this.fb.group({
      id: [null],
      name: ["", Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(100)])],
      nameAr: ["", Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(100)])],
      websiteBranchId: [null, Validators.compose([Validators.required, Validators.pattern(/^[0-9]+$/)])],
      workingDays: ["", Validators.required],
      startTime: ["", Validators.required],
      endTime: ["", Validators.required],
      categoryBranchId: [null, Validators.compose([Validators.required, Validators.pattern(/^[0-9]+$/)])],
      branchComponents: [[], Validators.compose([Validators.required])]
    });
    this.branchId = this.route.snapshot.params["id"];
  }

  ngOnInit(): void {
    this.loadBranchData();
  }

  loadBranchData() {
    this.service.branchGET2(this.branchId).subscribe({
      next: (res) => {
        if (res.isSuccess) {
          const branch = res.responseData!;
          this.branchForm.patchValue({
            id: branch.id,
            name: branch.name,
            nameAr: branch.nameAr,
            websiteBranchId: branch.websiteBranchId,
            workingDays: branch.workingDays,
            startTime: this.formatTime(branch.startTime!),
            endTime: this.formatTime(branch.endTime!),
            categoryBranchId: branch.categoryBranchId,
            branchComponents: branch.branchComponents?.map((x) => x.id!)!
          });
        }
      },
      error: (err) => console.error(err)
    });
  }

  onSubmit() {
    if (this.branchForm.valid) {
      const formValue = this.branchForm.value;
      const updateDto: CreateBranchDto = {
        ...formValue,
        startTime: this.convertTimeToDate(formValue.startTime),
        endTime: this.convertTimeToDate(formValue.endTime),
        branchComponents: formValue.branchComponents.map((c: number) => ({
          branchId: this.branchId,
          componentId: c
        }))
      };

      this.service.branchPUT(this.branchId, updateDto).subscribe({
        next: (res) => {
          if (res.isSuccess) {
            this.ct.sendToaster("info", this.tr.get("SHARED.ServerDetails"), res.message);
            this.router.navigate(["/branch/branch-list"]);
          }
        },
        error: (err) => console.error(err)
      });
    } else {
      this.logValidationErrors();
    }
  }

  private formatTime(date: Date): string {
    return date.toISOString().slice(11, 16);
  }

  private convertTimeToDate(timeString: string): Date {
    const [hours, minutes] = timeString.split(":");
    const date = new Date();
    date.setHours(parseInt(hours), parseInt(minutes));
    return date;
  }

  logValidationErrors() {
    Object.keys(this.branchForm.controls).forEach((key) => {
      const control = this.branchForm.get(key);
      if (control?.errors) {
        console.error(`Validation errors for ${key}:`, control.errors);
      }
    });
  }

  onReturn() {
    this.router.navigate(["/branch/branch-list"]);
  }
}
