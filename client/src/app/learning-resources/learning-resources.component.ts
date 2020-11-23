import { Component, OnInit } from '@angular/core';
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

  constructor(private learningResourcesService: LearningResourcesService) {}

  ngOnInit(): void {
    this.learningResourcesService.getLearningResources()?.subscribe((res) => {
      this.resources = res.map(resource => {return {...resource, showLogos: true}});
      console.log(this.resources)
    });
  }

  graphicalSkillsView(resource: LearningResourceCard) {
    resource.showLogos = true;
  }

  textualSkillsView(resource: LearningResourceCard) {
    resource.showLogos = false;
  }
}
