import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CaloriegainedComponent } from './caloriegained.component';

describe('CaloriegainedComponent', () => {
  let component: CaloriegainedComponent;
  let fixture: ComponentFixture<CaloriegainedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CaloriegainedComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CaloriegainedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
