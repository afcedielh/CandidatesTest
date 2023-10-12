import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { CandidateComponent } from './pages/candidate/candidate.component';
import { CandidatesComponent } from './pages/candidates/candidates.component';
import { AppRoutingModule } from './app-routing.module';
import { ExperienceComponent } from './pages/experience/experience.component';



@NgModule({
  declarations: [
    AppComponent,
    CandidateComponent,
    CandidatesComponent,
    ExperienceComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
