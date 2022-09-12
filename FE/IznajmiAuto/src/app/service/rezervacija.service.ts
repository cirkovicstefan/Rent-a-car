import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Rezervacija } from '../models/entities/Rezervacija';
import { RezervacijaDetail } from '../models/entities/RezervacijaDetail';
import { ListResponseModel } from '../models/responses/ListResponseModel';
import { ResponseModel } from '../models/responses/ResponseModel ';

@Injectable({
  providedIn: 'root'
})
export class RezervacijaService {

  readonly apiUrl = "https://localhost:7133/api/Rezervacija";

  constructor(private httpClient: HttpClient) { }

  getAllRezervacije(): Observable<ListResponseModel<RezervacijaDetail>> {
    let newPath = this.apiUrl + "/getalldetail";
    return this.httpClient.get<ListResponseModel<RezervacijaDetail>>(newPath);
  }

  addRezervacije(rezervacija: Rezervacija): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(this.apiUrl + "/add", rezervacija);
  }

  deleteRezervacija(rezervacija: Rezervacija): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(this.apiUrl + "/delete", rezervacija);
  }

  updateRezervacija(rezervacija: Rezervacija): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(this.apiUrl + "/update", rezervacija);
  }
  rezervisaniautomobilibyIdKorisnik(idKorisnika:number):Observable<ListResponseModel<RezervacijaDetail>>{
    let newPath = this.apiUrl + "/getbyidkorisnik?idKorisnika="+idKorisnika;
    return this.httpClient.get<ListResponseModel<RezervacijaDetail>>(newPath);
  }

}
