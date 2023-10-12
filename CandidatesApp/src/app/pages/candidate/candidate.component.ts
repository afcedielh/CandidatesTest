import { CandidatesService } from './../../services/candidates.service';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { CandidateModel } from 'src/app/models/candidate.model';


@Component({
  selector: 'app-candidate',
  templateUrl: './candidate.component.html',
  styleUrls: ['./candidate.component.css']
})

export class CandidateComponent implements OnInit{
  isCreate: boolean | undefined;
  isUpdate: boolean | undefined;
  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id !== null && id !== 'nuevo') {
      this.CandidatesService.getCandidateById(id).subscribe((resp: CandidateModel) => {
        this.candidate = resp;

        // Mapear campos de experiencia aquí
        this.candidate.experiences = resp.experiences.map((exp) => {
          return {
            IdCandidateExperience: exp.IdCandidateExperience,
            IdCandidate: exp.IdCandidate,
            Company: exp.Company,
            Job: exp.Job,
            Description: exp.Description,
            Salary: exp.Salary,
            Begindate: new Date(exp.Begindate),
            Enddate: new Date(exp.Enddate),
          };
        });

        console.log(this.candidate);
      });
    }
  }
  constructor(private CandidatesService: CandidatesService , private route: ActivatedRoute){}
  candidate = new CandidateModel();

  guardar(form: NgForm){
    if(form.invalid){
      console.log('Formulario  no vbálido')
      return;
    }

    if(this.candidate.idCandidate){
      this.CandidatesService.updateCandidate(this.candidate.idCandidate,this.candidate)
      .subscribe(resp => {
        console.log(resp);
        this.isUpdate = true;
        this.isCreate = false;
      })
    }else{
      this.CandidatesService.createCandidate(this.candidate)
      .subscribe(resp => {
        this.isUpdate = false;
        this.isCreate = true;
      })
    }
  }
}
