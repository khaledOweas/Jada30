import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JadaHeaderComponent } from './jada-header.component';

describe('JadaHeaderComponent', () => {
  let component: JadaHeaderComponent;
  let fixture: ComponentFixture<JadaHeaderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [JadaHeaderComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(JadaHeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
