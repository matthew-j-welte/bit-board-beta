import { Component, OnInit } from '@angular/core';
import { UserModel } from '../+models/user_model';
import { UsersService } from '../+services/users.service';

@Component({
  selector: 'app-user-dashboard',
  templateUrl: './user-dashboard.component.html',
  styleUrls: ['./user-dashboard.component.css'],
})
export class UserDashboardComponent implements OnInit {
  user: UserModel;

  constructor(private usersService: UsersService) {}

  ngOnInit(): void {
    this.loadUserData();
  }

  loadUserData() {
    this.usersService.getUser().subscribe((res) => {
      this.user = res;
    });
  }
}
