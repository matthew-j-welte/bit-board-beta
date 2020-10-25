import { Skill } from './skill_dto';

export interface UserSkill {
    skill: Skill;
    level: number;
    progressPercent: number;
}