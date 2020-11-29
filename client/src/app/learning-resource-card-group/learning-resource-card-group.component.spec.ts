import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LearningResourceCardGroupComponent } from './learning-resource-card-group.component';

describe('LearningResourceCardGroupComponent', () => {
  let component: LearningResourceCardGroupComponent;
  let fixture: ComponentFixture<LearningResourceCardGroupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LearningResourceCardGroupComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LearningResourceCardGroupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
