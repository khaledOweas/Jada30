import { Component, Input, OnDestroy, OnInit } from "@angular/core";
import { Subscription } from "rxjs";
import { LayoutType } from "../../../core/configs/config";
import { LayoutService } from "../../../core/layout.service";
import { KeeniconComponent } from "src/app/_metronic/shared/keenicon/keenicon.component";
import { NgClass, NgIf } from "@angular/common";

@Component({
  selector: "app-sidebar-logo",
  templateUrl: "./sidebar-logo.component.html",
  styleUrls: ["./sidebar-logo.component.scss"],
  standalone: true,
  imports: [KeeniconComponent, NgClass, NgIf]
})
export class SidebarLogoComponent implements OnInit, OnDestroy {
  private unsubscribe: Subscription[] = [];
  @Input() toggleButtonClass: string = "";
  @Input() toggleEnabled: boolean;
  @Input() toggleType: string = "";
  @Input() toggleState: string = "";
  currentLayoutType: LayoutType | null;

  toggleAttr: string;
  iconName: string = "double-right";
  constructor(private layout: LayoutService) {}

  ngOnInit(): void {
    this.toggleAttr = `app-sidebar-${this.toggleType}`;
    const layoutSubscr = this.layout.currentLayoutTypeSubject.asObservable().subscribe((layout) => {
      this.currentLayoutType = layout;
    });
    this.unsubscribe.push(layoutSubscr);
  }

  ngOnDestroy() {
    this.unsubscribe.forEach((sb) => sb.unsubscribe());
  }
  toggleIcon() {
    if (this.iconName == "double-right") {
      this.iconName = "double-left";
    } else {
      this.iconName = "double-right";
    }
  }
}
