import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LearningResourceDetailComponent } from './learning-resource-detail.component';

describe('LearningResourceDetailComponent', () => {
  let component: LearningResourceDetailComponent;
  let fixture: ComponentFixture<LearningResourceDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LearningResourceDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LearningResourceDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
