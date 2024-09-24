import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomizedexerciseComponent } from './customizedexercise.component';

describe('CustomizedexerciseComponent', () => {
  let component: CustomizedexerciseComponent;
  let fixture: ComponentFixture<CustomizedexerciseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CustomizedexerciseComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CustomizedexerciseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
