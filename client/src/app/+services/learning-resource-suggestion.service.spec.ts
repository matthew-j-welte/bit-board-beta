import { TestBed } from '@angular/core/testing';

import { LearningResourceSuggestionService } from './learning-resource-suggestion.service';

describe('LearningResourceSuggestionService', () => {
  let service: LearningResourceSuggestionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LearningResourceSuggestionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
