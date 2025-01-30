import { Component, ElementRef, HostBinding, OnDestroy, OnInit, Renderer2 } from "@angular/core";
import { Observable, Subscription } from "rxjs";
import { TranslationService } from "../../../../../../modules/i18n";
import { AuthService, UserType } from "../../../../../../modules/auth";
import { AsyncPipe, NgClass, NgFor, NgIf } from "@angular/common";
import { RouterLink } from "@angular/router";
import { TranslateModule } from "@ngx-translate/core";

@Component({
  selector: "app-user-inner",
  templateUrl: "./user-inner.component.html",
  standalone: true,
  imports: [NgClass, NgFor, NgIf, AsyncPipe, RouterLink, TranslateModule]
})
export class UserInnerComponent implements OnInit, OnDestroy {
  @HostBinding("class")
  class = `menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-600 menu-state-bg menu-state-primary fw-bold py-4 fs-6 w-275px`;
  @HostBinding("attr.data-kt-menu") dataKtMenu = "true";

  language: LanguageFlag = languages[1];
  user$: Observable<UserType>;
  langs = languages;
  lang: string = localStorage.getItem("language")!;
  username: string = "";
  private unsubscribe: Subscription[] = [];

  constructor(
    private auth: AuthService,
    private renderer: Renderer2,
    private el: ElementRef,
    private translationService: TranslationService
  ) {
    this.lang = localStorage.getItem("language") ?? "ar";
  }
  getUserName(): void {
    if (typeof localStorage !== "undefined") {
      const user = localStorage.getItem("user");
      if (user) {
        this.username = JSON.parse(user).nameAr;
      }
    }
  }
  ngOnInit(): void {
    this.user$ = this.auth.currentUserSubject.asObservable();
    this.setLanguage(this.translationService.getSelectedLanguage());
    this.lang = localStorage.getItem("language")!;
    if (!this.lang) {
      localStorage.setItem("language", "ar");
    }
    this.getUserName();
  }

  logout() {
    this.auth.logout();
    // document.location.reload();
  }

  selectLanguage(lang: string) {
    this.translationService.setLanguage(lang);
    this.setLanguage(lang);
    document.location.reload();
  }

  setLanguage(lang: string) {
    this.langs.forEach((language: LanguageFlag) => {
      if (language.lang === lang) {
        language.active = true;
        this.language = language;
      } else {
        language.active = false;
      }
      if (this.language.lang == "ar") {
        this.changeStylesheet("s2", "assets/css/style.rtl.css");
        this.changeStylesheet("s3", "assets/css/global.rtl.css");
        this.toggleDirection(false);
      } else {
        this.changeStylesheet("s2", "assets/css/style.css");
        this.changeStylesheet("s3", "assets/css/global.ltr.css");
        this.toggleDirection(true);
      }
    });
  }
  toggleDirection(isLTR: boolean): void {
    const htmlElement = this.el.nativeElement.ownerDocument.documentElement;
    const body = this.el.nativeElement.ownerDocument.body;
    const sideBar = document.getElementById("kt_app_sidebar");
    if (isLTR) {
      // Switch to LTR
      this.renderer.setAttribute(htmlElement, "direction", "ltr");
      this.renderer.setAttribute(htmlElement, "dir", "ltr");
      this.renderer.setStyle(htmlElement, "direction", "ltr");
      this.renderer.setStyle(sideBar, "direction", "ltr");
      this.renderer.setStyle(body, "direction", "ltr");
    } else {
      // Switch to RTL
      this.renderer.setAttribute(htmlElement, "direction", "rtl");
      this.renderer.setAttribute(htmlElement, "dir", "rtl");
      this.renderer.setStyle(htmlElement, "direction", "rtl");
      this.renderer.setStyle(sideBar, "direction", "rtl");
      this.renderer.setStyle(body, "direction", "rtl");
    }
    localStorage.setItem("dir", isLTR ? "en" : "ar");
  }
  changeStylesheet(id: string, newHref: string): void {
    const linkElement = document.getElementById(id) as HTMLLinkElement;
    if (linkElement) {
      linkElement.href = newHref;
    } else {
      console.error("Link element not found");
    }
  }

  ChangeLanguage(lang: string) {
    this.setLanguage(lang);
    this.translationService.setLanguage(lang);
    localStorage.setItem("language", lang);
    this.lang = lang;
    document.location.reload();
  }

  ngOnDestroy() {
    this.unsubscribe.forEach((sb) => sb.unsubscribe());
  }
}

interface LanguageFlag {
  lang: string;
  name: string;
  nameAr: string;
  flag: string;
  active?: boolean;
}

const languages = [
  {
    lang: "en",
    name: "English",
    nameAr: "إنجليزي",
    flag: "./assets/media/flags/united-states.svg"
  },

  {
    lang: "ar",
    name: "Arabic",
    nameAr: "عربي",
    flag: "./assets/media/flags/saudi-arabia.svg"
  }
];
