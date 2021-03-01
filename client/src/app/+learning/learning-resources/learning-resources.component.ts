import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs/operators';
import { LearningResource } from '../../shared/models/dtos/learning_resource_dto';
import { LearningResourcesService } from '../../shared/services/learning-resources.service';
import { UsersService } from '../../shared/services/users.service';

interface LearningResourceCard extends LearningResource {
  showLogos: boolean;
  progressPercent?: number;
}

@Component({
  selector: 'app-learning-resources',
  templateUrl: './learning-resources.component.html',
  styleUrls: ['./learning-resources.component.css'],
})
export class LearningResourcesComponent implements OnInit {
  resources: LearningResourceCard[];
  allResources: LearningResourceCard[];

  constructor(
    private learningResourcesService: LearningResourcesService,
    private userService: UsersService
  ) {}

  ngOnInit(): void {
    this.getLearningResources();
    this.getAllResources();
  }

  getLearningResources(): void {
    const resources$ = this.userService.getResourceProgressions()?.pipe(
      map((response) =>
        response.map((resource) => ({
          ...resource.learningResource,
          showLogos: true,
          progressPercent: resource.progressPercent,
        }))
      )
    );

    resources$.subscribe((resourceCards) => {
      this.resources = resourceCards;
      this.resources.sort((x, y) =>
        x.progressPercent < y.progressPercent ? 1 : -1
      );
    });
  }

  getAllResources(): void {
    const resources$ = this.learningResourcesService
      .getTopViewedLearningResources(9)
      ?.pipe(
        map((response) =>
          response.map((resource) => ({
            ...resource,
            showLogos: true,
          }))
        )
      );

    resources$.subscribe((resourceCards) => {
      this.allResources = resourceCards;
    });
  }
}
