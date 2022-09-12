import { Component, OnInit } from '@angular/core';
import { Korisnik } from 'src/app/models/entities/Korisnik';
import { KorisnikService } from 'src/app/service/korisnik.service';

@Component({
  selector: 'app-profil-korisnika',
  templateUrl: './profil-korisnika.component.html',
  styleUrls: ['./profil-korisnika.component.css']
})
export class ProfilKorisnikaComponent implements OnInit {
  email?: string;
  korisnik?: Korisnik;
  prezime?: string;
  ime?: string;
  constructor(
    private korisnikService: KorisnikService
  ) { }

  ngOnInit(): void {
    this.email = localStorage.getItem("email")?.toString();

    this.korisnikService.getKorisnikByEmail(this.email!).subscribe(res => {
      this.korisnik = res.data;
      this.ime = this.korisnik.ime;
      this.prezime = this.korisnik.prezime;
      console.log(this.korisnik);
    });
  }
  getByEmailKorisnik(email: string) {
    this.korisnikService.getKorisnikByEmail(this.email!).subscribe(res => {
      this.korisnik = res.data;
  
    });
  }
}
