import { Component, Input, OnInit } from '@angular/core';
import { LearningResource } from '../+models/dtos/learning_resource_dto';

interface LearningResourceCard extends LearningResource {
  showLogos: boolean;
  progressPercent?: number;
}

@Component({
  selector: 'app-learning-resource-card',
  templateUrl: './learning-resource-card.component.html',
  styleUrls: ['./learning-resource-card.component.css']
})
export class LearningResourceCardComponent implements OnInit {
  @Input() resources: LearningResourceCard[]

  constructor() { }

  ngOnInit(): void {
  }

  graphicalSkillsView(resource: LearningResourceCard) {
    resource.showLogos = true;
  }

  textualSkillsView(resource: LearningResourceCard) {
    resource.showLogos = false;
  }
}
