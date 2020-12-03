import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserPostAction } from '../+enums/models';
import { Post } from '../+models/dtos/post_dto';
import { LearningResourceModel } from '../+models/learning_resource_model';

@Component({
  selector: 'app-learning-resource-detail',
  templateUrl: './learning-resource-detail.component.html',
  styleUrls: ['./learning-resource-detail.component.css'],
})
export class LearningResourceDetailComponent implements OnInit {
  learningResource: LearningResourceModel;

  constructor(private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.route.data.subscribe((data) => {
      this.learningResource = data.learningResource;
    });
  }

  like = (post: Post) =>
    (post.userPostAction =
      post.userPostAction === UserPostAction.Liked
        ? UserPostAction.None
        : UserPostAction.Liked);
  
  report = (post) =>
    (post.userPostAction =
      post.userPostAction === UserPostAction.Reported
        ? UserPostAction.None
        : UserPostAction.Reported);
}
