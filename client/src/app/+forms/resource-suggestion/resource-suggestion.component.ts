import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { FormConfig, FormFieldBuilder } from 'src/app/+helpers/form-helpers';
import { Skill } from 'src/app/+models/dtos/skill_dto';
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
  skills: SkillSelection[]

  constructor(private fb: FormBuilder, private skillsService: SkillsService) {}

  ngOnInit(): void {
    this.buildForm();
    this.getSkills();
  }

  buildForm() {
    this.formConfig = resourceSuggestionConfig;
    this.resourceSuggestionForm = this.fb.group(
      FormFieldBuilder.buildCtlConfig(this.formConfig)
    );
  }

  submitSuggestion() {
    console.log(this.resourceSuggestionForm.value);
    const skillString: string = this.resourceSuggestionForm.controls['skillSelections'].value
    const skillNames = skillString.trim().split(' ')
    const skills = this.skills.filter(skill => skillNames.includes(skill.name))
    const formValues = {...this.resourceSuggestionForm.value, skillSelections: skills};
    console.log(formValues);
    // this.accountService.register(this.registerForm.value).subscribe(
    //   (_) => {
    //     this.router.navigateByUrl('/userDashboard');
    //   },
    //   (error) => {
    //     this.validationErrors = error;
    //   }
    // );
  }

  async getSkills() {
    this.skillsService.getSkills()?.subscribe((res) => {
      this.skills = res.map(skill => {
        return {...skill, selected: false, hovered: false}
      })
    });
  }

  toggleSkill(skill: SkillSelection) {
    skill.selected = !skill.selected;
    const value: string = this.resourceSuggestionForm.controls['skillSelections'].value;
    const skillSelectionField = this.resourceSuggestionForm.controls['skillSelections']
    
    if (skill.selected) {
      skillSelectionField.setValue(value + ' ' + skill.name);
    }
    else {
      skillSelectionField.setValue(value.replace(' ' + skill.name, ''));
    }
    
  }

  hoverSkill(skill: SkillSelection, hover: boolean) {
    skill.hovered = hover;
  }
}
