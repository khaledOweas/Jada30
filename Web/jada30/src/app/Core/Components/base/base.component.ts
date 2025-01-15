import { Component, Injector, OnDestroy } from "@angular/core";
import { CustomToasterService } from "../../Services/custom-toaster.service";
import { TranslationService } from "../../Services/translation.service";
import { Subject } from "rxjs";

@Component({
  selector: "app-base",
  imports: [],
  standalone: true,
  templateUrl: "./base.component.html",
  styleUrl: "./base.component.css"
})
export class BaseComponent implements OnDestroy {
  destroyed$ = new Subject<void>();

  ngOnDestroy() {
    this.destroyed$.next();
    this.destroyed$.complete();
  }

  ct: CustomToasterService;
  tr: TranslationService;
  lang: string = localStorage.getItem("dir")!;

  constructor(injector: Injector) {
    this.ct = injector.get(CustomToasterService);
    this.tr = injector.get(TranslationService);
    this.lang = localStorage.getItem("dir")!;
  }
}
