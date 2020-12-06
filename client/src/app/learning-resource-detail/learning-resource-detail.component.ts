import { Component, OnInit, ViewChildren } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserPostAction } from '../+enums/models';
import { Post } from '../+models/dtos/post_dto';
import { LearningResourceModel } from '../+models/learning_resource_model';
import { LearningResourcesService } from '../+services/learning-resources.service';

interface PostContent extends Post {
  expanded: boolean;
}

@Component({
  selector: 'app-learning-resource-detail',
  templateUrl: './learning-resource-detail.component.html',
  styleUrls: ['./learning-resource-detail.component.css'],
})
export class LearningResourceDetailComponent implements OnInit {
  learningResource: LearningResourceModel;
  maxVisiblePosts = 5;

  constructor(
    private route: ActivatedRoute,
    private learningResourceService: LearningResourcesService
  ) {}

  ngOnInit(): void {
    this.route.data.subscribe((data) => {
      this.learningResource = data.learningResource;
      this.learningResource.posts = this.learningResource.posts.map((p) => ({
        ...p,
        expanded: false,
      }));
    });
  }

  addPost = (post: Post) => {
    this.learningResource.posts.push(post);
  }

  getPostContentHeight(el): number {
    return el.scrollHeight;
  }

  resizePostContent(post: PostContent): void {
    post.expanded = !post.expanded;
  }

  public incrementPosts(): void {
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

  somefunc = (a) => console.log(a);

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
}
