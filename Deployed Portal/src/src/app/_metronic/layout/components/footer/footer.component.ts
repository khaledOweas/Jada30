import { NgClass, NgIf, NgTemplateOutlet } from "@angular/common";
import { Component, Input } from "@angular/core";
import { JadaFooterComponent } from "src/app/core/Components/jada-footer/jada-footer.component";

@Component({
  selector: "app-footer",
  templateUrl: "./footer.component.html",
  styleUrls: ["./footer.component.scss"],
  standalone: true,
  imports: [NgClass, NgIf, NgTemplateOutlet,JadaFooterComponent]
})
export class FooterComponent {
  @Input() appFooterContainerCSSClass: string = "";

  currentDateStr: string = new Date().getFullYear().toString();
  constructor() {}
}
