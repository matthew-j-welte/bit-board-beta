import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { LearningResourceModel } from '../+models/learning_resource_model';

@Component({
  selector: 'app-learning-resource-detail',
  templateUrl: './learning-resource-detail.component.html',
  styleUrls: ['./learning-resource-detail.component.css'],
})
export class LearningResourceDetailComponent implements OnInit {
  liked: boolean = false;
  reported: boolean = false;
  likeMap: object = {};
  reportMap: object = {};
  learningResource: LearningResourceModel;

  constructor(private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.route.data.subscribe((data) => {
      this.learningResource = data.learningResource;
    });
  }

  like = (id) => (this.likeMap[id] = this.likeMap[id] === true ? false : true);
  report = (id) => (this.reportMap[id] = this.reportMap[id] === true ? false : true);
}
