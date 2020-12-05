import { Component, OnInit } from '@angular/core';
import { LearningResource } from '../+models/dtos/learning_resource_dto';
import { LearningResourcesService } from '../+services/learning-resources.service';
import { UsersService } from '../+services/users.service';

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
  ) { }

  ngOnInit(): void {
    this.getLearningResources();
    this.getAllResources();
  }

  async getLearningResources(): Promise<void> {
    this.userService.getResourceProgressions()?.subscribe((res) => {
      this.resources = res.map((resource) => {
        return {
          ...resource.learningResource,
          showLogos: true,
          progressPercent: resource.progressPercent,
        };
      });
      this.resources.sort((x, y) =>
        x.progressPercent < y.progressPercent ? 1 : -1
      );
    });
  }

  async getAllResources(): Promise<void> {
    this.learningResourcesService
      .getTopViewedLearningResources(9)
      ?.subscribe((res) => {
        this.allResources = res.map((resource) => {
          return {
            ...resource,
            showLogos: true,
          };
        });
      });
  }
}
