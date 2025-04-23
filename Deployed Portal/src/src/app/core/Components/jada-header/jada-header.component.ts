import { Component, Input, OnInit, ElementRef, Renderer2 } from '@angular/core';
import { MenuItem, MessageService } from 'primeng/api';
import { MenubarModule } from 'primeng/menubar';
import { ButtonModule } from 'primeng/button';
import { SplitButtonModule } from 'primeng/splitbutton';
import { ToastModule } from 'primeng/toast';
import { AvatarModule } from 'primeng/avatar';
import { StyleClassModule } from 'primeng/styleclass';
import { TreeModule } from 'primeng/tree';
import { TreeNode } from 'primeng/api';
// import { JadaButtonComponent } from "../jada-button/jada-button.component";
import { CommonModule } from '@angular/common';

import { AuthService, UserType } from "../../../modules/auth";

@Component({
    selector: 'jada-header',
    imports: [MenubarModule, ToastModule, ButtonModule, SplitButtonModule, StyleClassModule, AvatarModule, TreeModule, CommonModule],
    templateUrl: './jada-header.component.html',
    styleUrl: './jada-header.component.scss',
    providers: [MessageService],
    standalone: true
})
export class JadaHeaderComponent implements OnInit {
    @Input() mode: "light" | "dark" = "light";
    @Input() language: string = "ar";
    @Input() state: "default" | "loggedin" = "default";
    @Input() useravatar: string = "./assets/media/avatars/300-3.jpg";
    @Input() username: string = "مستخدم 1";
    @Input() avatarusername: string = "";

    languagelabel: string = "Arabic";


    items: MenuItem[] | undefined;
    // treeitems!: TreeNode[];

    treeselecteditem!: TreeNode;
    treeitems: MenuItem[] | undefined;

    constructor(private messageService: MessageService,
        private auth: AuthService,
        private el: ElementRef,
        private renderer: Renderer2) {
        this.language = localStorage.getItem("language") ?? "ar";
    }

    ngOnInit() {
        this.getUserName();
        this.getAvatarUserName();
        this.items = [
            {
                label: 'الرئيسية',
                command: () => {
                    this.messageService.add({ severity: 'warn', summary: 'Main Results', detail: 'No results found', life: 3000 });
                },
                routerLink: '/dashboard'
            },
            {
                label: 'الفروع',
                command: () => {
                    this.messageService.add({ severity: 'warn', summary: 'Branches Results', detail: 'No results found', life: 3000 });
                },
                routerLink: "/branch/branch-list"
            },
            {
                separator: true
            },
            {
                label: 'المرافق',
                command: () => {
                    this.messageService.add({ severity: 'warn', summary: 'Branches Results', detail: 'No results found', life: 3000 });
                },
                routerLink: "/facility/facility-list"
            },
            {
                label: 'المحتوى الإعلامي',
                command: () => {
                    this.messageService.add({ severity: 'warn', summary: 'Branches Results', detail: 'No results found', life: 3000 });
                },
                routerLink: "/client-pages/about-jada"
            },
            // {
            //     label: 'المحتوى الإعلامي',
            //     items: [
            //         {
            //             label: ' عن جادة30',
            //             icon: 'pi pi-info-circle',
            //             command: () => {
            //                 this.messageService.add({ severity: 'info', summary: 'Downloads', detail: 'Downloaded from cloud', life: 3000 });
            //             }
            //         },
            //         {
            //             label: ' أخبار ',
            //             icon: 'pi pi-file',
            //             command: () => {
            //                 this.messageService.add({ severity: 'info', summary: 'Shared', detail: 'Exported to cloud', life: 3000 });
            //             }
            //         },
            //         {
            //             label: ' قصص نجاح',
            //             icon: 'pi pi-check-circle',
            //             command: () => {
            //                 this.messageService.add({ severity: 'info', summary: 'Shared', detail: 'Exported to cloud', life: 3000 });
            //             }
            //         },
            //         {
            //             label: ' المدونات',
            //             icon: 'pi pi-pencil',
            //             command: () => {
            //                 this.messageService.add({ severity: 'info', summary: 'Shared', detail: 'Exported to cloud', life: 3000 });
            //             }
            //         },
            //         {
            //             label: 'الصور و الفيديوهات',
            //             icon: 'pi pi-images',
            //             command: () => {
            //                 this.messageService.add({ severity: 'info', summary: 'Shared', detail: 'Exported to cloud', life: 3000 });
            //             }
            //         }

            //     ]
            // },
            {
                label: 'فعاليات جادة 30',
                command: () => {
                    this.messageService.add({ severity: 'warn', summary: 'Main Results', detail: 'No results found', life: 3000 });
                },
                routerLink: "/event/event-list"
            },
            {
                label: 'الأسئلة الشائعة',
                command: () => {
                    this.messageService.add({ severity: 'warn', summary: 'Main Results', detail: 'No results found', life: 3000 });
                },
                routerLink: "/client-pages/faq"
            }
        ];
        this.treeitems = [
            {
                label: this.username,
                items: [
                    {
                        label: 'إعدادات الحساب',
                        icon: 'pi pi-user',
                        routerLink: '/user-settings',
                        command: () => {
                            this.messageService.add({ severity: 'info', summary: 'Downloads', detail: 'Downloaded from cloud', life: 3000 });
                        }
                    },
                    {
                        label: 'تسجيل الخروج',
                        icon: 'pi pi-sign-out',
                        command: () => {
                            this.logout(); // Call the logout function
                        },
                    }
                ]
            }
            // {
            //     key: '0',
            //     label: this.username,
            //     children: [
            //         {
            //             key: '0-0',
            //             label: 'إعدادات الحساب',
            //             data:'https://angular.io',
            //             type:'url'
            //         },
            //         {
            //             key: '0-1',
            //             label: 'تسجيل الخروج',
            //             data:'https://angular.io',
            //             type:'url'
            //         }
            //     ]
            // }
        ];
    }

    // toggleLanguage() {
    //     this.language = this.language == "Arabic" ? "English" : "Arabic"
    //     // Add your language toggle logic here
    // }

    toggleMode() {
        this.mode = this.mode === "dark" ? "light" : "dark";
        // Add your mode toggle logic here
    }

    getUserName(): void {
        if (typeof localStorage !== "undefined") {
            const user = localStorage.getItem("user");
            if (user) {
                this.username = JSON.parse(user).nameAr;
            }
        }
    }
    getAvatarUserName(): void {
        // if (typeof localStorage !== "undefined") {
        //     const user = localStorage.getItem("user");
        //     if (user) {
        //         this.avatarusername = JSON.parse(user).nameEn.substring(0, 2);
        //     }

        // }
    }
    logout() {
        this.auth.logout();
        // document.location.reload();
    }
    toggleLanguage() {
        this.language = this.language == "ar" ? "en" : "ar"
        // this.langs.forEach((language: LanguageFlag) => {
        //   if (language.lang === lang) {
        //     language.active = true;
        //     this.language = language;
        //   } else {
        //     language.active = false;
        //   }
        if (this.language == "ar") {
            this.changeStylesheet("s2", "assets/css/style.rtl.css");
            this.changeStylesheet("s3", "assets/css/global.rtl.css");
            this.toggleDirection(false);
            this.languagelabel="Arabic";
        } else {
            this.changeStylesheet("s2", "assets/css/style.css");
            this.changeStylesheet("s3", "assets/css/global.ltr.css");
            this.toggleDirection(true);
            this.languagelabel="English";
        }
        console.log("lang: "+ this.language)
    }
    toggleDirection(isLTR: boolean): void {
        const htmlElement = this.el.nativeElement.ownerDocument.documentElement;
        const body = this.el.nativeElement.ownerDocument.body;
        const sideBar = document.getElementById("kt_app_sidebar");
        if (isLTR) {
            // Switch to LTR
            // this.renderer.setAttribute(htmlElement, "direction", "ltr");
            // this.renderer.setAttribute(htmlElement, "dir", "ltr");
            // this.renderer.setStyle(htmlElement, "direction", "ltr");
            // this.renderer.setStyle(sideBar, "direction", "ltr");
            this.renderer.setStyle(body, "direction", "ltr");
        } else {
            // Switch to RTL
            // this.renderer.setAttribute(htmlElement, "direction", "rtl");
            // this.renderer.setAttribute(htmlElement, "dir", "rtl");
            // this.renderer.setStyle(htmlElement, "direction", "rtl");
            // this.renderer.setStyle(sideBar, "direction", "rtl");
            this.renderer.setStyle(body, "direction", "rtl");
        }
        localStorage.setItem("dir", isLTR ? "en" : "ar");
    }
    changeStylesheet(id: string, newHref: string): void {
        const linkElement = document.getElementById(id) as HTMLLinkElement;
        if (linkElement) {
            linkElement.href = newHref;
        } else {
            console.error("Link element not found");
        }
    }
}
