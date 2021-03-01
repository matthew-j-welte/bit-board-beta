import { Component, OnInit, ViewChildren } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { LearningResourceModel } from '../../../shared/models/learning_resource_model';

@Component({
  selector: 'app-learning-resource-detail',
  templateUrl: './learning-resource-detail.component.html',
  styleUrls: ['./learning-resource-detail.component.css'],
})
export class LearningResourceDetailComponent implements OnInit {
  learningResource: LearningResourceModel;
  maxVisiblePosts = 5;

  constructor(private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.route.data.subscribe((data) => {
      this.learningResource = data.learningResource;
      this.learningResource.posts = this.learningResource.posts.map((p) => ({
        ...p,
        expanded: false,
      }));
    });
  }

  public incrementPosts(): void {
    this.maxVisiblePosts += 5;
  }
}
