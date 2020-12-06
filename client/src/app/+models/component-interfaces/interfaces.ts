import { LearningResource } from '../dtos/learning_resource_dto';
import { Post } from '../dtos/post_dto';

export interface LearningResourceCard extends LearningResource {
  showLogos: boolean;
  progressPercent?: number;
}

export interface PostContent extends Post {
  expanded: boolean;
}
