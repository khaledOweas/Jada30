import { Routes } from "@angular/router";
import { LayoutComponent } from "src/app/_metronic/layout/layout.component";
import { LookupListComponent } from "../lookup/lookup-list/lookup-list.component";

export const LOOKUP_ROUTES: Routes = [
  {
    path: "",
    component: LayoutComponent,
    children: [{ path: "lookup-list/:code", component: LookupListComponent }]
  }
];
