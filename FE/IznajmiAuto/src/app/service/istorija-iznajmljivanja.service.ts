import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Istorija } from '../models/entities/Istorija';
import { IstorijaDetail } from '../models/entities/IstorijaDetail';
import { ListResponseModel } from '../models/responses/ListResponseModel';
import { ResponseModel } from '../models/responses/ResponseModel ';

@Injectable({
  providedIn: 'root'
})
export class IstorijaIznajmljivanjaService {

  readonly apiUrl = "https://localhost:7133/api/IstorijaIznajmljivanja";

  constructor(private httpClient: HttpClient) { }

  addIstorija(istorija: any): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(this.apiUrl + "/add", istorija);
  }

  getAllIstorija(): Observable<ListResponseModel<Istorija>> {

    let newPath = this.apiUrl + "/getall";
    return this.httpClient.get<ListResponseModel<Istorija>>(newPath);

  }

  getAllIstorijaDetail(): Observable<ListResponseModel<IstorijaDetail>> {
    let newPath = this.apiUrl + "/getalldetail";
    return this.httpClient.get<ListResponseModel<IstorijaDetail>>(newPath);
  }

  deleteIstorija(istorija:Istorija): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(this.apiUrl + "/delete", istorija);
  }
  getAllIstorijaDetailByIdKorisnika(idKorisnika:number): Observable<ListResponseModel<IstorijaDetail>> {
    let newPath = this.apiUrl + "/getistorijaiznajmljivanjabyidKorisnika?idKorisnika="+idKorisnika;
    return this.httpClient.get<ListResponseModel<IstorijaDetail>>(newPath);
  }

}
