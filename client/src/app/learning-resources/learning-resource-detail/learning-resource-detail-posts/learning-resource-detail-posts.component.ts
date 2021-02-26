import { Component, Input, OnInit } from '@angular/core';
import { UserPostAction } from 'src/app/+enums/models';
import { PostContent } from 'src/app/+models/component-interfaces/interfaces';
import { Post } from 'src/app/+models/dtos/post_dto';
import { LearningResourceModel } from 'src/app/+models/learning_resource_model';
import { LearningResourcesService } from 'src/app/+services/learning-resources.service';

@Component({
  selector: 'app-learning-resource-detail-posts',
  templateUrl: './learning-resource-detail-posts.component.html',
  styleUrls: ['./learning-resource-detail-posts.component.css'],
})
export class LearningResourceDetailPostsComponent implements OnInit {
  @Input() learningResource: LearningResourceModel;
  maxVisiblePosts = 5;

  constructor(private learningResourceService: LearningResourcesService) {}

  ngOnInit(): void {}

  getPostContentHeight(el): number {
    return el.scrollHeight;
  }

  resizePostContent(post: PostContent): void {
    post.expanded = !post.expanded;
  }

  incrementPosts(): void {
    this.maxVisiblePosts += 5;
  }

  public like(post: Post): void {
    post.previousUserPostAction = post.userPostAction;
    post.userPostAction =
      post.userPostAction === UserPostAction.Liked
        ? UserPostAction.None
        : UserPostAction.Liked;
    this.updatePost(post);
  }

  public report(post: Post): void {
    post.previousUserPostAction = post.userPostAction;
    post.userPostAction =
      post.userPostAction === UserPostAction.Reported
        ? UserPostAction.None
        : UserPostAction.Reported;
    this.updatePost(post);
  }

  private async updatePost(post: Post): Promise<void> {
    this.learningResourceService.updateResourcePost(post)?.subscribe((res) => {
      this.learningResource.posts.find((x) => x.postId === post.postId).likes =
        res.likes;
      this.learningResource.posts.find(
        (x) => x.postId === post.postId
      ).reports = res.reports;
    });
  }

  addPost(post: Post): void {
    this.learningResource.posts.push({
      ...post,
      userPostAction: UserPostAction.Authored,
    });
  }
}
