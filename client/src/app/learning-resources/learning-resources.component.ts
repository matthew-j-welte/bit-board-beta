import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { LearningResource } from '../+models/dtos/learning_resource_dto';
import { LearningResourcesService } from '../+services/learning-resources.service';

interface LearningResourceCard extends LearningResource {
  showLogos: boolean;
}

@Component({
  selector: 'app-learning-resources',
  templateUrl: './learning-resources.component.html',
  styleUrls: ['./learning-resources.component.css'],
})
export class LearningResourcesComponent implements OnInit {
  resources: LearningResourceCard[];
  activeResources: LearningResourceCard[];
  resourceIndex: number = 0;
  resourcePageCount = 3;
  pages: number[] = [];

  constructor(private learningResourcesService: LearningResourcesService) {}

  ngOnInit(): void {
    this.getLearningResources();
  }

  setActiveResources() {
    this.activeResources = this.resources?.slice(
      this.resourceIndex * this.resourcePageCount,
      this.resourceIndex * this.resourcePageCount + 3
    );
  }

  async getLearningResources() {
    this.learningResourcesService.getLearningResources()?.subscribe((res) => {
      this.resources = res.map((resource) => {
        return { ...resource, showLogos: true };
      });
      this.setActiveResources();
      for (
        let index = 0;
        index < this.resources.length / this.resourcePageCount;
        index++
      ) {
        this.pages.push(index + 1);
      }
    });
  }

  graphicalSkillsView(resource: LearningResourceCard) {
    resource.showLogos = true;
  }

  textualSkillsView(resource: LearningResourceCard) {
    resource.showLogos = false;
  }

  nextKeepWorkingPage() {
    if (
      this.resourceIndex <
      this.resources.length / this.resourcePageCount - 1
    ) {
      this.resourceIndex += 1;
    } else {
      this.resourceIndex = 0;
    }
    this.setActiveResources();
  }

  previousKeepWorkingPage() {
    if (this.resourceIndex > 0) {
      this.resourceIndex -= 1;
    } else {
      this.resourceIndex = this.resources.length / this.resourcePageCount - 1;
    }
    this.setActiveResources();
  }

  setKeepWorkingPage(page: number) {
    this.resourceIndex = page - 1;
    this.setActiveResources();
  }
}
