import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CmprecipeComponent } from './cmprecipe.component';

describe('CmprecipeComponent', () => {
  let component: CmprecipeComponent;
  let fixture: ComponentFixture<CmprecipeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CmprecipeComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CmprecipeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
