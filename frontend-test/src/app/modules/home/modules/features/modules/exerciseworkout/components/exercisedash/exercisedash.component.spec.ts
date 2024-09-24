import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExercisedashComponent } from './exercisedash.component';

describe('ExercisedashComponent', () => {
  let component: ExercisedashComponent;
  let fixture: ComponentFixture<ExercisedashComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ExercisedashComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ExercisedashComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
