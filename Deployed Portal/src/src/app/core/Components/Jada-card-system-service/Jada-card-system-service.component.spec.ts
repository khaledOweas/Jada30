import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JadaCardSystemServiceComponent } from './Jada-card-system-service.component';

describe('JadaCardSystemServiceComponent', () => {
  let component: JadaCardSystemServiceComponent;
  let fixture: ComponentFixture<JadaCardSystemServiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [JadaCardSystemServiceComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(JadaCardSystemServiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
