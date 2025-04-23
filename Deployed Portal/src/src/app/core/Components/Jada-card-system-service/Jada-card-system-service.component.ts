import { Component, Input, OnInit } from '@angular/core';
import {  MessageService } from 'primeng/api';
import { ButtonModule } from 'primeng/button';
import { SplitButtonModule } from 'primeng/splitbutton';
import { ToastModule } from 'primeng/toast';
import { AvatarModule } from 'primeng/avatar';
import { StyleClassModule } from 'primeng/styleclass';
import { TreeModule } from 'primeng/tree';

import { CommonModule } from '@angular/common';


type ModeType = 'dark' | 'light';
type ProfileType = 'lessinfo' | 'fullinfo';
type SolidStatusType = 'success' | 'alert' | 'information' | 'danger' | 'primary' | 'secondary';
type SolidSizeType = 'large' | 'medium' | 'small' | 'x-small';
type FileStatusType = 'default' | 'warning' | 'danger';


@Component({
    selector: 'Jada-card-system-service',
    imports: [ ToastModule, ButtonModule, SplitButtonModule, StyleClassModule, AvatarModule, TreeModule, CommonModule],
    templateUrl: './Jada-card-system-service.component.html',
    styleUrl: './Jada-card-system-service.component.scss',
    providers: [MessageService],
    standalone: true
})
export class JadaCardSystemServiceComponent {
    @Input() language: 'arabic' | 'english' = 'english';
  @Input() mode: 'dark' | 'light' = 'light';
  @Input() size: 'small' | 'large' = 'large';
  @Input() state: 'selected' | 'default' = 'default';

  @Input() cardtitle: string = 'Video and Voice';
  @Input() cardsubtitle: string = 'Devices Service';
  @Input() cardnumber: string = '29%';

  // Showing and hiding different elements
  @Input() icon: 'true' | 'false' = 'true';
  @Input() counter: 'true' | 'false' = 'true';
  @Input() subtitle: 'true' | 'false' = 'true';

  // Props for Icon
  @Input() iconname: string = 'recycle';
  @Input() iconvariant: 'regular' | 'duotone' | 'solid' = 'solid';

  private iconsize: '2x-large' | 'large';
  private iconcolor: string;

  ngOnInit() {
    this.onNameChanged(this.size);
    this.onModeChanged(this.mode);
  }

  ngOnChanges() {
    this.onNameChanged(this.size);
    this.onModeChanged(this.mode);
  }

  private onNameChanged(size: 'large' | 'small') {
    if (size == 'large') this.iconsize = '2x-large';
    if (size == 'small') this.iconsize = 'large';
  }

  private onModeChanged(mode: 'dark' | 'light') {
    if (mode == 'light') this.iconcolor = '#02618d';
    if (mode == 'dark') this.iconcolor = '#5fcae6';
  }
    
  }