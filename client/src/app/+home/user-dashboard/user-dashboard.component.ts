import { Component, OnInit } from '@angular/core';
import { UserSkill } from '../../shared/models/dtos/user_skill_dto';
import { UserModel } from '../../shared/models/user_model';
import { UsersService } from '../../shared/services/users.service';

@Component({
  selector: 'app-user-dashboard',
  templateUrl: './user-dashboard.component.html',
  styleUrls: ['./user-dashboard.component.scss'],
})
export class UserDashboardComponent implements OnInit {
  user: UserModel;

  constructor(private usersService: UsersService) {}

  ngOnInit(): void {
    this.loadUserData();
  }

  async loadUserData(): Promise<void> {
    this.usersService.getUserModel()?.subscribe((res) => {
      this.user = res;
    });
  }

  getSortedSkills(): UserSkill[] {
    return this.user?.userSkills.sort(
      (x, y) => y.progressPercent - x.progressPercent
    );
  }
}
