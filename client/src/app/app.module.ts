import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { LearningResourcesComponent } from './learning-resources/learning-resources.component';
import { UserDashboardComponent } from './user-dashboard/user-dashboard.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ProgressbarModule } from 'ngx-bootstrap/progressbar';
import { SkillProgressionBarComponent } from './skill-progression-bar/skill-progression-bar.component';
import { NavbarComponent } from './navbar/navbar.component';
import { LoginComponent } from './+forms/login/login.component';
import { TextInputComponent } from './+forms/text-input/text-input.component';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { MentorPageComponent } from './mentor-page/mentor-page.component';
import { ModalModule } from 'ngx-bootstrap/modal';
import { LearningResourceDetailComponent } from './learning-resource-detail/learning-resource-detail.component';
import { RegistrationComponent } from './+forms/registration/registration.component';
import { NgxSpinnerModule } from 'ngx-spinner';
import { LoadingInterceptor } from './+interceptors/loading.interceptor';
import { ResourceSuggestionComponent } from './+forms/resource-suggestion/resource-suggestion.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LearningResourcesComponent,
    UserDashboardComponent,
    SkillProgressionBarComponent,
    NavbarComponent,
    LoginComponent,
    TextInputComponent,
    MentorPageComponent,
    LearningResourceDetailComponent,
    RegistrationComponent,
    ResourceSuggestionComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ProgressbarModule.forRoot(),
    FormsModule,
    ReactiveFormsModule,
    TabsModule.forRoot(),
    ModalModule.forRoot(),
    NgxSpinnerModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
