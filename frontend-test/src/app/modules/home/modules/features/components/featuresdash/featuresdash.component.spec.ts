import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FeaturesdashComponent } from './featuresdash.component';

describe('FeaturesdashComponent', () => {
  let component: FeaturesdashComponent;
  let fixture: ComponentFixture<FeaturesdashComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FeaturesdashComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FeaturesdashComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
