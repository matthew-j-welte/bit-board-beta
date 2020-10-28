import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SkillProgressionBarComponent } from './skill-progression-bar.component';

describe('SkillProgressionBarComponent', () => {
  let component: SkillProgressionBarComponent;
  let fixture: ComponentFixture<SkillProgressionBarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SkillProgressionBarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SkillProgressionBarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
