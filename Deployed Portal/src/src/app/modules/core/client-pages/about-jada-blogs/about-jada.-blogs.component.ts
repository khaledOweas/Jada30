import { Component, Injector, OnDestroy, OnInit } from "@angular/core";
import { PrimeNGConfig } from "primeng/api";
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

interface Blog {
  id: number;
  image: string;
  date: string;
  title: string;
  description: string;
  author: string;
}

@Component({
  selector: "app-about-jada-blogs",
  standalone: true,
  imports: [ RouterLink, RouterLinkActive,  CommonModule,
    // JadaCardSystemServiceComponent, 
    CardModule, ButtonModule],
  templateUrl: "./about-jada-blogs.component.html",
  styleUrl: "./about-jada-blogs.component.scss",
  providers: [CoreService]
})
export class AboutJadaBlogsComponent extends BaseComponent implements OnInit, OnDestroy  {

  apiurl= 'http://localhost:5000/api/Data/Endpoint2'


  constructor(private injector: Injector, private service: CoreService, private http: HttpClient,private PrimeNGConfig: PrimeNGConfig) {
    super(injector);
  }

  blogs: Blog[] = [
    {
      id: 1,
      image: '../../../../../assets/media/logos/about.png',
      date: 'هـ 1446/05/05',
      title: 'النجاح الشخصي',
      description: 'المركز التعليمي - هذا النص هو مثال لنص يمكن أن يستبدل في نفس المساحة...',
      author: 'عادل ميزات الفالح'
    },
    {
      id: 2,
      image: '../../../../../assets/media/logos/about.png',
      date: 'هـ 1446/05/05',
      title: 'تجربة تعليمية',
      description: 'هذا النص هو مثال لنص يمكن أن يستبدل في نفس المساحة...',
      author: 'أحمد محمد'
    },
    {
      id: 3,
      image: '../../../../../assets/media/logos/about.png',
      date: 'هـ 1446/05/05',
      title: 'تجربة تعليمية',
      description: 'لقد تم توليد هذا النص من مواد النص العربي...',
      author: 'سارة عبدالله'
    }
  ];
 
  currentIndex = 0;
  isMobile = false;
  autoRotateInterval: any;
  visibleBlogs: Blog[][]=[];
 
  ngOnInit() {
    this.PrimeNGConfig.ripple=true;
    this.checkScreenSize();
    window.addEventListener('resize', () => this.checkScreenSize());
   this.chunkBlogs();
    // Auto rotate only for mobile
    if (this.isMobile) {
      this.startAutoRotation();
    }
  }
 
  chunkBlogs(){
    this.visibleBlogs=[];
    for(let i=this.currentIndex;i< this.blogs.length;i=i+2){
      this.visibleBlogs.push(this.blogs.slice(i, i+2));
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
    this.currentIndex = (this.currentIndex < this.visibleBlogs.length - 1) ?
      this.currentIndex + 1 : 0;
  }
 
  prev() {
    this.currentIndex = (this.currentIndex > 0) ?
      this.currentIndex - 1 : this.visibleBlogs.length - 1;
  }
 
  ngOnDestroy() {
    clearInterval(this.autoRotateInterval);
    window.removeEventListener('resize', () => this.checkScreenSize());
  }
}
