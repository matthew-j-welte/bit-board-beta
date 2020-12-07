import { TestBed } from '@angular/core/testing';

import { LearningResourceGuard } from './learning-resource.guard';

describe('LearningResourceGuard', () => {
  let guard: LearningResourceGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(LearningResourceGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
