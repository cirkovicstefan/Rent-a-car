import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UgovorIznajmljivanja } from '../models/entities/UgovorIznajmljivanja';
import { UgovorIznajmljivanjaDetail } from '../models/entities/UgovorIznajmljivanjaDetail';
import { ListResponseModel } from '../models/responses/ListResponseModel';
import { ResponseModel } from '../models/responses/ResponseModel ';

@Injectable({
  providedIn: 'root'
})
export class IznajmiService {

  readonly apiUrl = "https://localhost:7133/api/UgovorIznajmljivanja";

  constructor(private httpClient: HttpClient) { }

  getAllUgovorIznjamljivanja(): Observable<ListResponseModel<UgovorIznajmljivanja>> {
    let newPath = this.apiUrl + "/getall";
    return this.httpClient.get<ListResponseModel<UgovorIznajmljivanja>>(newPath);
  }

  getAllUgovorIznjamljivanjaDetail(): Observable<ListResponseModel<UgovorIznajmljivanjaDetail>> {
    let newPath = this.apiUrl + "/getalldetail";
    return this.httpClient.get<ListResponseModel<UgovorIznajmljivanjaDetail>>(newPath);
  }
  addUgovorIznjamljivanja(ugovor: UgovorIznajmljivanja): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(this.apiUrl + "/add", ugovor);
  }

  deleteUgovorIznjamljivanja(ugovor: UgovorIznajmljivanja): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(this.apiUrl + "/delete", ugovor);
  }

  updateUgovorIznjamljivanja(ugovor: UgovorIznajmljivanja): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(this.apiUrl + "/update", ugovor);
  }
  returnAuto(ugovor: UgovorIznajmljivanja): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(this.apiUrl + "/returnauto", ugovor);
  }

}
