import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JadaFooterComponent } from './jada-footer.component';

describe('JadaFooterComponent', () => {
  let component: JadaFooterComponent;
  let fixture: ComponentFixture<JadaFooterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [JadaFooterComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(JadaFooterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
