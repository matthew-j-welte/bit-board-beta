import { LearningResource } from './learning_resource_dto';
import { User } from './user_dto';

export interface UserResourceProgress {
  learningResource: LearningResource;
  user: User;
  progressPercent: number;
}
