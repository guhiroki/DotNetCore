import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { DropDownModel } from 'src/Modelos/DropDownModel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProdutoCosifService {

  private readonly url: string = 'https://localhost:5001/api/ProdutoCosif'

  constructor(private httpClient: HttpClient) { }
  
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }
  
  get(codigoProduto: string): Observable<DropDownModel[]> {
    return this.httpClient.get<DropDownModel[]>(this.url + '/' + codigoProduto);
  }
}
