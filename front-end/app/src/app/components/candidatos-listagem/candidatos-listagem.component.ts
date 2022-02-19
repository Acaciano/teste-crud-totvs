import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Candidatos } from 'src/app/models/candidatos.model';
import { CandidatosService } from 'src/app/services/candidatos.service';

@Component({
  selector: 'app-candidatos-listagem',
  templateUrl: './candidatos-listagem.component.html',
  styleUrls: ['./candidatos-listagem.component.css']
})
export class CandidatosListagemComponent implements OnInit {
  candidatos?: Candidatos[];
  candidatoAtual?: Candidatos;
  currentIndex = -1;
  search = '';

  constructor(private candidatosService: CandidatosService,
    private router: Router) { }

  ngOnInit(): void {
    this.retrievecandidatos();
  }

  retrievecandidatos(): void {
    this.candidatosService.getAll()
      .subscribe(
        data => {
          this.candidatos = data.data;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }

  refreshList(): void {
    this.retrievecandidatos();
    this.candidatoAtual = undefined;
    this.currentIndex = -1;
  }

  setActivecandidato(candidato: Candidatos, index: number): void {
    this.candidatoAtual = candidato;
    this.currentIndex = index;
  }

  searchContatos(): void {
    this.candidatosService.getFilterName(this.search)
      .subscribe(
        data => {
          this.candidatos = data.data;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }

  deleteCandidato(id: string): void {
    debugger;
    this.candidatosService.delete(id)
      .subscribe(
        response => {
          this.refreshList();
        },
        error => {
          console.log(error);
        });
  }
}
