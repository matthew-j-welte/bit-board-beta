import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../models/dtos/user_dto';
import { UserModel } from '../models/user_model';

@Injectable({
  providedIn: 'root',
})
export class UsersService {
  baseUrl = 'https://localhost:5001/api';
  members = [];
  memberCache = new Map();

  constructor(private http: HttpClient) {}

  getUser(): Observable<UserModel> {
    const user: User = JSON.parse(localStorage.getItem('user'));
    if (user) {
      return this.http.get<UserModel>(`${this.baseUrl}/users/GetByUsername/${user.userName}`);
    }
  }

  getUserModel(): Observable<UserModel> {
    const user: User = JSON.parse(localStorage.getItem('user'));
    if (user) {
      return this.http.get<UserModel>(`${this.baseUrl}/users/GetModel/${user.userId}`);
    }
  }
}
