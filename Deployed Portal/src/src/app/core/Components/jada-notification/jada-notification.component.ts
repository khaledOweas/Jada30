import { Component, Input, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { ButtonModule } from 'primeng/button';
import { SplitButtonModule } from 'primeng/splitbutton';
import { ToastModule } from 'primeng/toast';
import { AvatarModule } from 'primeng/avatar';
import { StyleClassModule } from 'primeng/styleclass';
import { TreeModule } from 'primeng/tree';

import { CommonModule } from '@angular/common';

@Component({
    selector: 'jada-notification',
    imports: [ToastModule, ButtonModule, SplitButtonModule, StyleClassModule, AvatarModule, TreeModule, CommonModule],
    templateUrl: './jada-notification.component.html',
    styleUrl: './jada-notification.component.scss',
    providers: [MessageService],
    standalone: true
})
export class JadaNotificationComponent {

    @Input() language: 'arabic' | 'english' = 'arabic';
    @Input() mode: 'dark' | 'light' = 'light';
    @Input() label: string = 'تنبيه جديد بوجود مشكلة ما';
    @Input() closebutton: 'true' | 'false' = 'true';
    @Input() gridview: 'outside' | 'inside' = 'inside';
    @Input() status: 'information' | 'alert' | 'success' | 'danger' | 'critical' = 'information';
    @Input() hasicon:boolean=true;
    @Input() iconname: string='pi pi-calculator'

}