import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LearningResourceGuard } from './+guards/learning-resource.guard';
import { UserDashboardGuard } from './+guards/user-dashboard.guard';
import { LearningResourceDetailedResolver } from './+resolvers/learning-resource-detailed.resolver';
import { AccessDeniedComponent } from './access-denied/access-denied.component';
import { HomeComponent } from './home/home.component';
import { LearningResourceDetailComponent } from './learning-resources/learning-resource-detail/learning-resource-detail.component';
import { LearningResourcesComponent } from './learning-resources/learning-resources.component';
import { MentorPageComponent } from './mentor-page/mentor-page.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { UserDashboardComponent } from './user-dashboard/user-dashboard.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'learningResources', component: LearningResourcesComponent },
  {
    path: 'learningResources/:id',
    component: LearningResourceDetailComponent,
    resolve: { learningResource: LearningResourceDetailedResolver },
    canActivate: [LearningResourceGuard],
  },
  {
    path: 'userDashboard',
    component: UserDashboardComponent,
    canActivate: [UserDashboardGuard],
  },
  { path: 'mentor', component: MentorPageComponent },
  { path: 'not-found', component: PageNotFoundComponent },
  { path: 'access-denied', component: AccessDeniedComponent },
  { path: '**', redirectTo: 'not-found' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule],
})
export class AppRoutingModule {}
