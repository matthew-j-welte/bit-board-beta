import { Component, Input, OnInit } from '@angular/core';
import { LearningResourceModel } from 'src/app/+models/learning_resource_model';

@Component({
  selector: 'app-learning-resource-detail-jumbotron',
  templateUrl: './learning-resource-detail-jumbotron.component.html',
  styleUrls: ['./learning-resource-detail-jumbotron.component.css']
})
export class LearningResourceDetailJumbotronComponent implements OnInit {
  @Input() learningResource: LearningResourceModel;

  constructor() { }

  ngOnInit(): void {
  }

}
