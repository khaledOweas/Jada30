import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JadaInputComponent } from './jada-input.component';

describe('JadaInputComponent', () => {
  let component: JadaInputComponent;
  let fixture: ComponentFixture<JadaInputComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [JadaInputComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(JadaInputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
