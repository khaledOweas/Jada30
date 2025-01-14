import { Component, Injector } from "@angular/core";

import { ToastModule } from "primeng/toast";
import { BaseComponent } from "../../../Core/Base/base/base.component";
import { TranslateDirective } from "@ngx-translate/core";
import { SharedDatatableComponent } from "../../../Core/shared/shared-datatable/shared-datatable.component";
import { SharedDataTableColumn } from "../../../Core/shared/shared-datatable/sharedDatatablesModels";

@Component({
  selector: "app-user-list",
  standalone: true,
  imports: [ToastModule, TranslateDirective, SharedDatatableComponent],
  providers: [],
  templateUrl: "./user-list.component.html",
  styleUrl: "./user-list.component.css"
})
export class UserListComponent extends BaseComponent {
  Cols!: SharedDataTableColumn[];
  Data: any[] = [];

  constructor(private injector: Injector) {
    super(injector);

    this.Cols = [
      SharedDataTableColumn.fromJS({
        id: 1,
        sorted: true,
        filtered: true,
        hidden: true,
        field: "id",
        header: this.lang == "ar" ? "الكود التعريفي" : "Id Code ",
        type: "text"
      }),
      SharedDataTableColumn.fromJS({
        id: 4,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "start",
        header: this.lang == "ar" ? "بداية" : "Start ",
        type: "text"
      }),
      SharedDataTableColumn.fromJS({
        id: 5,
        sorted: true,
        filtered: true,
        hidden: false,
        field: "end",
        header: this.lang == "ar" ? "نهاية" : "End ",
        type: "text"
      })
    ];
  }
  show() {
    this.ct.sendToaster("info", "title mesage ", "message Meesage");
  }
}
