import { Component, Injector, OnInit } from "@angular/core";

import { Observable, takeUntil } from "rxjs";
import { BaseComponent } from "src/app/core/Components/base/base.component";
import { ApplicationRole, BooleanBaseResponse } from "src/app/services/IdentityService";
import { CoreService } from "src/app/services/CoreService";
import { RouterLink, RouterLinkActive } from "@angular/router";



import { CardModule } from 'primeng/card';
import { ButtonModule } from "primeng/button";
import { CommonModule } from "@angular/common";
import { HttpClient } from "@angular/common/http";

interface FaqItem {
  question: string;
  answer: string;
  isExpanded: boolean;
}
 
interface FaqGroup {
  title: string;
  description: string;
  items: FaqItem[];
}
@Component({
  selector: "app-frequently-asked-questions",
  standalone: true,
  imports: [ RouterLink, RouterLinkActive,  CommonModule,

    // JadaCardSystemServiceComponent, 
    CardModule, ButtonModule],
  templateUrl: "./frequently-asked-questions.component.html",
  styleUrl: "./frequently-asked-questions.component.scss",
  providers: [CoreService]
})
export class FrequentlyAskedQuestionsComponent  extends BaseComponent  {

  apiurl= 'http://localhost:5000/api/Data/Endpoint2'


  constructor(private injector: Injector, private service: CoreService, private http: HttpClient) {
    super(injector);
  }

  faqGroups: FaqGroup[] = [
    {
      title: 'الأسئلة الشائعة',
      description: 'هذا النص هو مثال لنص يمكن أن يستبدل في نفس المساحة...',
      items: [
        {
          question: 'كم من الوقت يستغرق توصيل طلبي؟',
          answer: 'متوسط وقت التوصيل من 2-5 أيام عمل حسب الموقع.',
          isExpanded: false
        },
        {
          question: 'ما هي مناطق التوصيل؟',
          answer: 'نقوم بالتوصيل لجميع أنحاء المملكة.',
          isExpanded: false
        },
        {
          question: 'ما هي طرق الدفع المتاحة؟',
          answer: 'نقبل الدفع نقداً عند الاستلام وبالبطاقات الائتمانية.',
          isExpanded: false
        },
        {
          question: 'هل الدفع آمن؟',
          answer: 'نعم جميع عمليات الدفع مؤمنة بالكامل.',
          isExpanded: false
        }
      ]
    }
  ];
 
  toggleItem(item: FaqItem): void {
    item.isExpanded = !item.isExpanded;
  }
}
