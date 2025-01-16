import { LayoutComponent } from "../Layout/layout/layout.component";
import { Routes } from "@angular/router";
import { LookupListComponent } from "../Modules/lookup/lookup-list/lookup-list.component";

export const LOOKUP_ROUTES: Routes = [
  {
    path: "",
    component: LayoutComponent,
    children: [{ path: "lookup-list/:code", component: LookupListComponent }]
  }
];
