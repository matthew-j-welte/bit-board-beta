import { Component, OnInit } from '@angular/core';

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
    { title: 'Code Reviews', url: '/codeReviews' }
  ]

  rightLinks = [
    { title: 'User Dashboard', url: '/userDashboard' },
    { title: 'Log Out', url: '/home' }
  ]

  constructor() {}

  ngOnInit(): void {}

  toggleNavbarCollapsing() {
    this.navbarCollapsed = !this.navbarCollapsed;
  }

  handleDropdownClick() {
    if (!this.navbarCollapsed) {
      this.toggleNavbarCollapsing();
    }
  }
}
