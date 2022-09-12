import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {Observable } from 'rxjs';
import { Auto } from '../models/entities/Auto';
import { AutoDetail } from '../models/entities/AutoDetail';
import { ItemResponseModel } from '../models/responses/ItemResponseModel';
import { ListResponseModel } from '../models/responses/ListResponseModel';
import { ResponseModel } from '../models/responses/ResponseModel ';

@Injectable({
  providedIn: 'root'
})
export class AutoService {

  readonly apiUrl = "https://localhost:7133/api/Automobil";

  constructor(private httpClient: HttpClient) { }

  getAutomobili(): Observable<ListResponseModel<Auto>> {
    let newPath = this.apiUrl + "/getall";
    return this.httpClient.get<ListResponseModel<Auto>>(newPath);
  }

  getAutoById(autoId: number): Observable<ItemResponseModel<Auto>> {
    let newPath = this.apiUrl + "/getbyid?idAutomobil=" + autoId;
    return this.httpClient.get<ItemResponseModel<Auto>>(newPath);
  }

  getAutoDetails(): Observable<ListResponseModel<AutoDetail>> {
    let newPath = this.apiUrl + "/getautodetails";
    return this.httpClient.get<ListResponseModel<AutoDetail>>(newPath);
  }

  getAutomobiliById(autoId: number): Observable<ListResponseModel<AutoDetail>> {
    let newPath = this.apiUrl + "/getautodetails?autoId=" + autoId;
    return this.httpClient.get<ListResponseModel<AutoDetail>>(newPath);
  }
  getAutomobiiById(autoId: number): Observable<ItemResponseModel<AutoDetail>> {
    let newPath = this.apiUrl + "/getautodetails?autoId=" + autoId;
    return this.httpClient.get<ItemResponseModel<AutoDetail>>(newPath);
  }

  getAutomobilisByModel(modelId: Number): Observable<ListResponseModel<AutoDetail>> {
    let newPath = this.apiUrl + "/getautodetailmodelby?modelId=" + modelId;
    return this.httpClient.get<ListResponseModel<AutoDetail>>(newPath);
  }

  getAutomobiliCenaBetween(cena1:number,cena2:number): Observable<ListResponseModel<AutoDetail>>{
    let newPath = this.apiUrl + `/getcenabetween/${cena1}/${cena2}`;
    return this.httpClient.get<ListResponseModel<AutoDetail>>(newPath);
  }

  

  addAuto(auto: Auto): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(this.apiUrl + "/add", auto)
  }

  deleteAuto(auto: Auto): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(this.apiUrl + "/delete", auto)
  }

  updateAuto(auto: Auto): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(this.apiUrl + "/update", auto)
  }

}
