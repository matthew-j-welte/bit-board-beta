import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { LearningResource } from '../+models/dtos/learning_resource_dto';
import { Post } from '../+models/dtos/post_dto';
import { User } from '../+models/dtos/user_dto';
import { LearningResourceModel } from '../+models/learning_resource_model';

@Injectable({
  providedIn: 'root',
})
export class LearningResourcesService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getLearningResources(): Observable<LearningResource[]> {
    return this.http.get<LearningResource[]>(
      this.baseUrl + 'learningResources/standard'
    );
  }

  getTopViewedLearningResources(count: number): Observable<LearningResource[]> {
    return this.http.get<LearningResource[]>(
      this.baseUrl + 'learningResources/standard',
      { headers: { count: count.toString(), sortBy: 'viewers' } }
    );
  }

  getLearningResource(id: string): Observable<LearningResource> {
    return this.http.get<LearningResource>(
      this.baseUrl + `learningResources/standard/${id}`
    );
  }

  getLearningResourceModel(id: string): Observable<LearningResourceModel> {
    const user: User = JSON.parse(localStorage.getItem('user'));
    return this.http.get<LearningResourceModel>(
      this.baseUrl + `learningResources/detailed/${id}/${user.userId}`
    );
  }

  updateResourcePost(post: Post): Observable<Post> {
    const user: User = JSON.parse(localStorage.getItem('user'));
    return this.http.put<Post>(
      this.baseUrl + `learningResources/user/${user.userId}/post`,
      post
    );
  }

  newResourcePost(post: Post): Observable<Post> {
    const user: User = JSON.parse(localStorage.getItem('user'));
    post.userId = user.userId;
    return this.http.post<Post>(this.baseUrl + `learningResources/posts`, post);
  }
}
