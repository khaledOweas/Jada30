import { Component, HostBinding, Input, OnInit } from "@angular/core";
import icons from "./icons.json";
import { NgFor, NgIf } from "@angular/common";

@Component({
  selector: "app-keenicon",
  standalone: true,
  templateUrl: "./keenicon.component.html",
  styleUrls: ["./keenicon.component.scss"],
  imports: [NgIf, NgFor]
})
export class KeeniconComponent implements OnInit {
  @Input() name: string;
  @Input() class: string;
  @Input() type: string = "duotone";

  pathsNumber: number = 0;

  constructor() {}

  ngOnInit() {
    if (this.type === "duotone") {
      // @ts-ignore
      this.pathsNumber = icons[this.type + "-paths"][this.name] ?? 0;
    }
  }

  @HostBinding("style.display")
  get styleDisplay() {
    return "contents";
  }
}
