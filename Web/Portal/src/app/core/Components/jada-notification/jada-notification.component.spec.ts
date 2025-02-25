import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JadaNotificationComponent } from './jada-notification.component';

describe('JadaNotificationComponent', () => {
  let component: JadaNotificationComponent;
  let fixture: ComponentFixture<JadaNotificationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [JadaNotificationComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(JadaNotificationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
