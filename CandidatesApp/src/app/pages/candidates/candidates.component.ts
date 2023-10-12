import { CandidateModel } from 'src/app/models/candidate.model';
import { CandidatesService } from './../../services/candidates.service';
import { Component, OnInit } from '@angular/core';
@Component({
  selector: 'app-candidates',
  templateUrl: './candidates.component.html',
  styleUrls: ['./candidates.component.css']
})
export class CandidatesComponent implements OnInit{

  candidates: CandidateModel[] = [];
  isLoading = false;
  isDelete = false;
  isCharging = false;
  constructor(private CandidatesService: CandidatesService) {

  }

  ngOnInit(): void {
    this.isCharging = true;
    this.CandidatesService.getCandidates().subscribe(
      (data) => {
        this.isCharging = true;
        this.candidates = data;
        this.isLoading = false;
      },
      (error) => {
        console.error('Error fetching candidates:', error);
        this.isLoading = false;
      }
    );
  }
  deleteCandidate(candidate: CandidateModel, id: number){
    this.candidates.splice(id, 1)
    this.CandidatesService.deleteCandidateById(candidate.idCandidate).subscribe();
    this.isDelete = true;
  }
}
