import { UserPostAction } from 'src/app/+learning/models';
import { LearningResource } from './learning_resource_dto';

export interface Post {
  postId?: string;
  content?: string;
  learningResourceId?: string;
  userId?: string;
  learningResource?: LearningResource;
  userPostAction?: UserPostAction;
  previousUserPostAction?: UserPostAction;
  likes?: number;
  reports?: number;
}
