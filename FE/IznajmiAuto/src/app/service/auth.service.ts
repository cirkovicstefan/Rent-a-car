import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LocalStorageService } from './local-storage.service';
import { RegisterModel } from '../models/entities/RegisterModel';
import { TokenModel } from '../models/entities/TokenModel';
import { LoginModel } from '../models/entities/LoginModel';
import { SingleResponseModel } from '../models/responses/SingleResponseModel';
import { KorisnikPromenaLozinke } from '../models/entities/KorisnikPromenaLozinke';
import { ResponseModel } from '../models/responses/ResponseModel ';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  apiUrl = 'https://localhost:7133/api/auth/';

  constructor(private httpClient: HttpClient,
    private localStorage: LocalStorageService) { }

  register(registerModel: RegisterModel) {
    return this.httpClient.post<SingleResponseModel<TokenModel>>(this.apiUrl + "registerradnik", registerModel);
  }

  registerKorisnik(registerModel: RegisterModel) {
    return this.httpClient.post<SingleResponseModel<TokenModel>>(this.apiUrl + "registerkorisnik", registerModel);
  }

  login(loginModel: LoginModel) {
    return this.httpClient.post<SingleResponseModel<TokenModel>>(this.apiUrl + "login", loginModel);
  }

  logout() {
    this.localStorage.remove("token");
    this.localStorage.remove("email");
    this.localStorage.remove("IdRole");
    return true;
  }

  isAuthenticated() {
    if (this.localStorage.get("token")) {
      var rola = localStorage.getItem("IdRole")?.toString();
      if (Number(rola) == 1) {
        return true;
      }
      return false;
    }
    else {
      return false;
    }
  }
  isAuthenticatedKorisnik() {
    if (this.localStorage.get("token")) {
      var rola = localStorage.getItem("IdRole")?.toString();
      if (Number(rola) == 2) {
        return true;
      }
      return false;
    }
    else {
      return false;
    }
  }

  updateUserPassword(korisnikPromenaLozinke: KorisnikPromenaLozinke) {
    return this.httpClient.post<ResponseModel>(this.apiUrl + "promenalozinke", korisnikPromenaLozinke);
  }

}
