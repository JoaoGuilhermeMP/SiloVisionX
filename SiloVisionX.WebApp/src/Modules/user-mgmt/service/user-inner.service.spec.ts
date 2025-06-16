import { TestBed } from '@angular/core/testing';

import { UserInnerService } from './user-inner.service';

describe('UserInnerService', () => {
  let service: UserInnerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UserInnerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
