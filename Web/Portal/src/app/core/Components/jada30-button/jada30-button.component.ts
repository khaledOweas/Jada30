import { Component, Input, Output, EventEmitter, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { CommonModule } from '@angular/common';
import {ButtonModule} from 'primeng/button'
@Component({
  selector: 'jada30-button',
  imports: [CommonModule, ButtonModule],
  templateUrl: './jada30-button.component.html',
  styleUrl: './jada30-button.component.scss',
  standalone: true
})
export class Jada30ButtonComponent implements OnInit, OnChanges {
  @Output() buttonClick = new EventEmitter<void>();

  // @Input() mode: 'dark' | 'light' = 'light';
  @Input() size: 'default' | 'large' | 'small' = 'large';
  @Input() style: 'outline' | 'fill' = 'fill';
  @Input() width: 'default' | 'wide' = 'wide';
  @Input() corners: 'circled' | 'rounded' = 'rounded';
  @Input() state: 'disabled' | 'enabled' = 'enabled';
  @Input() label: string = 'Action';
  @Input() hasicon:boolean=true;
  @Input() iconname: string = 'pi pi-sign-in';

  @Input() icolor: string = ''; // default to white

  iconcolor: string = '#ffffff';

  ngOnInit() {
    this.determineIconColor();
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['size'] || changes['style'] || changes['width'] || changes['corners'] || changes['state']) {
      this.determineIconColor();
    }
  }

  handleClick() {
    this.buttonClick.emit();
  }

  determineIconColor() {
      if (this.state === 'enabled') {
        if (this.style === 'fill') this.iconcolor = '#ffffff';
        if (this.style === 'outline') this.iconcolor = '#02618D';
      }
      if (this.state === 'disabled') {
        if (this.style === 'fill') this.iconcolor = '#DCE0E3';
        if (this.style === 'outline') this.iconcolor = '#B9BDC0';
      }
    }

    // Define the buttonClasses object
  get buttonClasses() {
    return {
      'button--light':true,
      'button--container': true,
      'button--primary':true,
      'button--text':true,
      ['buttonw--' + this.size]: true,
      ['button--' + this.style]: true,
      ['button--' + this.state]: true,
      ['button--' + this.corners]: true,
      ['button--' + this.width]: true,
    };
  }
  }


