import { Component, Inject, Renderer2 } from '@angular/core';
import { RouterLink, RouterOutlet, Router, Event, NavigationStart } from '@angular/router';
import { AdminMenuService } from './components/admin-menu/admin-menu.service';
import { CommonModule, DOCUMENT } from '@angular/common';
import { AdminMenuComponent } from './components/admin-menu/admin-menu.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CommonModule, AdminMenuComponent],
  templateUrl: './app.component.html',
})
export class AppComponent {
  showMenu = true; // Default to true (menu is visible)
  constructor(private router: Router, private menuService: AdminMenuService , private renderer: Renderer2,
    @Inject(DOCUMENT) private document: Document) {
    this.router.events.subscribe((event: Event) => {
      if (event instanceof NavigationStart) {
        this.menuService.setShowMenu(!event.url.includes('/auth'));
      }
    });

    this.menuService.showMenu$.subscribe((show) => {
      this.showMenu = show;
    });

  }
  title = 'SDBDemo';

  showCustomizePanel = false; // Controls the visibility of the panel
  isRTL = false; // Tracks the current direction
  // constructor(
  //   private renderer: Renderer2,
  //   @Inject(DOCUMENT) private document: Document
  // ) { }
  // Toggle the customization panel
  toggleCustomizePanel() {
    this.showCustomizePanel = !this.showCustomizePanel;
  }

  // Toggle the direction (LTR/RTL)
  toggleDirection() {
    this.isRTL = !this.isRTL;
    const html = this.document.documentElement;
    if (this.isRTL) {
      this.renderer.setAttribute(html, 'dir', 'rtl'); // Set direction to RTL
    } else {
      this.renderer.setAttribute(html, 'dir', 'ltr'); // Set direction to LTR
    }
    this.showCustomizePanel = !this.showCustomizePanel;
  }
}
