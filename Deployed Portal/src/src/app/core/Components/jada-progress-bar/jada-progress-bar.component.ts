import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
    selector: 'jada-progress-bar',
    imports: [CommonModule],
    templateUrl: './jada-progress-bar.component.html',
    styleUrl: './jada-progress-bar.component.scss',
    providers: [],
    standalone: true
})
export class JadaProgressBarComponent {
    // Default values for the inputs
    @Input() language: 'arabic' | 'english' = 'english';
    @Input() mode: 'dark' | 'light' = 'light';
    @Input() progress: number = 80;
  
    get status(): 'default' | 'success' | 'alert' | 'warn' | 'danger' {
      if (this.progress > 0 && this.progress <= 25) {
        return 'danger';
      } else if (this.progress > 25 && this.progress <= 50) {
        return 'alert';
      } else if (this.progress > 50 && this.progress <= 75) {
        return 'warn';
      } else if (this.progress > 75) {
        return 'success';
      } else {
        return 'default';
      }
    }
  }