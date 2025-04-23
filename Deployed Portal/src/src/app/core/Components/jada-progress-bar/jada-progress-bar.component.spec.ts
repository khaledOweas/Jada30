import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JadaProgressBarComponent } from './jada-progress-bar.component';

describe('JadaProgressBarComponent', () => {
  let component: JadaProgressBarComponent;
  let fixture: ComponentFixture<JadaProgressBarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [JadaProgressBarComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(JadaProgressBarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
