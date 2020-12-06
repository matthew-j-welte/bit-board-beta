import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LearningResourceDetailedResolver } from './+resolvers/learning-resource-detailed.resolver';
import { HomeComponent } from './home/home.component';
import { LearningResourceDetailComponent } from './learning-resources/learning-resource-detail/learning-resource-detail.component';
import { LearningResourcesComponent } from './learning-resources/learning-resources.component';
import { MentorPageComponent } from './mentor-page/mentor-page.component';
import { UserDashboardComponent } from './user-dashboard/user-dashboard.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'learningResources', component: LearningResourcesComponent },
  {
    path: 'learningResource/:id',
    component: LearningResourceDetailComponent,
    resolve: { learningResource: LearningResourceDetailedResolver },
  },
  { path: 'userDashboard', component: UserDashboardComponent },
  { path: 'mentor', component: MentorPageComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
