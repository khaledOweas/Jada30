import { APP_INITIALIZER, ApplicationConfig } from "@angular/core";
import { routes } from "./app.routes";
import { HTTP_INTERCEPTORS, provideHttpClient, withInterceptorsFromDi } from "@angular/common/http";
import { HashLocationStrategy, LocationStrategy } from "@angular/common";
import { provideRouter } from "@angular/router";
import { provideClientHydration } from "@angular/platform-browser";
import { provideAnimations } from "@angular/platform-browser/animations";
import { provideTranslateService } from "@ngx-translate/core";
import { API_BASE_URL as Identity } from "./Services/IdentityService";
import { API_BASE_URL as Lookup } from "./Services/LookupService";
import { AppConfigService } from "./Core/Services/app-config.service";
import { HeaderInterceptorService } from "./Core/Interceptors/header-interceptor.service";
import { LoaderInterceptorService } from "./Core/Interceptors/loader-interceptor.service";

function loadConfigFactory(configService: AppConfigService) {
  return () => configService.loadConfig();
}

export const appConfig: ApplicationConfig = {
  providers: [
    provideHttpClient(withInterceptorsFromDi()),
    provideRouter(routes),
    provideClientHydration(),
    { provide: LocationStrategy, useClass: HashLocationStrategy },
    {
      provide: APP_INITIALIZER,
      useFactory: loadConfigFactory,
      deps: [AppConfigService],
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: LoaderInterceptorService,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HeaderInterceptorService,
      multi: true
    },
    {
      provide: Identity,
      deps: [AppConfigService],
      useFactory: (configService: AppConfigService) => configService.getConfig().apiUrl
    },
    {
      provide: Lookup,
      deps: [AppConfigService],
      useFactory: (configService: AppConfigService) => configService.getConfig().apiUrl
    },
    provideTranslateService({
      defaultLanguage: "ar"
    }),
    provideAnimations()
  ]
};
