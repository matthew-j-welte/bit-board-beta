import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserResourceProgress } from '../+models/dtos/user_resource_progress_dto';
import { LearningResourceModel } from '../+models/learning_resource_model';
import { UsersService } from '../+services/users.service';

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
  userProgression: UserResourceProgress;

  constructor(
    private route: ActivatedRoute,
    private userService: UsersService
  ) {}

  ngOnInit(): void {
    this.route.data.subscribe((data) => {
      this.learningResource = data.learningResource;
      this.userService
        .getResourceProgression(this.learningResource.learningResourceId)
        ?.subscribe((res) => {
          this.userProgression = res;
        });
    });
  }

  like = (id) => (this.likeMap[id] = this.likeMap[id] === true ? false : true);
  report = (id) =>
    (this.reportMap[id] = this.reportMap[id] === true ? false : true);
}
