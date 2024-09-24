import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TargetcaloriemodalComponent } from './targetcaloriemodal.component';

describe('TargetcaloriemodalComponent', () => {
  let component: TargetcaloriemodalComponent;
  let fixture: ComponentFixture<TargetcaloriemodalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TargetcaloriemodalComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TargetcaloriemodalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
