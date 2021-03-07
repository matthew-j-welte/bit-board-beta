import { Injectable } from '@angular/core';
import { User } from '../models/dtos/user_dto';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor() { }

  isLoggedIn(): boolean {
    return localStorage.getItem('user') !== null;
  }

  validUser(id: string): boolean {
    const user: User = JSON.parse(localStorage.getItem('user'));
    return id === user.userId;
  }
}
