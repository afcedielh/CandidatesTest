import { CandidateModel } from './../models/candidate.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CandidatesService {

  private url = 'http://localhost:5000/api/candidate'
  constructor(private http: HttpClient) { }

  createCandidate( candidate: CandidateModel){
    return this.http.post(`${this.url}`,candidate)
    .pipe(
      map((resp: any) => {
          candidate.idCandidate = resp;
      })
    );
  }

  updateCandidate(id: number, candidate: CandidateModel) {
    return this.http.put(`${this.url}/${id}`, candidate)
      .pipe(
        map((resp: any) => {
          return resp;
        })
      );
  }

  getCandidates(): Observable<CandidateModel[]> {
    return this.http.get<CandidateModel[]>(this.url);
  }

  getCandidateById(id: string){
    return this.http.get<CandidateModel>(`${this.url}/${id}`);
  }

  deleteCandidateById(id: number){
    return this.http.delete<CandidateModel>(`${this.url}/${id}`);
  }
}
