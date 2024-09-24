import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CmpbmiComponent } from './cmpbmi.component';

describe('CmpbmiComponent', () => {
  let component: CmpbmiComponent;
  let fixture: ComponentFixture<CmpbmiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CmpbmiComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CmpbmiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
