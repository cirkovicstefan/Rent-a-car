import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Model } from '../models/entities/Model';
import { ListResponseModel } from '../models/responses/ListResponseModel';
import { ResponseModel } from '../models/responses/ResponseModel ';

@Injectable({
  providedIn: 'root'
})
export class ModelService {

  readonly apiUrl = "https://localhost:7133/api/ModelAutomobila";

  constructor(private httpClient: HttpClient) { }

  getModeli(): Observable<ListResponseModel<Model>> {
    let newPath = this.apiUrl + "/getall";
    return this.httpClient.get<ListResponseModel<Model>>(newPath);
  }
  getModeliDetail(): Observable<ListResponseModel<Model>> {
    let newPath = this.apiUrl + "/getalldetail";
    return this.httpClient.get<ListResponseModel<Model>>(newPath);
  }
  addModel(model: Model): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(this.apiUrl + "/add", model)
  }

  deleteModel(model: Model): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(this.apiUrl + "/delete", model)
  }

  updateModel(model: Model): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(this.apiUrl + "/update", model)
  }


}
