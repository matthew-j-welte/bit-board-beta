import { UserPostAction } from 'src/app/+learning/models';
import { LearningResource } from './learning_resource_dto';

export interface Post {
  postId?: number;
  content?: string;
  learningResourceId?: number;
  userId?: number;
  learningResource?: LearningResource;
  userPostAction?: UserPostAction;
  previousUserPostAction?: UserPostAction;
  likes?: number;
  reports?: number;
}
