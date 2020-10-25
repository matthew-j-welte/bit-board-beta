import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../+models/dtos/user_dto';
import { UserModel } from '../+models/user_model';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  baseUrl = 'https://localhost:5001/api';
  members = [];
  memberCache = new Map();

  constructor(private http: HttpClient) { }

  getUser() {
    return this.http.get<UserModel>(`${this.baseUrl}/users/GuerraSnider`)
  }
}