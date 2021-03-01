import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LearningResourceDetailedResolver } from './learning-resource-detailed.resolver';
import { LearningResourceGuard } from './learning-resource.guard';
import { LearningResourceDetailComponent } from './learning-resources/learning-resource-detail/learning-resource-detail.component';
import { LearningResourcesComponent } from './learning-resources/learning-resources.component';
import { RootComponent } from './root.component';

const routes: Routes = [
  { path: '', component: RootComponent },
  { path: 'resources', component: LearningResourcesComponent },
  {
    path: 'resources/:id',
    component: LearningResourceDetailComponent,
    resolve: { learningResource: LearningResourceDetailedResolver },
    canActivate: [LearningResourceGuard],
  },
  { path: '**', redirectTo: 'not-found' },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class LearningRoutingModule {}
