import { ButtonCheckboxDirective } from 'ng-bootstrap';
import { LearningResource } from './learning_resource_dto';
import { User } from './user_dto';

export interface UserResourceState {
  learningResource: LearningResource;
  user: User;
  progressPercent: number;
}
