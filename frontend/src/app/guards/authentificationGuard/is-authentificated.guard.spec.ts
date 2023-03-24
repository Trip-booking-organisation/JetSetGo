import { TestBed } from '@angular/core/testing';

import { IsAuthentificatedGuard } from './is-authentificated.guard';

describe('IsAuthentificatedGuard', () => {
  let guard: IsAuthentificatedGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(IsAuthentificatedGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
