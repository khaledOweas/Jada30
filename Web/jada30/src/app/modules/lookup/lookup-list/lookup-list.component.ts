import { Component, Injector, OnInit } from "@angular/core";
import { TranslateDirective } from "@ngx-translate/core";

import { ActivatedRoute } from "@angular/router";

import { GetLookupDto, GetLookupDtoListBaseResponse, LookupService } from "src/app/services/LookupService";
import { SharedDataTableColumn } from "src/app/core/shared/shared-datatable/sharedDatatablesModels";
import { SharedDatatableComponent } from "src/app/core/shared/shared-datatable/shared-datatable.component";
import { BaseComponent } from "src/app/core/Components/base/base.component";

@Component({
  selector: "app-lookup-list",
  imports: [TranslateDirective, SharedDatatableComponent],
  providers: [LookupService],
  standalone: true,
  templateUrl: "./lookup-list.component.html",
  styleUrl: "./lookup-list.component.css"
})
export class LookupListComponent extends BaseComponent implements OnInit {
  Cols!: SharedDataTableColumn[];
  Data: GetLookupDto[] | undefined;
  code: string = "";

  constructor(private injector: Injector, private service: LookupService, private route: ActivatedRoute) {
    super(injector);
  }

  ngOnInit(): void {
    this.code = this.route.snapshot.params["code"];
    this.loadAll();
    this.route.params.subscribe((params) => {
      const newCode = params["code"];
      if (newCode !== this.code) {
        this.code = newCode;
        this.loadAll();
      }
    });
  }

  loadAll() {
    this.service.getAll2(this.code).subscribe({
      next: (res: GetLookupDtoListBaseResponse) => {
        this.Data = res.responseData;
      },
      error: (err) => {
        console.error("Failed to load lookup data:", err);
      }
    });
  }
}
