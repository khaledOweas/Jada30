import { Routes } from "@angular/router";
import { AuthGuard } from "../auth/services/auth.guard";
import { EventComponent } from "../core/events/event/event.component";
// import { BranchCreateComponent } from "../core/branchs/branch-create/branch-create.component";
// import { BranchUpdateComponent } from "../core/branchs/branch-update/branch-update.component";
import { EventDetailsComponent } from "../core/events/event-details/event-details.component";


export const EVENT_ROUTES: Routes = [
  { path: "event-list", canActivate: [], component: EventComponent },
  // { path: "branch-create", canActivate: [], component: BranchCreateComponent },
  { path: "event-details/:id", canActivate: [], component: EventDetailsComponent }
];
