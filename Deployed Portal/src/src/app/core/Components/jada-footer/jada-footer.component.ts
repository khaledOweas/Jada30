import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
    selector: 'jada-footer',
    imports: [CommonModule],
    templateUrl: './jada-footer.component.html',
    styleUrl: './jada-footer.component.scss',
    providers: [],
    standalone: true
})
export class JadaFooterComponent {
    @Output() buttonClick = new EventEmitter<void>();
    @Input() language: 'arabic' | 'english' = 'arabic';
    @Input() mode: 'dark' | 'light' = 'light';
    @Input() cardtitle: string = 'Card Title';
    @Input() carddescription: string = 'Card description';
    @Input() carddate: string = '10 Jan 2024';

    handleClick() {
        this.buttonClick.emit();
    }

}
