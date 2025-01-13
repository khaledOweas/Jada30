import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root' // Provide the service at the root level
})
export class AdminMenuService {
  private showMenuSubject = new BehaviorSubject<boolean>(true);
  showMenu$ = this.showMenuSubject.asObservable();

  setShowMenu(show: boolean) {
    this.showMenuSubject.next(show);
  }
}