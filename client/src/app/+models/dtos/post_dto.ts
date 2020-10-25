import { LearningResource } from './learning_resource_dto';

export interface Post {
    postId: number;
    content: string;
    learningResourceId: number;
    learningResource: LearningResource;
}