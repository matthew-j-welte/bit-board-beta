import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../+models/dtos/user_dto';
import { UserResourceProgress } from '../+models/dtos/user_resource_progress_dto';
import { UserModel } from '../+models/user_model';

@Injectable({
  providedIn: 'root',
})
export class UsersService {
  baseUrl = 'https://localhost:5001/api';
  members = [];
  memberCache = new Map();

  constructor(private http: HttpClient) {}

  getUser() {
    const user: User = JSON.parse(localStorage.getItem('user'));
    if (user) {
      return this.http.get<UserModel>(`${this.baseUrl}/users/${user.userName}`);
    }
  }

  getResourceProgressions() {
    const user: User = JSON.parse(localStorage.getItem('user'));
    if (user) {
      return this.http.get<UserResourceProgress[]>(
        `${this.baseUrl}/users/${user.userId}/resourceProgress`
      );
    }
  }

  getResourceProgression(learningResourceId: number) {
    const user: User = JSON.parse(localStorage.getItem('user'));
    if (user) {
      return this.http.get<UserResourceProgress>(
        `${this.baseUrl}/users/${user.userId}/resourceProgress/${learningResourceId}`
      );
    }
  }
}
