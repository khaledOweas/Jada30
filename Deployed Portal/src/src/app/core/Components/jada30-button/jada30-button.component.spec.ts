import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Jada30ButtonComponent } from './jada30-button.component';

describe('Jada30ButtonComponent', () => {
  let component: Jada30ButtonComponent;
  let fixture: ComponentFixture<Jada30ButtonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Jada30ButtonComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Jada30ButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
