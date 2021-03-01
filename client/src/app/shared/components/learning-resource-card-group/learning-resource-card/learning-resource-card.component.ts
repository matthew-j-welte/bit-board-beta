import { Component, Input, OnInit } from '@angular/core';
import { LearningResourceCard } from '../../../models/component-interfaces/interfaces';

@Component({
  selector: 'app-learning-resource-card',
  templateUrl: './learning-resource-card.component.html',
  styleUrls: ['./learning-resource-card.component.css'],
})
export class LearningResourceCardComponent implements OnInit {
  @Input() learningResource: LearningResourceCard;

  constructor() {}

  graphicalSkillsView(): void {
    this.learningResource.showLogos = true;
  }

  textualSkillsView(): void {
    this.learningResource.showLogos = false;
  }

  ngOnInit(): void {}
}
