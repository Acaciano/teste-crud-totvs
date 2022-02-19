import { Component, OnInit } from '@angular/core';
import { Candidatos } from 'src/app/models/candidatos.model';
import { CandidatosService } from 'src/app/services/candidatos.service';

@Component({
  selector: 'app-adiciona-candidato',
  templateUrl: './adiciona-candidato.component.html',
  styleUrls: ['./adiciona-candidato.component.css']
})
export class AdicionaCandidatoComponent implements OnInit {
  candidato: Candidatos = {
    nome: '',
    cpf: '',
    email: '',
    idade: 0
  };

  submitted = false;

  constructor(private candidatosService: CandidatosService) { }

  ngOnInit(): void {
  }

  saveCandidato(): void {
    const data = {
      nome: this.candidato.nome,
      cpf: this.candidato.cpf?.toString(),
      email: this.candidato.email,
      idade: this.candidato.idade,
    };

    this.candidatosService.create(data)
      .subscribe(
        response => {
          console.log(response);
          this.submitted = true;
        },
        error => {
          console.log(error);
        });
  }

  newCandidato(): void {
    this.submitted = false;
    this.candidato = {
      nome: '',
      cpf: '',
      email: '',
      idade: 0,
    };
  }
}
