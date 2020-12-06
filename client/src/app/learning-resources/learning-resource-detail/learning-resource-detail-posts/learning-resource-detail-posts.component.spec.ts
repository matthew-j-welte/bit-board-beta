import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LearningResourceDetailPostsComponent } from './learning-resource-detail-posts.component';

describe('LearningResourceDetailPostsComponent', () => {
  let component: LearningResourceDetailPostsComponent;
  let fixture: ComponentFixture<LearningResourceDetailPostsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LearningResourceDetailPostsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LearningResourceDetailPostsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
