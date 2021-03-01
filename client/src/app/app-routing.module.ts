import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  {
    path: 'home',
    loadChildren: () => import('./+home/home.module').then((m) => m.HomeModule),
  },
  {
    path: 'learning',
    loadChildren: () =>
      import('./+learning/learning.module').then((m) => m.LearningModule),
  },
  {
    path: 'mentoring',
    loadChildren: () =>
      import('./+mentoring/mentoring.module').then((m) => m.MentoringModule),
  },
  { path: '**', redirectTo: 'not-found' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule],
})
export class AppRoutingModule {}
