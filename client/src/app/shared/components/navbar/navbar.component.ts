import { Component, OnInit } from '@angular/core';
import { APP_ROUTES } from '../../constants/routes/app-routes';
import { HOME_ROUTES } from '../../constants/routes/home-routes';
import { LEARNING_ROUTES } from '../../constants/routes/learning-routes';
import { MENTORING_ROUTES } from '../../constants/routes/mentoring-routes';
import { AccountService } from '../../services/account.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent implements OnInit {
  navbarCollapsed = true;
  leftLinks = [
    {
      title: 'Learning',
      url: `${APP_ROUTES.learning}/${LEARNING_ROUTES.resources}`,
    },
    {
      title: 'Code Challenges',
      url: `${APP_ROUTES.home}/${HOME_ROUTES.notFound}`,
    },
    {
      title: 'Mentor',
      url: `${APP_ROUTES.mentoring}/${MENTORING_ROUTES.root}`,
    },
  ];

  rightLinks = [
    {
      title: 'User Dashboard',
      url: `${APP_ROUTES.home}/${HOME_ROUTES.dashboard}`,
    },
    { title: 'Log Out', url: '/' },
  ];

  constructor(private accountService: AccountService) {}

  ngOnInit(): void {}

  toggleNavbarCollapsing(): void {
    this.navbarCollapsed = !this.navbarCollapsed;
  }

  handleNavbarClick(event): void {
    if (!this.navbarCollapsed) {
      this.toggleNavbarCollapsing();
    }
    if (event.target.name === 'Log Out') {
      this.logout();
    }
  }

  logout(): void {
    this.accountService.logout();
  }
}
