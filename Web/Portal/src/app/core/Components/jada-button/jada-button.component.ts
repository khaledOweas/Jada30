import { Component, Input, Output, EventEmitter, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { CommonModule } from '@angular/common';
@Component({
    selector: 'jada-button',
    imports: [CommonModule],
    templateUrl: './jada-button.component.html',
    styleUrl: './jada-button.component.scss',
    standalone:true
})
export class JadaButtonComponent implements OnInit, OnChanges {
  @Output() buttonClick = new EventEmitter<void>();

  @Input() language: 'arabic' | 'english' = 'english';
  @Input() mode: 'dark' | 'light' = 'light';
  @Input() size: 'medium' | 'large' | 'small' | 'x-small' = 'large';
  @Input() background: 'fill' | 'outline' | 'no-fill' | 'bezeled' = 'no-fill';
  @Input() state: 'disabled' | 'enabled' = 'enabled';
  @Input() type: 'text' | 'icon' | 'text-icon' = 'text-icon';
  @Input() iconposition: 'ending' | 'leading' = 'leading';
  @Input() radius: 'circled' | 'rounded' = 'circled';
  @Input() width: 'normal' | 'wide' = 'normal';
  @Input() label: string = 'Action';
  @Input() icolor: string = ''; // default to white
  @Input() status: 'success' | 'alert' | 'information' | 'danger' | 'primary' | 'secondary' | 'disabled' = 'primary';
  @Input() iconname: string = 'gear';
  @Input() iconvariant:'solid' | 'duotone' | 'regular' = 'solid';
  @Input() iconsize: 'medium' | 'large' | 'small' | 'x-small' = 'large';
  @Input() badge: 'true' | 'false' = 'false';
  @Input() badgelabel: string = '99';
  @Input() badgestatus: 'disabled' | 'hint' | 'success' | 'alert' | 'information' | 'danger' | 'primary' | 'secondary' = 'alert';
  @Input() badgeradius: 'circled' | 'rounded' = 'circled';
  @Input() badgesize: 'medium' | 'small' = 'medium';
  @Input() badgebackground: 'fill' | 'no-fill' = 'fill';

  iconcolor: string = '#ffffff';

  ngOnInit() {
    this.determineIconColor();
    this.determineIconSize();
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['mode'] || changes['background'] || changes['state'] || changes['language'] || changes['size']) {
      this.determineIconColor();
      this.determineIconSize();
    }
  }

  handleClick() {
    this.buttonClick.emit();
  }

  determineIconColor() {
    if (this.mode === 'light') {
      if (this.state === 'enabled') {
        if (this.background === 'fill') this.iconcolor = '#ffffff';
        if (this.background === 'no-fill') this.iconcolor = '#02618D';
        if (this.background === 'outline') this.iconcolor = '#02618D';
        if (this.background === 'bezeled') this.iconcolor = '#02618D';
      }
      if (this.state === 'disabled') {
        if (this.background === 'fill') this.iconcolor = '#DCE0E3';
        if (this.background === 'outline') this.iconcolor = '#B9BDC0';
        if (this.background === 'no-fill') this.iconcolor = '#B9BDC0';
        if (this.background === 'bezeled') this.iconcolor = '#B9BDC0';
      }
    }
    if (this.mode === 'dark') {
      if (this.state === 'enabled') {
        if (this.background === 'fill') this.iconcolor = '#02618D';
        if (this.background === 'outline') this.iconcolor = '#5FCAE6';
        if (this.background === 'no-fill') this.iconcolor = '#5FCAE6';
        if (this.background === 'bezeled') this.iconcolor = '#02618D';
      }
      if (this.state === 'disabled') {
        if (this.background === 'fill') this.iconcolor = '#5E6163';
        if (this.background === 'outline') this.iconcolor = '#5E6163';
        if (this.background === 'no-fill') this.iconcolor = '#5E6163';
        if (this.background === 'bezeled') this.iconcolor = '#5E6163';
      }
    }
  }

  determineIconSize() {
    if (this.size === 'large' || this.size === 'medium') {
      this.iconsize = 'large';
    } else if (this.size === 'small' || this.size === 'x-small') {
      this.iconsize = 'medium';
    }
  }
}
