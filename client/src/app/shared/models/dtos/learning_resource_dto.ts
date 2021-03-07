import { Skill } from './skill_dto';

export interface LearningResource {
  learningResourceId: string;
  title: string;
  description: string;
  videoId: string;
  imageUrl: string;
  type: string;
  skills: Skill[];
  viewers: number;
  userId: string;
}
