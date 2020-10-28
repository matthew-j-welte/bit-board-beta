import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserDashboardSidenavComponent } from './user-dashboard-sidenav.component';

describe('UserDashboardSidenavComponent', () => {
  let component: UserDashboardSidenavComponent;
  let fixture: ComponentFixture<UserDashboardSidenavComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserDashboardSidenavComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UserDashboardSidenavComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
