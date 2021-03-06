import { LearningResource } from './dtos/learning_resource_dto';
import { Post } from './dtos/post_dto';
import { UserResourceProgression } from './dtos/user_resource_progression_dto';

export interface LearningResourceModel extends LearningResource {
  posts: Post[];
  userResourceProgression: UserResourceProgression;
}
