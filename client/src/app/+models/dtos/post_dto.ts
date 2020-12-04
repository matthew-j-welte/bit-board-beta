import { UserPostAction } from 'src/app/+enums/models';
import { LearningResource } from './learning_resource_dto';

export interface Post {
  postId: number;
  content: string;
  learningResourceId: number;
  learningResource: LearningResource;
  userPostAction: UserPostAction;
  previousUserPostAction?: UserPostAction;
  likes: number;
  reports: number;
}
