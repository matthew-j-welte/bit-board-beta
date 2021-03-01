import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TextInputComponent } from './components/text-input/text-input.component';
import { TextSummaryPipe } from './pipes/text-summary.pipe';
import { GenericModalComponent } from './components/generic-modal/generic-modal.component';
import { JumbotronComponent } from './components/jumbotron/jumbotron.component';
import { LearningResourceCardGroupComponent } from './components/learning-resource-card-group/learning-resource-card-group.component';
import { LearningResourceCardComponent } from './components/learning-resource-card-group/learning-resource-card/learning-resource-card.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { RouterModule } from '@angular/router';
import { ResourceSuggestionComponent } from '../+mentoring/resource-suggestion/resource-suggestion.component';

@NgModule({
  declarations: [
    TextInputComponent,
    TextSummaryPipe,
    GenericModalComponent,
    JumbotronComponent,
    LearningResourceCardGroupComponent,
    LearningResourceCardComponent,
    NavbarComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    TextInputComponent,
    TextSummaryPipe,
    JumbotronComponent,
    NavbarComponent,
    LearningResourceCardGroupComponent,
    LearningResourceCardComponent
  ]
})
export class SharedModule { }
