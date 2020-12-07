import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../+services/auth.service';

@Injectable({
  providedIn: 'root',
})
export class UserDashboardGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) {}

  canActivate(): boolean {
    const loggedIn = this.authService.isLoggedIn();
    if (loggedIn) {
      return true;
    }
    this.router.navigate(['access-denied'], {
      state: { errorMessage: 'Login or Register to access your User Dashboard' },
    });
  }
}
