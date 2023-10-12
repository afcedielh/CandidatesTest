import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CandidateComponent } from './pages/candidate/candidate.component';
import { CandidatesComponent } from './pages/candidates/candidates.component';


const routes: Routes = [
  {path:'candidates', component: CandidatesComponent},
  {path:'candidate/:id', component: CandidateComponent},
  {path: '**', pathMatch: 'full', redirectTo: 'candidates'}
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports:[
    RouterModule
  ]
})
export class AppRoutingModule { }
