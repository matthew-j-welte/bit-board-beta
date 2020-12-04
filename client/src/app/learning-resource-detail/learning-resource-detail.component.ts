import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserPostAction } from '../+enums/models';
import { Post } from '../+models/dtos/post_dto';
import { LearningResourceModel } from '../+models/learning_resource_model';
import { LearningResourcesService } from '../+services/learning-resources.service';

@Component({
  selector: 'app-learning-resource-detail',
  templateUrl: './learning-resource-detail.component.html',
  styleUrls: ['./learning-resource-detail.component.css'],
})
export class LearningResourceDetailComponent implements OnInit {
  learningResource: LearningResourceModel;

  constructor(
    private route: ActivatedRoute,
    private learningResourceService: LearningResourcesService
  ) {}

  ngOnInit(): void {
    this.route.data.subscribe((data) => {
      this.learningResource = data.learningResource;
    });
  }

  like(post: Post) {
    post.previousUserPostAction = post.userPostAction;
    post.userPostAction =
      post.userPostAction === UserPostAction.Liked
        ? UserPostAction.None
        : UserPostAction.Liked;
    this.updatePost(post);
  }

  report(post: Post) {
    post.previousUserPostAction = post.userPostAction;
    post.userPostAction =
      post.userPostAction === UserPostAction.Reported
        ? UserPostAction.None
        : UserPostAction.Reported;
    this.updatePost(post);
  }

  private async updatePost(post: Post) {
    this.learningResourceService.updateResourcePost(post)?.subscribe((res) => {
      this.learningResource.posts.find(x => x.postId === post.postId).likes = res.likes;
      this.learningResource.posts.find(x => x.postId === post.postId).reports = res.reports;
    });
  }
}
