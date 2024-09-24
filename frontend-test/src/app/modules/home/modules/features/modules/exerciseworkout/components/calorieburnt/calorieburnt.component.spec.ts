import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CalorieburntComponent } from './calorieburnt.component';

describe('CalorieburntComponent', () => {
  let component: CalorieburntComponent;
  let fixture: ComponentFixture<CalorieburntComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CalorieburntComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CalorieburntComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
