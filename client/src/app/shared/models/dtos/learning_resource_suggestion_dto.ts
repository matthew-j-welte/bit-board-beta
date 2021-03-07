import { Skill } from './skill_dto';

export interface LearningResourceSuggestion {
  userId: string;
  sourceUrl: string;
  rationale: string;
  skills: Skill[];
}
