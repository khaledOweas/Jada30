import { Component, Injector, OnInit } from "@angular/core";
import { BaseComponent } from "../../../Core/Components/base/base.component";
import { TranslateDirective } from "@ngx-translate/core";
import { SharedDatatableComponent } from "../../../Core/shared/shared-datatable/shared-datatable.component";
import { SharedDataTableColumn } from "../../../Core/shared/shared-datatable/sharedDatatablesModels";
import { GetLookupDto, GetLookupDtoListBaseResponse, LookupService } from "../../../Services/LookupService";
import { ActivatedRoute } from "@angular/router";

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
  }

  loadAll() {
    this.service.getAll2(this.code).subscribe({
      next: (res: GetLookupDtoListBaseResponse) => {
        this.Data = res.responseData;
      }
    });
  }
}
