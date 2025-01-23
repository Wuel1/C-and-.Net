import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Pessoa } from './Pessoa';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',
  })
};

@Injectable({
  providedIn: 'root'
})

export class PessoaService {

  url = "http://localhost:5144/api/Pessoas"

  constructor(private http: HttpClient) { }

  getAllPessoas(): Observable<Pessoa[]>{
    return this.http.get<Pessoa[]>(this.url)
  }

  getPessoa(userid: Number): Observable<Pessoa>{
    const apiUrl = `${this.url}/${userid}`
    return this.http.get<Pessoa>(apiUrl)
  }

  postPessoa(pessoa: Pessoa): Observable<any>{
    return this.http.post<Pessoa>(this.url, pessoa, httpOptions)
  }

  putPessoa(pessoa: Pessoa) : Observable<any>{
    return this.http.put<Pessoa>(this.url, pessoa, httpOptions)
  }

  deletePessoa(userid: Number) : Observable<any>{
    const apiUrl = `${this.url}/${userid}`
    return this.http.delete<Number>(apiUrl, httpOptions)
  }
  
}
