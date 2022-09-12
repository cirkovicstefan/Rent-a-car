import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Korisnik } from 'src/app/models/entities/Korisnik';
import { AuthService } from 'src/app/service/auth.service';
import { KorisnikService } from 'src/app/service/korisnik.service';

@Component({
  selector: 'app-navbar-korisnik',
  templateUrl: './navbar-korisnik.component.html',
  styleUrls: ['./navbar-korisnik.component.css']
})
export class NavbarKorisnikComponent implements OnInit {
  email?: string;
  korisnik?: Korisnik;
  prezime?: string;
  ime?: string;
  constructor(
    private korisnikService: KorisnikService,
    private authService: AuthService,
    private router: Router,
    private toastrService: ToastrService,
    private activatedRoute: ActivatedRoute,
    private senitazer2: DomSanitizer
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
  odjaviSe(){
    if (this.authService.logout() == true) {
      this.router.navigate(['/login']).then(() => {
        window.location.reload()
      })
    }
  }
  
  getByEmailKorisnik(email: string) {
    this.korisnikService.getKorisnikByEmail(this.email!).subscribe(res => {
      this.korisnik = res.data;
  
    });
  }

}
