import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AdicionaCandidatoComponent } from './components/adiciona-candidato/adiciona-candidato.component';
import { CandidatoDetalhesComponent } from './components/candidato-detalhes/candidato-detalhes.component';
import { CandidatosListagemComponent } from './components/candidatos-listagem/candidatos-listagem.component';

@NgModule({
  declarations: [
    AppComponent,
    AdicionaCandidatoComponent,
    CandidatoDetalhesComponent,
    CandidatosListagemComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
