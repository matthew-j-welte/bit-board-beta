import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RootComponent } from './root.component';
import { LearningResourceDetailJumbotronComponent } from './learning-resources/learning-resource-detail/learning-resource-detail-jumbotron/learning-resource-detail-jumbotron.component';
import { LearningResourceDetailPostsComponent } from './learning-resources/learning-resource-detail/learning-resource-detail-posts/learning-resource-detail-posts.component';
import { NewPostComponent } from './new-post/new-post.component';
import { LearningRoutingModule } from './learning-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';
import { LearningResourceDetailComponent } from './learning-resources/learning-resource-detail/learning-resource-detail.component';
import { LearningResourcesComponent } from './learning-resources/learning-resources.component';

@NgModule({
  declarations: [
    RootComponent,
    LearningResourcesComponent,
    LearningResourceDetailComponent,
    NewPostComponent,
    LearningResourceDetailJumbotronComponent,
    LearningResourceDetailPostsComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    LearningRoutingModule,
    FormsModule,
    ReactiveFormsModule,
  ]
})
export class LearningModule {}
