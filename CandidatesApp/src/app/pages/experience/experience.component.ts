import { ExperiencesService } from './../../services/experiences.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgForm } from '@angular/forms';
import { ExperienceModel } from 'src/app/models/experience.model';
@Component({
  selector: 'app-experience',
  templateUrl: './experience.component.html',
  styleUrls: ['./experience.component.css']
})
export class ExperienceComponent implements OnInit{
  isCreate: boolean | undefined;
  isUpdate: boolean | undefined;

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id !== null) {
      this.experience.IdCandidate = parseInt(id, 10);
    } else {
      this.experience.IdCandidate = 0;
    }
  }

  constructor(private ExperiencesService: ExperiencesService,private route: ActivatedRoute) {

  }
  experience = new ExperienceModel();
  guardar(form: NgForm){
    if(form.invalid){
      console.log('Formulario  no válido')
      return;
    }
    this.ExperiencesService.createCandidate(this.experience)
    .subscribe(resp => {
      this.isUpdate = false;
      this.isCreate = true;
    })
  }
}
