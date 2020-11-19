import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { LearningResourcesComponent } from './learning-resources/learning-resources.component';
import { UserDashboardComponent } from './user-dashboard/user-dashboard.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ProgressbarModule } from 'ngx-bootstrap/progressbar';
import { SkillProgressionBarComponent } from './skill-progression-bar/skill-progression-bar.component';
import { UserDashboardSidenavComponent } from './user-dashboard-sidenav/user-dashboard-sidenav.component';
import { NavbarComponent } from './navbar/navbar.component';
import { LoginComponent } from './+forms/login/login.component';
import { TextInputComponent } from './+forms/text-input/text-input.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LearningResourcesComponent,
    UserDashboardComponent,
    SkillProgressionBarComponent,
    UserDashboardSidenavComponent,
    NavbarComponent,
    LoginComponent,
    TextInputComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ProgressbarModule.forRoot(),
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
