import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Korisnik } from '../models/entities/Korisnik';
import { ItemResponseModel } from '../models/responses/ItemResponseModel';
import { ListResponseModel } from '../models/responses/ListResponseModel';
import { ResponseModel } from '../models/responses/ResponseModel ';

@Injectable({
  providedIn: 'root'
})
export class KorisnikService {

  readonly apiUrl = "https://localhost:7133/api/Korisnik";

  constructor(private httpClient: HttpClient) { }

  getKorisnici(): Observable<ListResponseModel<Korisnik>> {
    let newPath = this.apiUrl + "/getdetail";
    return this.httpClient.get<ListResponseModel<Korisnik>>(newPath);
  }

  getKorisniciKlijenti(): Observable<ListResponseModel<Korisnik>> {
    let newPath = this.apiUrl + "/getallklijenti";
    return this.httpClient.get<ListResponseModel<Korisnik>>(newPath);
  }
  getKorisniciRadnici(): Observable<ListResponseModel<Korisnik>> {
    let newPath = this.apiUrl + "/getallradnici";
    return this.httpClient.get<ListResponseModel<Korisnik>>(newPath);
  }

  getKorisnikByEmail(email: string): Observable<ItemResponseModel<Korisnik>> {
    let newPath = this.apiUrl + "/getbyemail?email=" + email;
    return this.httpClient.get<ItemResponseModel<Korisnik>>(newPath);
  }

  deleteKorisnik(IdKorisnika: number): Observable<ResponseModel> {
    return this.httpClient.delete<ResponseModel>(this.apiUrl + "/delete/" + IdKorisnika)
  }

  aktivirajNalogKorisnika(IdKorisnika: number): Observable<ResponseModel> {
    return this.httpClient.put<ResponseModel>(this.apiUrl + "/updatestatus", IdKorisnika)
  }

  updateKorisnik(korisnik: Korisnik): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(this.apiUrl + "/update", korisnik);
  }
}
