import { Component, Injector, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from "@angular/forms";
import { ActivatedRoute } from "@angular/router";
import { TranslatePipe } from "@ngx-translate/core";
import { BaseComponent } from "src/app/core/Components/base/base.component";
import { CoreService, CreateBranchDto, GetBranchDto } from "src/app/services/CoreService";
import { LookupDropdownComponent } from "../../../shared/lookup-dropdown/lookup-dropdown.component";
import { LookupMultiSelectComponent } from "../../../shared/lookup-multi-select/lookup-multi-select.component";
import { ValidationAlertsComponent } from "src/app/core/Components/validation-alerts/validation-alerts.component";
import { JsonPipe, NgIf } from "@angular/common";
import { TranslationModule } from "../../../i18n";

import { TabViewModule } from 'primeng/tabview';
import { PanelModule } from 'primeng/panel';
import { formatDate } from "src/app/core/Interceptors/date.util";
import { CommonModule } from "@angular/common";


@Component({
  selector: "app-branch-details",
  standalone: true,
  imports: [
    LookupDropdownComponent,
    LookupMultiSelectComponent,
    ValidationAlertsComponent,
    TranslatePipe,
    ReactiveFormsModule,
    TranslationModule,
    NgIf,
    TabViewModule, PanelModule, CommonModule, JsonPipe
  ],
  providers: [CoreService],
  templateUrl: "./branch-details.component.html"
})
export class BranchDetailsComponent extends BaseComponent implements OnInit {
  branchForm: FormGroup;
  branchId: number;

  branchDetails: GetBranchDto; // Object to hold branch details
  branchComponents: any[] = [];
  formattedStartDate: string;
  formattedEndDate: string;


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
      administrativeRegionId: [null, Validators.compose([Validators.required, Validators.pattern(/^[0-9]+$/)])],
      branchComponents: [[], Validators.compose([Validators.required])]
    });
    this.branchId = this.route.snapshot.params["id"];
  }

  ngOnInit(): void {
    this.loadBranchData();
    console.log("branchForm.get('nameAr'): "+ JSON.stringify(this.branchForm.get('nameAr')))
  }

  loadBranchData() {
    this.service.branchGET2(this.branchId).subscribe({
      next: (res) => {
        this.branchDetails= res[0]!;
        this.branchComponents =  JSON.parse( res[0].Components);
        // if (res.isSuccess) {
        //   const branch = res.responseData!;
        //   // this.branchForm.patchValue({
        //   //   id: branch.id,
        //   //   name: branch.name,
        //   //   nameAr: branch.nameAr,
        //   //   websiteBranchId: branch.websiteBranchId,
        //   //   workingDays: branch.workingDays,
        //   //   startTime: this.formatTime(branch.startTime!),
        //   //   endTime: this.formatTime(branch.endTime!),
        //   //   categoryBranchId: branch.categoryBranchId,
        //   //   administrativeRegionId: branch.administrativeRegionId,
        //   //   branchComponents: branch.branchComponents?.map((x) => x.id!)!
        //   // });
       
        //   debugger;
        //   this.formattedStartDate= formatDate(this.branchDetails.startTime);
        //   this.formattedEndDate= formatDate(this.branchDetails.endTime); 
        // }
      },
      error: (err) => console.error(err)
    });
  }

  onSubmit() {
    if (this.branchForm.valid) {
      const formValue = this.branchForm.value;
      const detailsDto: CreateBranchDto = {
        ...formValue,
        startTime: this.convertTimeToDate(formValue.startTime),
        endTime: this.convertTimeToDate(formValue.endTime),
        branchComponents: formValue.branchComponents.map((c: number) => ({
          branchId: this.branchId,
          componentId: c
        }))
      };

      this.service.branchPUT(this.branchId, detailsDto).subscribe({
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
