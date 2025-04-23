import { CommonModule } from "@angular/common";
import { Component, EventEmitter, Input, OnInit, Output } from "@angular/core";
import { FormGroup, FormsModule, ReactiveFormsModule } from "@angular/forms";
import { DropdownModule } from "primeng/dropdown";
import { TranslationModule } from "../../i18n";
import { Subject, takeUntil } from "rxjs";
import { GetLookupDtoListBaseResponse, LookupService } from "src/app/services/LookupService";

@Component({
  selector: "app-lookup-dropdown",
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, DropdownModule, FormsModule, TranslationModule],
  templateUrl: "./lookup-dropdown.component.html",
  styleUrl: "./lookup-dropdown.component.scss",
  providers: [LookupService]
})
export class LookupDropdownComponent implements OnInit {
  @Input() parentForm: FormGroup;
  @Output() selected = new EventEmitter<any>();
  @Input() code: string;
  @Input() itemFormName: string;
  @Input() validationTextTranslated: string;
  @Input() placeholderTextTranslated: string;
  @Input() labelTextTranslated: string;
  private destroy$ = new Subject<void>();
  lang: string = localStorage.getItem("language")!;
  selectedItem: any = {};
  items: any[] = [];
  constructor(private lookupService: LookupService) {}
  ngOnInit(): void {
    this.lang = localStorage.getItem("language")!;
    this.loadAll();
  }

  loadAll() {
    this.lookupService
      .getAll2(this.code)
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: (res: GetLookupDtoListBaseResponse) => {
          this.items =
            res.responseData?.map((x) => ({
              id: x.id!,
              name: this.lang === "ar" ? x.nameAr! : x.name!,
              code: x.internalCode!
            })) || [];
        }
      });
  }
}
