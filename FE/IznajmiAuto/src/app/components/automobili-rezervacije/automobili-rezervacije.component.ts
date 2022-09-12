import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AutoDetail } from 'src/app/models/entities/AutoDetail';
import { CarImage } from 'src/app/models/entities/CarImage';
import { Korisnik } from 'src/app/models/entities/Korisnik';
import { AuthService } from 'src/app/service/auth.service';
import { AutoService } from 'src/app/service/auto.service';
import { KorisnikService } from 'src/app/service/korisnik.service';

@Component({
  selector: 'app-automobili-rezervacije',
  templateUrl: './automobili-rezervacije.component.html',
  styleUrls: ['./automobili-rezervacije.component.css']
})
export class AutomobiliRezervacijeComponent implements OnInit {

  email?: string;
  korisnik?: Korisnik;
  prezime?: string;
  ime?: string;
  autoDetails: AutoDetail[] = [];
  dataLoaded = false;
  slikaPrazna = '6fa7ea97-4fe3-41cc-8c0b-927a7dfb49f2.jpg';
  // title = '  PRETRAŽI I IZNAJMI AUTOMOBIL JEDNOSTAVNO';
  title = ``;
  filterTerm!: string;
  link?: any;
  nazivModela?: any;
  dostupan?: any;
  filterKriterijum!: string;
  slika: CarImage[] = [];
  tempPath?: any;
  ind: boolean = false;

  constructor(
    private korisnikService: KorisnikService,
    private authService: AuthService,
    private router: Router,
    private autoService: AutoService,

    private toastrService: ToastrService,
    private activatedRoute: ActivatedRoute,
    private senitazer2: DomSanitizer
  ) { }
  ngOnInit(): void {
    this.tempPath = window.location.pathname;
    // console.log(this.pom)


    if (this.tempPath == '/rezervacijegost' || this.tempPath=='/') {
      this.ind = true;
    }
    this.email = localStorage.getItem("email")?.toString();

    this.korisnikService.getKorisnikByEmail(this.email!).subscribe(res => {
      this.korisnik = res.data;
      this.ime = this.korisnik.ime;
      this.prezime = this.korisnik.prezime;
      console.log(this.korisnik);
    });
    this.activatedRoute.params.subscribe(params => {
      if (params["modelId"]) {
        this.getModelById(params["modelId"]);

      }

      else {
        this.getAllAutomobili();

      }
    });

  }

  getModelById(modelId: Number) {
    this.autoService.getAutomobilisByModel(modelId).subscribe((res) => {
      this.autoDetails = res.data;
      this.dataLoaded = true;
    });
  }
  getAllAutomobili() {
    this.autoService.getAutoDetails().subscribe((res) => {
      this.autoDetails = res.data;
      this.dataLoaded = true;
    });
  }


  // odjaviSe(){
  //   if (this.authService.logout() == true) {
  //     this.router.navigate(['/login']).then(() => {
  //       window.location.reload()
  //     })
  //   }
  // }

  getByEmailKorisnik(email: string) {
    this.korisnikService.getKorisnikByEmail(this.email!).subscribe(res => {
      this.korisnik = res.data;

    });
  }

}
