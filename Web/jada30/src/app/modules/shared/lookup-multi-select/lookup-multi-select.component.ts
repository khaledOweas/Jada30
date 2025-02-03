import { CommonModule } from "@angular/common";
import { Component, EventEmitter, Input, OnInit, Output } from "@angular/core";
import { FormGroup, FormsModule, ReactiveFormsModule } from "@angular/forms";
import { TranslationModule } from "../../i18n";
import { Subject, takeUntil } from "rxjs";
import { GetLookupDtoListBaseResponse, LookupService } from "src/app/services/LookupService";
import { MultiSelectModule } from "primeng/multiselect";

@Component({
  selector: "app-lookup-multi-select",
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, MultiSelectModule, FormsModule, TranslationModule],
  templateUrl: "./lookup-multi-select.component.html",
  styleUrl: "./lookup-multi-select.component.scss",
  providers: [LookupService]
})
export class LookupMultiSelectComponent implements OnInit {
  @Input() parentForm: FormGroup;
  @Output() selected = new EventEmitter<any>();
  @Input() code: string;
  @Input() itemFormName: string;
  @Input() validationTextTranslated: string;
  @Input() placeholderTextTranslated: string;
  @Input() labelTextTranslated: string;
  private destroy$ = new Subject<void>();

  selectedItem: any = {};
  items: any[] = [];
  constructor(private lookupService: LookupService) {}
  ngOnInit(): void {
    this.loadAll();
  }

  loadAll() {
    this.lookupService
      .getAll2(this.code)
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: (res: GetLookupDtoListBaseResponse) => {
          this.items = res.responseData?.map((x) => ({ id: x.id!, name: x.nameAr!, code: x.internalCode! })) || [];
        }
      });
  }
}
