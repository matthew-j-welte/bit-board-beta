import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Skill } from '../+models/dtos/skill_dto';

@Injectable({
  providedIn: 'root',
})
export class SkillsService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getSkills(): Observable<Skill[]> {
    return this.http.get<Skill[]>(this.baseUrl + 'skills');
  }
}
