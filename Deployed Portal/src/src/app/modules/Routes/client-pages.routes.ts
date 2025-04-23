import { Routes } from "@angular/router";
// import { AuthGuard } from "../auth/services/auth.guard";
import { MainPageComponent } from "../core/client-pages/main-page/main-page.component";
import { AboutJadaComponent } from "../core/client-pages/about-jada/about-jada.component";
import { FrequentlyAskedQuestionsComponent } from "../core/client-pages/frequently-asked-questions/frequently-asked-questions.component";
export const CLIENTPAGES_ROUTES: Routes = [
  { path: "main-page", canActivate: [], component: MainPageComponent },
  { path: "about-jada", canActivate: [], component: AboutJadaComponent },
  { path: "faq", canActivate: [], component: FrequentlyAskedQuestionsComponent },
];
