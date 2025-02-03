import { Routes } from "@angular/router";
import { AuthGuard } from "../auth/services/auth.guard";
import { FacilitiesComponent } from "../core/facilities/facilities.component";
import { FacilityCreateComponent } from "../core/facility-create/facility-create.component";
import { FacilityUpdateComponent } from "../core/facility-update/facility-update.component";

export const Facility_ROUTES: Routes = [
  { path: "facility-list", canActivate: [AuthGuard], component: FacilitiesComponent },
  { path: "facility-create", canActivate: [AuthGuard], component: FacilityCreateComponent },
  { path: "facility-update/:id", canActivate: [AuthGuard], component: FacilityUpdateComponent }
];
