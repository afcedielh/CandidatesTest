import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { ExperienceModel } from '../models/experience.model';

@Injectable({
  providedIn: 'root'
})
export class ExperiencesService {

  private url = 'http://localhost:5000/api/CandidateExperience'

  constructor(private http: HttpClient) { }

  createCandidate( experience: ExperienceModel){
    return this.http.post(`${this.url}`,experience)
    .pipe(
      map((resp: any) => {
        experience.IdCandidateExperience = resp;
      })
    );
  }
}
