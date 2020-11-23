import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { LearningResource } from '../+models/dtos/learning_resource_dto';

@Component({
  selector: 'app-learning-resource-detail',
  templateUrl: './learning-resource-detail.component.html',
  styleUrls: ['./learning-resource-detail.component.css']
})
export class LearningResourceDetailComponent implements OnInit {
  learningResource: LearningResource

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.learningResource = data.learningResource;
    })
  }

}
