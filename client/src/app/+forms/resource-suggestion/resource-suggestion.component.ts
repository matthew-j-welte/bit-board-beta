import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { FormConfig, FormFieldBuilder } from 'src/app/+helpers/form-helpers';
import { LearningResourceSuggestion } from 'src/app/+models/dtos/learning_resource_suggestion_dto';
import { Skill } from 'src/app/+models/dtos/skill_dto';
import { LearningResourceSuggestionService } from 'src/app/+services/learning-resource-suggestion.service';
import { SkillsService } from 'src/app/+services/skills.service';
import { resourceSuggestionConfig } from './resource-suggestion.config';

interface SkillSelection extends Skill {
  selected: boolean;
  hovered: boolean;
}

@Component({
  selector: 'app-resource-suggestion',
  templateUrl: './resource-suggestion.component.html',
  styleUrls: ['./resource-suggestion.component.css'],
})
export class ResourceSuggestionComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();

  resourceSuggestionForm: FormGroup;
  validationErrors: string[] = [];
  formConfig: FormConfig;
  skills: SkillSelection[];

  constructor(
    private fb: FormBuilder,
    private skillsService: SkillsService,
    private resourceSuggestionService: LearningResourceSuggestionService
  ) {}

  ngOnInit(): void {
    this.buildForm();
    this.getSkills();
  }

  buildForm(): void {
    this.formConfig = resourceSuggestionConfig;
    this.resourceSuggestionForm = this.fb.group(
      FormFieldBuilder.buildCtlConfig(this.formConfig)
    );
  }

  submitSuggestion(): void {
    const skillString: string = this.resourceSuggestionForm.controls.skills
      .value;
    const skillNames = skillString.trim().split(' ');
    const skills = this.skills.filter((skill) =>
      skillNames.includes(skill.name)
    );
    const resourceSuggestion: LearningResourceSuggestion = {
      ...this.resourceSuggestionForm.value,
      skills,
    };
    this.resourceSuggestionService
      .postLearningResourceSuggestion(resourceSuggestion)
      .subscribe(
        (res) => {
          console.log(res);
        },
        (error) => {
          this.validationErrors = error;
        }
      );
  }

  async getSkills(): Promise<void> {
    this.skillsService.getSkills()?.subscribe((res) => {
      this.skills = res.map((skill) => {
        return { ...skill, selected: false, hovered: false };
      });
    });
  }

  toggleSkill(skill: SkillSelection): void {
    skill.selected = !skill.selected;
    const value: string = this.resourceSuggestionForm.controls.skills.value;
    const skillSelectionField = this.resourceSuggestionForm.controls.skills;

    if (skill.selected) {
      skillSelectionField.setValue(value + ' ' + skill.name);
    } else {
      skillSelectionField.setValue(value.replace(' ' + skill.name, ''));
    }
  }

  hoverSkill(skill: SkillSelection, hover: boolean): void {
    skill.hovered = hover;
  }
}
