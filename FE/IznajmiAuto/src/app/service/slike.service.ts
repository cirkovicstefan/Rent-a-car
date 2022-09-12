import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Slika } from '../models/entities/Slika';
import { Slike } from '../models/entities/Slike';
import { ListResponseModel } from '../models/responses/ListResponseModel';
import { ResponseModel } from '../models/responses/ResponseModel ';

@Injectable({
  providedIn: 'root'
})
export class SlikeService {

  readonly apiUrl = "https://localhost:7133/api/SlikaAutomobila";

  constructor(private httpClient: HttpClient) { }

  getAllSlike(): Observable<ListResponseModel<Slika>> {
    let newPath = this.apiUrl + "/getalldetail";

    return this.httpClient.get<ListResponseModel<Slika>>(newPath);
  }

  addSlike(idAutomobila:number,slika:any): Observable<ResponseModel> {
    let path = `https://localhost:7133/api/SlikaAutomobila/add?idAutomobila=${idAutomobila}&putanjaSlike&datum&${slika}`
    return this.httpClient.post<ResponseModel>(path,slika)
  }

  deleteSlika(slika: any): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(this.apiUrl + "/delete", slika)
  }

  updateSlike(slika: any): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(this.apiUrl + "/update", slika)
  }


}
