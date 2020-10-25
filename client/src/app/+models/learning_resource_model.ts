import { LearningResource } from './dtos/learning_resource_dto';
import { Post } from './dtos/post_dto';
import { Skill } from './dtos/skill_dto';

export interface LearningResourceModel extends LearningResource {
    posts: Post[];
    skills: Skill[];
}