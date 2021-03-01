import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MentorPageComponent } from './mentor-page/mentor-page.component';
import { MentoringRoutingModule } from './mentoring-routing.module';
import { SharedModule } from '../shared/shared.module';
import { ResourceSuggestionComponent } from './resource-suggestion/resource-suggestion.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ModalModule } from 'ngx-bootstrap/modal';



@NgModule({
  declarations: [
    MentorPageComponent,
    ResourceSuggestionComponent
  ],
  imports: [
    CommonModule,
    MentoringRoutingModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule,
    ModalModule.forRoot(),
  ]
})
export class MentoringModule { }
