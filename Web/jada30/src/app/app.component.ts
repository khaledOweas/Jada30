import { ChangeDetectionStrategy, Component, OnInit } from "@angular/core";
import { Router, RouterOutlet, NavigationEnd } from "@angular/router";

@Component({
  selector: "app-root",
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: "./app.component.html",
  styleUrl: "./app.component.css",
  changeDetection: ChangeDetectionStrategy.Default
})
export class AppComponent implements OnInit {
  constructor(private router: Router) {}

  ngOnInit(): void {
    this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        this.reinitializeMetronicScripts();
      }
    });
  }
  private reinitializeMetronicScripts() {}
}
