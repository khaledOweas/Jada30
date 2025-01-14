import { ApplicationConfig } from "@angular/core";
import { routes } from "./app.routes";
import { provideHttpClient } from "@angular/common/http";
import { HashLocationStrategy, LocationStrategy } from "@angular/common";
import { provideRouter } from "@angular/router";
import { provideClientHydration } from "@angular/platform-browser";
import { provideAnimations } from "@angular/platform-browser/animations";
import { provideTranslateService } from "@ngx-translate/core";

export const appConfig: ApplicationConfig = {
  providers: [
    provideHttpClient(),
    provideRouter(routes),
    provideClientHydration(),
    { provide: LocationStrategy, useClass: HashLocationStrategy },
    provideTranslateService({
      defaultLanguage: "ar"
    }),
    provideAnimations()
  ]
};
