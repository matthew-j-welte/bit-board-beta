import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LearningResourceDetailJumbotronComponent } from './learning-resource-detail-jumbotron.component';

describe('LearningResourceDetailJumbotronComponent', () => {
  let component: LearningResourceDetailJumbotronComponent;
  let fixture: ComponentFixture<LearningResourceDetailJumbotronComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LearningResourceDetailJumbotronComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LearningResourceDetailJumbotronComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
