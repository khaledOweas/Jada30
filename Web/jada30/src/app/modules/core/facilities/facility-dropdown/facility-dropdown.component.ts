import { CommonModule } from "@angular/common";
import { Component, EventEmitter, Input, OnInit, Output } from "@angular/core";
import { FormGroup, FormsModule, ReactiveFormsModule } from "@angular/forms";
import { DropdownModule } from "primeng/dropdown";

import { Subject, takeUntil } from "rxjs";
import { TranslationModule } from "src/app/modules/i18n";
import { CoreService, FacilityDto, FacilityDtoListBaseResponse } from "src/app/services/CoreService";
@Component({
  selector: "app-facility-dropdown",
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, DropdownModule, FormsModule, TranslationModule],
  templateUrl: "./facility-dropdown.component.html",
  styleUrl: "./facility-dropdown.component.scss",
  providers: [CoreService]
})
export class FacilityDropdownComponent {
  @Input() parentForm: FormGroup;
  @Output() selected = new EventEmitter<any>();
  @Input() itemFormName: string;
  @Input() validationTextTranslated: string;
  @Input() placeholderTextTranslated: string;
  @Input() labelTextTranslated: string;
  private destroy$ = new Subject<void>();
  lang: string = localStorage.getItem("language")!;
  selectedItem: any = {};
  items: any[] = [];
  constructor(private service: CoreService) {}
  ngOnInit(): void {
    this.lang = localStorage.getItem("language")!;
    this.loadAllFacilities();
  }

  // Facilities
  AllFacilities: FacilityDto[] | undefined;
  loadAllFacilities() {
    this.service
      .getFacilities()
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: (res: FacilityDtoListBaseResponse) => {
          this.items =
            res.responseData?.map((x) => ({
              id: x.id!,
              name: this.lang === "ar" ? x.nameAr! : x.name!,
              code: x.destinationName?.replace(" ", "")
            })) || [];
        }
      });
  }
}
