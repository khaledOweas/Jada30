import { Component, ElementRef, OnInit, Renderer2 } from "@angular/core";

@Component({
  selector: "app-header-bar",
  standalone: true,
  imports: [],
  templateUrl: "./header-bar.component.html",
  styleUrl: "./header-bar.component.css"
})
export class HeaderBarComponent implements OnInit {
  currentLangIconPath: string = "assets/media/flags/saudi-arabia.svg";
  currentLangText: string = "Arabic";
  constructor(private renderer: Renderer2, private el: ElementRef) {}

  ngOnInit(): void {
    if (typeof localStorage !== "undefined") {
      this.setLanguage(localStorage.getItem("dir")!);
    }
  }

  changeLanguage(Text: string, path: string) {
    this.setLanguage(Text);
  }

  setLanguage(lang: string) {
    this.currentLangText = lang;
    if (lang == "Arabic") {
      this.changeStylesheet("s1", "assets/css/style.bundle.rtl.css");
      this.toggleDirection(false);
      this.currentLangIconPath = "assets/media/flags/saudi-arabia.svg";
    } else {
      this.changeStylesheet("s1", "assets/css/style.bundle.css");
      this.toggleDirection(true);
      this.currentLangIconPath = "assets/media/flags/united-states.svg";
    }
  }

  toggleDirection(isLTR: boolean): void {
    const htmlElement = this.el.nativeElement.ownerDocument.documentElement;
    const header = document.getElementById("kt_header");
    const side = document.getElementById("kt_aside");
    const side2 = document.getElementById("kt_aside_menu");
    const content = document.getElementById("kt_content");
    if (isLTR) {
      // Switch to LTR
      this.renderer.setAttribute(htmlElement, "direction", "ltr");
      this.renderer.setAttribute(htmlElement, "dir", "ltr");
      this.renderer.setStyle(htmlElement, "direction", "ltr");
      this.renderer.setStyle(header, "direction", "ltr");
      this.renderer.setStyle(side, "direction", "ltr");
      this.renderer.setStyle(side2, "direction", "ltr");
      this.renderer.setStyle(content, "direction", "ltr");
    } else {
      // Switch to RTL
      this.renderer.setAttribute(htmlElement, "direction", "rtl");
      this.renderer.setAttribute(htmlElement, "dir", "rtl");
      this.renderer.setStyle(htmlElement, "direction", "rtl");
      this.renderer.setStyle(header, "direction", "rtl");
      this.renderer.setStyle(side, "direction", "rtl");
      this.renderer.setStyle(side2, "direction", "rtl");
      this.renderer.setStyle(content, "direction", "rtl");
    }
    // for temp

    localStorage.setItem("dir", isLTR ? "English" : "Arabic");
  }
  changeStylesheet(id: string, newHref: string): void {
    const linkElement = document.getElementById(id) as HTMLLinkElement;
    if (linkElement) {
      linkElement.href = newHref;
    } else {
      console.error("Link element not found");
    }
  }
}
