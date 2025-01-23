import { Routes } from "@angular/router";
import { LookupListComponent } from "../lookup/lookup-list/lookup-list.component";
import { LookupCreateComponent } from "../lookup/lookup-create/lookup-create.component";

export const LOOKUP_ROUTES: Routes = [
  { path: "lookup-list/:code", component: LookupListComponent },
  { path: "lookup-create/:code", component: LookupCreateComponent }
];
