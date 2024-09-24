import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TargetgaincaloriemodalComponent } from './targetgaincaloriemodal.component';

describe('TargetgaincaloriemodalComponent', () => {
  let component: TargetgaincaloriemodalComponent;
  let fixture: ComponentFixture<TargetgaincaloriemodalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TargetgaincaloriemodalComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TargetgaincaloriemodalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
