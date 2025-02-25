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
    selector: 'jada-card-data',
    imports: [ ToastModule, ButtonModule, SplitButtonModule, StyleClassModule, AvatarModule, TreeModule, CommonModule],
    templateUrl: './jada-card-data.component.html',
    styleUrl: './jada-card-data.component.scss',
    providers: [MessageService],
    standalone: true
})
export class JadaCardDataComponent {
    mode: ModeType = 'light';
    @Input() profile: ProfileType = 'fullinfo';
  
    @Input() subtitle: string = '120 ريال / الطاولة';
    @Input() cardtitle: string = 'مقهى';
    @Input() cardnote: string = 'Note: شامل الضريبة';
    // @Input() cardlabel: string = 'Request has been rejected';
    @Input() carddescription: string = 'تفاصيل بسيطة عن المقهى لا تتعدى السطر';
  
    // @Input() status: 'true' | 'false' = 'false';
    @Input() hassubtitle: boolean=true;
    @Input() details: 'true' | 'false' = 'true';
    @Input() hasnote: boolean= true;
    
  }