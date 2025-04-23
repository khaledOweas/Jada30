import { Routes } from "@angular/router";
// import { AuthGuard } from "../auth/services/auth.guard";
import { BranchComponent } from "../core/branchs/branch/branch.component";
import { BranchCreateComponent } from "../core/branchs/branch-create/branch-create.component";
// import { BranchUpdateComponent } from "../core/branchs/branch-update/branch-update.component";
import { BranchDetailsComponent } from "../core/branchs/branch-details/branch-details.component";


export const BRANCH_ROUTES: Routes = [
  { path: "branch-list", canActivate: [], component: BranchComponent },
  { path: "branch-create", canActivate: [], component: BranchCreateComponent },
  { path: "branch-details/:id", canActivate: [], component: BranchDetailsComponent }
];
