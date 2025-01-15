import { ChangeDetectionStrategy, Component, OnInit } from "@angular/core";
import { RouterOutlet } from "@angular/router";
import { CustomToasterService } from "./Core/Services/custom-toaster.service";
import { MessageService } from "primeng/api";
import { ToastModule, ToastPositionType } from "primeng/toast";
import { TranslationService } from "./Core/Services/translation.service";
import { locale as enLang } from "./Core/i18n/vocabs/en";
import { locale as arLang } from "./Core/i18n/vocabs/ar";
import { MainSpinnerComponent } from "./Core/Components/main-spinner/main-spinner.component";

@Component({
  selector: "app-root",
  standalone: true,
  imports: [RouterOutlet, ToastModule, MainSpinnerComponent],
  providers: [CustomToasterService, MessageService],
  templateUrl: "./app.component.html",
  styleUrl: "./app.component.css",
  changeDetection: ChangeDetectionStrategy.Default
})
export class AppComponent implements OnInit {
  constructor(
    private ct: CustomToasterService,
    private messageService: MessageService,
    private translationService: TranslationService
  ) {
    this.translationService.loadTranslations(arLang, enLang);
  }

  ngOnInit(): void {
    this.subscribeToToasters();
  }

  subscribeToToasters() {
    this.ct.toasterListener$.subscribe((msg: any) => {
      if (msg.message?.length > 5) this.addLogMessage(msg.title, msg.message, msg.style);
    });
  }
  addLogMessage(title: string, msg: string, severity: string) {
    if (localStorage.getItem("dir")! === "ar") {
      this.messageService.add({ key: "tl", severity: severity, summary: title, detail: msg, life: 8000 });
    } else {
      this.messageService.add({ key: "rl", severity: severity, summary: title, detail: msg, life: 8000 });
    }
  }
}
