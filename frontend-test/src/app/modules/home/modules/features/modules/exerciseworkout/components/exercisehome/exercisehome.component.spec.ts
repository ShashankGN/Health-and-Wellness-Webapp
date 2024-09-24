import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExercisehomeComponent } from './exercisehome.component';

describe('ExercisehomeComponent', () => {
  let component: ExercisehomeComponent;
  let fixture: ComponentFixture<ExercisehomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ExercisehomeComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ExercisehomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
