import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Proizvodjac } from '../models/entities/Proizvodjac';
import { ListResponseModel } from '../models/responses/ListResponseModel';
import { ResponseModel } from '../models/responses/ResponseModel ';

@Injectable({
  providedIn: 'root'
})
export class ProizvodjacService {

  readonly apiUrl = "https://localhost:7133/api/Proizvodjac";

  constructor(private httpClient: HttpClient) { }

getProizvodjaci(): Observable<ListResponseModel<Proizvodjac>> {
    let newPath = this.apiUrl + "/getall";
    return this.httpClient.get<ListResponseModel<Proizvodjac>>(newPath);
  }
  addProizvodjaci(proizvodjac: Proizvodjac): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(this.apiUrl + "/add", proizvodjac)
  }

  deleteProizvodjac(proizvodjac: Proizvodjac): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(this.apiUrl + "/delete", proizvodjac)
  }

  updateProizvodjac(proizvodjac: Proizvodjac): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(this.apiUrl + "/update", proizvodjac)
  }

}
