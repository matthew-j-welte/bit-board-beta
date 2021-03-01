import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MentorPageComponent } from './mentor-page/mentor-page.component';

const routes: Routes = [
  {
    path: '',
    component: MentorPageComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class MentoringRoutingModule {}
