import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { DropDownModel } from 'src/Modelos/DropDownModel';

@Injectable({
  providedIn: 'root'
})
export class ProdutoService {

  private readonly url: string = 'https://localhost:5001/api/Produto'

  constructor(private httpClient: HttpClient) { }
  
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }
  
  get(): Observable<DropDownModel[]> {
    return this.httpClient.get<DropDownModel[]>(this.url);
  }
}
