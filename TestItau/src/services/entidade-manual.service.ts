import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { EntidadeManualExibir } from 'src/Modelos/EntidadeManualExibir';
import { EntidadeManualBase } from 'src/Modelos/EntidadeManualBase';

@Injectable({
  providedIn: 'root'
})
export class EntidadeManualService {

  private readonly url: string = 'https://localhost:5001/api/EntidadeManual';

  constructor(private httpClient: HttpClient) { }
  
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }
  
  get(): Observable<EntidadeManualExibir[]>{
    return this.httpClient.get<EntidadeManualExibir[]>(this.url);
  }

  post(entidadeManual: EntidadeManualBase): Observable<boolean> {
    return this.httpClient.post<boolean>(this.url, entidadeManual, this.httpOptions);
  }
}
