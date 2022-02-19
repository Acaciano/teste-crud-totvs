import { Component, OnInit } from '@angular/core';
import { CandidatosService } from 'src/app/services/candidatos.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Candidatos } from 'src/app/models/candidatos.model';

@Component({
  selector: 'app-candidato-detalhes',
  templateUrl: './candidato-detalhes.component.html',
  styleUrls: ['./candidato-detalhes.component.css']
})
export class CandidatoDetalhesComponent implements OnInit {
  currentCandidatos: Candidatos = {
    nome: '',
    cpf: '',
    email: '',
    idade: 0
  };
  message = '';

  constructor(
    private candidatosService: CandidatosService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.message = '';
    this.get(this.route.snapshot.params.id);
  }

  get(id: string): void {
    this.candidatosService.get(id)
      .subscribe(
        data => {
          this.currentCandidatos = data.data;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }

  updateCandidato(): void {
    this.message = '';

    this.currentCandidatos.cpf = this.currentCandidatos.cpf?.toString();

    this.candidatosService.update(this.currentCandidatos.id, this.currentCandidatos)
      .subscribe(
        response => {
          console.log(response);
          this.message = response.message ? response.message : 'Este candidato foi atualizado com sucesso!';
        },
        error => {
          console.log(error);
        });
  }
}
