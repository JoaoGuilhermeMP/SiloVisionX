import { TestBed } from '@angular/core/testing';

import { RoleInnerService } from './role-inner.service';

describe('RoleInnerService', () => {
  let service: RoleInnerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RoleInnerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
