import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResourceSuggestionComponent } from './resource-suggestion.component';

describe('ResourceSuggestionComponent', () => {
  let component: ResourceSuggestionComponent;
  let fixture: ComponentFixture<ResourceSuggestionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ResourceSuggestionComponent],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ResourceSuggestionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
