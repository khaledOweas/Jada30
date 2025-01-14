import { bootstrapApplication } from "@angular/platform-browser";
import { appConfig } from "./app/app.config";
import { AppComponent } from "./app/app.component";
import { AppConfigService } from "./app/Core/Services/app-config.service";

bootstrapApplication(AppComponent, appConfig)
  .then(async (appRef) => {
    const configService = appRef.injector.get(AppConfigService);
    await configService.loadConfig();
    console.log("Configuration loaded successfully!");
  })
  .catch((err) => console.error(err));
