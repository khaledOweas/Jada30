import { Routes } from "@angular/router";
import { LookupListComponent } from "../lookup/lookup-list/lookup-list.component";

export const LOOKUP_ROUTES: Routes = [{ path: "lookup-list/:code", component: LookupListComponent }];
