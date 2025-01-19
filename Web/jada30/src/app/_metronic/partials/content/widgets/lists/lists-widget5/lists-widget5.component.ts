import { Component } from '@angular/core';
import { DropdownMenu1Component } from '../../../dropdown-menus/dropdown-menu1/dropdown-menu1.component';
import { KeeniconComponent } from 'src/app/_metronic/shared/keenicon/keenicon.component';

@Component({
  selector: 'app-lists-widget5',
  standalone: true, // Generated Stand-Alone Component
  templateUrl: './lists-widget5.component.html',
    imports: [KeeniconComponent, DropdownMenu1Component]

})
export class ListsWidget5Component {
  constructor() {}
}
