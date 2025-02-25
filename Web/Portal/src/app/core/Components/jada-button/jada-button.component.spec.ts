import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JadaButtonComponent } from './jada-button.component';

describe('JadaButtonComponent', () => {
  let component: JadaButtonComponent;
  let fixture: ComponentFixture<JadaButtonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [JadaButtonComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(JadaButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
