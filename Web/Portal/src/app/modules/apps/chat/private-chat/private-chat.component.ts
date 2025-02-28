import { Component, HostBinding, OnInit } from '@angular/core';

@Component({
  selector: 'app-private-chat',
  standalone: true, // Generated Stand-Alone Component
  templateUrl: './private-chat.component.html',
  styleUrls: ['./private-chat.component.scss'],
})
export class PrivateChatComponent implements OnInit {
  @HostBinding('class') class = 'd-flex flex-column flex-lg-row';

  constructor() {}

  ngOnInit(): void {}
}
