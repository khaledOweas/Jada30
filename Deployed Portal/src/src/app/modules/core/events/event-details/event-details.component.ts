import { Component, Injector, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from "@angular/forms";
import { ActivatedRoute } from "@angular/router";
import { TranslatePipe } from "@ngx-translate/core";
import { BaseComponent } from "src/app/core/Components/base/base.component";
import { CoreService, CreateEventDto, GetEventDto } from "src/app/services/CoreService";
import { LookupDropdownComponent } from "../../../shared/lookup-dropdown/lookup-dropdown.component";
import { LookupMultiSelectComponent } from "../../../shared/lookup-multi-select/lookup-multi-select.component";
import { ValidationAlertsComponent } from "src/app/core/Components/validation-alerts/validation-alerts.component";
import { NgIf } from "@angular/common";
import { TranslationModule } from "../../../i18n";

import { TabViewModule } from 'primeng/tabview';
import { PanelModule } from 'primeng/panel';
import { formatDate } from "src/app/core/Interceptors/date.util";
import { CommonModule } from "@angular/common";


@Component({
  selector: "app-event-details",
  standalone: true,
  imports: [
    LookupDropdownComponent,
    LookupMultiSelectComponent,
    ValidationAlertsComponent,
    TranslatePipe,
    ReactiveFormsModule,
    TranslationModule,
    NgIf,
    TabViewModule, PanelModule, CommonModule
  ],
  providers: [CoreService],
  templateUrl: "./event-details.component.html"
})
export class EventDetailsComponent extends BaseComponent implements OnInit {
  eventForm: FormGroup;
  eventId: number;

  eventDetails: GetEventDto; // Object to hold Event details
  formattedStartDate: string;
  formattedEndDate: string;


  constructor(
    private injector: Injector,
    private fb: FormBuilder,
    private service: CoreService,
    private route: ActivatedRoute
  ) {
    super(injector);
    this.eventForm = this.fb.group({
      id: [null],
      title: ["", Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(100)])],
      titleAr: ["", Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(100)])],
      typeId: [null, Validators.compose([Validators.required, Validators.pattern(/^[0-9]+$/)])],
      branchId: [null, Validators.compose([Validators.required, Validators.pattern(/^[0-9]+$/)])],
      duration: [null, Validators.compose([Validators.required, Validators.pattern(/^[0-9]+$/)])],
      startDate: ["", Validators.required],
      endDate: ["", Validators.required],
      isForJadah30Customers: [null, Validators.compose([Validators.required])],
      speakersNames: ["", Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(100)])],
      numberSeats: [null, Validators.compose([Validators.required, Validators.pattern(/^[0-9]+$/)])],
      socialMediaLinks:  ["", Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(100)])],
      registrationForm: [null, Validators.compose([Validators.required])],
      isFreePaid: [null, Validators.compose([Validators.required])],
      mediaFiles: [[], Validators.compose([Validators.required])]
    });
    this.eventId = this.route.snapshot.params["id"];
  }

  ngOnInit(): void {
    this.loadEventData();
    console.log("eventForm.get('nameAr'): "+ JSON.stringify(this.eventForm.get('nameAr')))
  }

  loadEventData() {
    this.service.eventGET2(this.eventId).subscribe({
      next: (res) => {
        if (res.isSuccess) {
          const event = res.responseData!;
          // this.branchForm.patchValue({
          //   id: branch.id,
          //   name: branch.name,
          //   nameAr: branch.nameAr,
          //   websiteBranchId: branch.websiteBranchId,
          //   workingDays: branch.workingDays,
          //   startTime: this.formatTime(branch.startTime!),
          //   endTime: this.formatTime(branch.endTime!),
          //   categoryBranchId: branch.categoryBranchId,
          //   administrativeRegionId: branch.administrativeRegionId,
          //   branchComponents: branch.branchComponents?.map((x) => x.id!)!
          // });
          this.eventDetails= res.responseData!;
        }
      },
      error: (err) => console.error(err)
    });
  }

  onSubmit() {
    if (this.eventForm.valid) {
      const formValue = this.eventForm.value;
      const detailsDto: CreateEventDto = {
        ...formValue,
        startTime: this.convertTimeToDate(formValue.startTime),
        endTime: this.convertTimeToDate(formValue.endTime),
        eventComponents: formValue.eventComponents.map((c: number) => ({
          eventId: this.eventId,
          componentId: c
        }))
      };

      this.service.eventPUT(this.eventId, detailsDto).subscribe({
        next: (res) => {
          if (res.isSuccess) {
            this.ct.sendToaster("info", this.tr.get("SHARED.ServerDetails"), res.message);
            this.router.navigate(["/event/event-list"]);
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
    Object.keys(this.eventForm.controls).forEach((key) => {
      const control = this.eventForm.get(key);
      if (control?.errors) {
        console.error(`Validation errors for ${key}:`, control.errors);
      }
    });
  }

  onReturn() {
    this.router.navigate(["/event/event-list"]);
  }
}
