import { TestBed } from '@angular/core/testing';

import { CmpService } from './cmp.service';

describe('CmpService', () => {
  let service: CmpService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CmpService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
