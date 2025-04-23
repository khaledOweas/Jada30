import { Component, Injector, OnInit } from "@angular/core";

import { Observable, takeUntil } from "rxjs";
import { BaseComponent } from "src/app/core/Components/base/base.component";
import { ApplicationRole, BooleanBaseResponse } from "src/app/services/IdentityService";
import { CoreService } from "src/app/services/CoreService";
import { RouterLink, RouterLinkActive } from "@angular/router";
import Swal from "sweetalert2";
import { ColumnManager, ListColumnType } from "src/app/data/DataTableColumnData";

import { CardModule } from 'primeng/card';
import { ButtonModule } from "primeng/button";
import { CommonModule } from "@angular/common";
import { HttpClient } from "@angular/common/http";

interface Story {
  id: number;
  image: string;
  date: string;
  title: string;
  description: string;
  author: string;
}

@Component({
  selector: "app-about-jada-news",
  standalone: true,
  imports: [ RouterLink, RouterLinkActive,  CommonModule,
    CardModule, ButtonModule],
  templateUrl: "./about-jada-news.component.html",
  styleUrl: "./about-jada-news.component.scss",
  providers: [CoreService]
})
export class AboutJadaNewsComponent extends BaseComponent implements OnInit  {

  apiurl= 'http://localhost:5000/api/Data/Endpoint2'


  constructor(private injector: Injector, private service: CoreService, private http: HttpClient) {
    super(injector);
  }

  stories: Story[] = [
    {
      id: 1,
      image: '../../../../../assets/media/logos/news.jpg',
      date: 'هـ 1446/05/05',
      title: 'جائزة',
      description: 'جادة 30 يفوز بجائزة دولية لأفضل مشروع تحول في المملكة للمشاريع الناشئة',
      author: 'عادل ميزات الفالح'
    },
    {
      id: 2,
      image: '../../../../../assets/media/logos/news.jpg',
      date: 'هـ 1446/05/05',
      title: 'خبر 2',
      description: 'هذا النص هو مثال لنص يمكن أن يستبدل في نفس المساحة...',
      author: 'أحمد محمد'
    },
    {
      id: 3,
      image: '../../../../../assets/media/logos/news.jpg',
      date: 'هـ 1446/05/05',
      title: 'خبر 3',
      description: 'لقد تم توليد هذا النص من مواد النص العربي...',
      author: 'سارة عبدالله'
    }
  ];
 
  currentIndex = 0;
  isMobile = false;
  autoRotateInterval: any;
 
  ngOnInit() {
    this.checkScreenSize();
    window.addEventListener('resize', () => this.checkScreenSize());
   
    // Auto rotate only for mobile
    if (this.isMobile) {
      this.startAutoRotation();
    }
  }
 
  checkScreenSize() {
    this.isMobile = window.innerWidth < 768;
    if (!this.isMobile) {
      clearInterval(this.autoRotateInterval);
    } else if (!this.autoRotateInterval) {
      this.startAutoRotation();
    }
  }
 
  startAutoRotation() {
    this.autoRotateInterval = setInterval(() => {
      this.next();
    }, 5000);
  }
 
  goTo(index: number) {
    this.currentIndex = index;
  }
 
  next() {
    this.currentIndex = (this.currentIndex < this.stories.length - 1) ?
      this.currentIndex + 1 : 0;
  }
 
  prev() {
    this.currentIndex = (this.currentIndex > 0) ?
      this.currentIndex - 1 : this.stories.length - 1;
  }
 
  ngOnDestroy() {
    clearInterval(this.autoRotateInterval);
    window.removeEventListener('resize', () => this.checkScreenSize());
  }
}
