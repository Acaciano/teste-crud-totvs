import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Candidatos } from '../models/candidatos.model';
import { Base } from '../models/base.model';
import { environment } from 'src/environments/environment';

const baseUrl =  `${environment.urlApi}/v1/candidatos`;

@Injectable({
  providedIn: 'root'
})
export class CandidatosService {

  constructor(private http: HttpClient) { }

  getAll(): Observable<Base<Candidatos[]>> {
    return this.http.get<Base<Candidatos[]>>(baseUrl);
  }

  getFilterName(nome: string): Observable<Base<Candidatos[]>> {
    return this.http.get<Base<Candidatos[]>>(`${baseUrl}/filtroPorNome/?nome=${nome}`);
  }


  get(id: any): Observable<Base<Candidatos>> {
    return this.http.get<Base<Candidatos>>(`${baseUrl}/${id}`);
  }

  create(data: any): Observable<any> {
    return this.http.post(baseUrl, data);
  }

  update(id: any, data: any): Observable<any> {
    return this.http.put(`${baseUrl}/${id}`, data);
  }

  delete(id: any): Observable<any> {
    return this.http.delete(`${baseUrl}/${id}`);
  }
}
