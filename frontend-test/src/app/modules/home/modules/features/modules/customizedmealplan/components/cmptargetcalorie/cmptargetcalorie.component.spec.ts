import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CmptargetcalorieComponent } from './cmptargetcalorie.component';

describe('CmptargetcalorieComponent', () => {
  let component: CmptargetcalorieComponent;
  let fixture: ComponentFixture<CmptargetcalorieComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CmptargetcalorieComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CmptargetcalorieComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
