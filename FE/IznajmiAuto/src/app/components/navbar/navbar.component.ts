import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Korisnik } from 'src/app/models/entities/Korisnik';
import { AuthService } from 'src/app/service/auth.service';
import { KorisnikService } from 'src/app/service/korisnik.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  email?: string;
  korisnik?: Korisnik;
  prezime?: string;
  ime?: string;

  constructor(
    private korisnikService: KorisnikService,
    private authService:AuthService,
    private router:Router
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
   if( this.authService.logout()==true){
    this.router.navigate(['/login']).then(()=>{
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
