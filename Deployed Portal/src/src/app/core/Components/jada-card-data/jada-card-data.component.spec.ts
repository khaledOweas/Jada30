import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JadaCardDataComponent } from './jada-card-data.component';

describe('JadaCardDataComponent', () => {
  let component: JadaCardDataComponent;
  let fixture: ComponentFixture<JadaCardDataComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [JadaCardDataComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(JadaCardDataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
