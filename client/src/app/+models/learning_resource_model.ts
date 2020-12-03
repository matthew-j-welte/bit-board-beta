import { LearningResource } from './dtos/learning_resource_dto';
import { Post } from './dtos/post_dto';
import { UserResourceState } from './dtos/user_resource_state_dto';

export interface LearningResourceModel extends LearningResource {
    posts: Post[];
    userResourceState: UserResourceState;
}