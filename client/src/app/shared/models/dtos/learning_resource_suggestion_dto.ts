import { Skill } from './skill_dto';

export interface LearningResourceSuggestion {
  userId: number;
  sourceUrl: string;
  rationale: string;
  skills: Skill[];
}
