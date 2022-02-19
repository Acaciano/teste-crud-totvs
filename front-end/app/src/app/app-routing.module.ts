import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CandidatosListagemComponent } from './components/candidatos-listagem/candidatos-listagem.component';
import { CandidatoDetalhesComponent } from './components/candidato-detalhes/candidato-detalhes.component';
import { AdicionaCandidatoComponent } from './components/adiciona-candidato/adiciona-candidato.component';

const routes: Routes = [
  { path: '', redirectTo: 'candidatos', pathMatch: 'full' },
  { path: 'candidatos', component: CandidatosListagemComponent },
  { path: 'candidatos/:id', component: CandidatoDetalhesComponent },
  { path: 'adicionar', component: AdicionaCandidatoComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
