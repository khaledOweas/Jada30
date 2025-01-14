import { Component, OnInit } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { AdminMenuService } from './admin-menu.service';

@Component({
  selector: 'admin-menu',
  standalone: true,
  templateUrl: './admin-menu.component.html',
  imports:[RouterLink]
})
export class AdminMenuComponent implements OnInit {
  ngOnInit() {
  }
  showMenu = true;

  constructor(private menuService: AdminMenuService) {
    this.menuService.showMenu$.subscribe((show) => {
      this.showMenu = show;
    });
  }
}
