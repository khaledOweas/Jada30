import { JsonPipe, NgIf } from "@angular/common";
import { Component, Injector, OnInit } from "@angular/core";
import { FormsModule, ReactiveFormsModule, FormBuilder, FormGroup, Validators, AbstractControl } from "@angular/forms";
import { TranslateDirective, TranslatePipe } from "@ngx-translate/core";
import { ToastModule } from "primeng/toast";
import { MultiSelectModule } from "primeng/multiselect";
import { BaseComponent } from "src/app/core/Components/base/base.component";
import { CoreService, CreateBranchDto } from "src/app/services/CoreService";
import { LookupDropdownComponent } from "../../shared/lookup-dropdown/lookup-dropdown.component";
import { LookupMultiSelectComponent } from "../../shared/lookup-multi-select/lookup-multi-select.component";


@Component({
  selector: "app-branch-create",
  standalone: true,
  imports: [
    FormsModule,
    ReactiveFormsModule,
    ToastModule,
    TranslateDirective,
    NgIf,
    MultiSelectModule,
    TranslatePipe,
    LookupDropdownComponent,
    LookupMultiSelectComponent,
    JsonPipe
  ],
  providers: [CoreService],
  templateUrl: "./branch-create.component.html"
})
export class BranchCreateComponent extends BaseComponent implements OnInit {
  branchForm: FormGroup;
  componentsData: any[] = [];

  constructor(private injector: Injector, private fb: FormBuilder, private service: CoreService) {
    super(injector);
    this.branchForm = this.fb.group({
      name: ["", Validators.required],
      websiteBranchId: [0, [Validators.required, Validators.pattern(/^[0-9]+$/)]],
      workingDays: ["", Validators.required],
      startTime: ["", Validators.required],
      endTime: ["", Validators.required],
      categoryBranchId: [0, [Validators.required, Validators.pattern(/^[0-9]+$/)]],
      branchComponents: [[], Validators.required]
    });
  }

  ngOnInit(): void {}

  onSubmit(action: "new" | "redirect") {
    if (this.branchForm.valid) {
      const formValue = this.branchForm.value;
      const createDto: CreateBranchDto = {
        ...formValue,

        startTime: this.convertTimeToDate(formValue.startTime),
        endTime: this.convertTimeToDate(formValue.endTime),

        branchComponents: formValue.branchComponents.map((c: number) => ({ branchId: 0, componentId: c }))
      };

      this.service.branchPOST(createDto).subscribe({
        next: (res) => {
          if (res.isSuccess) {
            this.ct.sendToaster("info", this.tr.get("SHARED.ServerDetails"), res.message);
            this.handlePostSubmit(action);
          }
        },
        error: (err) => console.error(err)
      });
    } else {
      this.logValidationErrors();
    }
  }

  private convertTimeToDate(timeString: string): Date {
    const [hours, minutes] = timeString.split(":");
    const date = new Date();
    date.setHours(parseInt(hours), parseInt(minutes));
    return date;
  }

  private handlePostSubmit(action: "new" | "redirect") {
    switch (action) {
      case "new":
        this.branchForm.reset();
        break;
      case "redirect":
        this.router.navigate(["/branch/branch-list"]);
        break;
    }
  }

  logValidationErrors() {
    Object.keys(this.branchForm.controls).forEach((key) => {
      const control = this.branchForm.get(key);
      if (control?.errors) {
        console.error(`Validation errors for ${key}:`, control.errors);
      }
    });
  }

  onReset() {
    this.branchForm.reset();
  }

  objectKeys(obj: any): string[] {
    return Object.keys(obj);
  }
}
