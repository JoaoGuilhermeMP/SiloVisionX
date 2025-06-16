import { TestBed } from '@angular/core/testing';

import { GeralInnerService } from './geral-inner.service';

describe('GeralInnerService', () => {
  let service: GeralInnerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GeralInnerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
