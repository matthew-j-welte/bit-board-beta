import { Component, Input, OnInit } from '@angular/core';
import { UserSkill } from '../+models/dtos/user_skill_dto';

@Component({
  selector: 'app-skill-progression-bar',
  templateUrl: './skill-progression-bar.component.html',
  styleUrls: ['./skill-progression-bar.component.css'],
})
export class SkillProgressionBarComponent implements OnInit {
  @Input() skillInfo: UserSkill;

  skillName: string;
  skillLevel: number;
  animate = true;
  striped = true;
  max = 100;
  min = 0;

  value: number;
  type: string;

  constructor() {}

  ngOnInit(): void {
    this.skillName = this.skillInfo.skill.name;
    this.skillLevel = this.skillInfo.level;
    this.animate = true;
    this.striped = true;
    this.value = this.skillInfo.progressPercent;

    if (this.value < 25) {
      this.type = 'danger';
    } else if (this.value < 50) {
      this.type = 'warning';
    } else if (this.value < 75) {
      this.type = 'info';
    } else {
      this.type = 'success';
    }
  }
}
