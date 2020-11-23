import { Component, OnInit } from '@angular/core';
import { AccountService } from '../+services/account.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent implements OnInit {
  navbarCollapsed = true;
  leftLinks = [
    { title: 'Learning', url: '/learningResources' },
    { title: 'Code Challenges', url: '/codeChallenges' },
    { title: 'Mentor', url: '/mentor' }
  ]

  rightLinks = [
    { title: 'User Dashboard', url: '/userDashboard' },
    { title: 'Log Out', url: '/' }
  ]

  constructor(private accountService: AccountService) {}

  ngOnInit(): void {}

  toggleNavbarCollapsing() {
    this.navbarCollapsed = !this.navbarCollapsed;
  }

  handleNavbarClick(event) {
    if (!this.navbarCollapsed) {
      this.toggleNavbarCollapsing();
    }
    if (event.target.name === "Log Out") {
      this.logout()
    }
  }

  logout() {
    this.accountService.logout();
  }
}
