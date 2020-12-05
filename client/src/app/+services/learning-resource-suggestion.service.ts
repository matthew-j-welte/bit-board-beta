import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { LearningResourceSuggestion } from '../+models/dtos/learning_resource_suggestion_dto';
import { User } from '../+models/dtos/user_dto';

@Injectable({
  providedIn: 'root',
})
export class LearningResourceSuggestionService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  postLearningResourceSuggestion(suggestion: LearningResourceSuggestion): Observable<object> {
    const user: User = JSON.parse(localStorage.getItem('user'));
    const usersSuggestion: LearningResourceSuggestion = {
      ...suggestion,
      userId: user.userId,
    };
    return this.http.post(
      this.baseUrl + 'learningResourceSuggestions',
      usersSuggestion
    );
  }
}
