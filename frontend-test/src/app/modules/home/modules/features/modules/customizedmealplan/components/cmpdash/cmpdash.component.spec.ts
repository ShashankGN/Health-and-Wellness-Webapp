import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CmpdashComponent } from './cmpdash.component';

describe('CmpdashComponent', () => {
  let component: CmpdashComponent;
  let fixture: ComponentFixture<CmpdashComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CmpdashComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CmpdashComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
