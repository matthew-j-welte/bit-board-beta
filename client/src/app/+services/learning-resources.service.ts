import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { LearningResource } from '../+models/dtos/learning_resource_dto';
import { LearningResourceModel } from '../+models/learning_resource_model';

@Injectable({
  providedIn: 'root',
})
export class LearningResourcesService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getLearningResources() {
    return this.http.get<LearningResource[]>(
      this.baseUrl + 'learningResources/standard'
    );
  }

  getLearningResource(id: string) {
    return this.http.get<LearningResource>(
      this.baseUrl + `learningResources/standard/${id}`
    );
  }

  getLearningResourceModel(id: string) {
    return this.http.get<LearningResourceModel>(
      this.baseUrl + `learningResources/detailed/${id}`
    );
  }
}
