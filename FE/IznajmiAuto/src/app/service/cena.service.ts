import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CenaPoDanu } from '../models/entities/CenaPoDanu';
import { CenaPoDanuDetail } from '../models/entities/CenaPoDanuDetail';
import { ListResponseModel } from '../models/responses/ListResponseModel';
import { ResponseModel } from '../models/responses/ResponseModel ';

@Injectable({
  providedIn: 'root'
})
export class CenaService {

  readonly apiUrl = "https://localhost:7133/api/CenaRezervacijePoDanu";

  constructor(private httpClient: HttpClient) { }

  getAllCene(): Observable<ListResponseModel<CenaPoDanu>> {
    let newPath = this.apiUrl + "/getall";
    return this.httpClient.get<ListResponseModel<CenaPoDanu>>(newPath);
  }

  getAllCenaDetail():Observable<ListResponseModel<CenaPoDanuDetail>> {
    let newPath = this.apiUrl + "/getallDetails";
    return this.httpClient.get<ListResponseModel<CenaPoDanuDetail>>(newPath);
  }
  addCena(cena: CenaPoDanu): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(this.apiUrl + "/add", cena);
  }

  deleteCena(cena: CenaPoDanu): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(this.apiUrl + "/delete", cena);
  }

  updateCena(cena: CenaPoDanu): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(this.apiUrl + "/update", cena);
  }

}
