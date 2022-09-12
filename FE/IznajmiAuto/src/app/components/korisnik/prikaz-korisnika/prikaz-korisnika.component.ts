import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Korisnik } from 'src/app/models/entities/Korisnik';
import { RegisterModel } from 'src/app/models/entities/RegisterModel';
import { AuthService } from 'src/app/service/auth.service';
import { KorisnikService } from 'src/app/service/korisnik.service';

@Component({
  selector: 'app-prikaz-korisnika',
  templateUrl: './prikaz-korisnika.component.html',
  styleUrls: ['./prikaz-korisnika.component.css']
})
export class PrikazKorisnikaComponent implements OnInit {

  ModalTitle?: any;
  ListaKorisnika?: Korisnik[];
  ActivateDodajIzmeniRadnikKomp?: boolean;
  ActiveFormPromenaLozinke?: boolean;
  ActivateIzmeniRadnikKomp?: boolean = false;
  korisnik?: any;
  filterTerm!: string;
  constructor(private serviceKorisnik: KorisnikService,
    private authService: AuthService,
    private toastService: ToastrService
  ) { }

  ngOnInit(): void {
    this.getAllKorisnici();
  }

  getAllKorisnici() {
    this.serviceKorisnik.getKorisnici().subscribe(item => {
      this.ListaKorisnika = item.data;
    });
  }

  closeClick() {
    this.ActivateDodajIzmeniRadnikKomp = false;
    this.getAllKorisnici();
  }
  addClick() {

    this.korisnik = {
      idKorisnika: 0,
      ime: '',

    }
    this.ModalTitle = "Dodaj korisnika";
    this.ActivateDodajIzmeniRadnikKomp = true;
    this.ActiveFormPromenaLozinke = false;
    this.ActivateIzmeniRadnikKomp = false;
  }
  deleteClick(item: any) {
    if (confirm('Da li ste sigurni')) {
      this.serviceKorisnik.deleteKorisnik(item.idKorisnika).subscribe((response) => {
        this.toastService.error(response.message);

        this.getAllKorisnici();
      })
    }
  }

  addEdit(item: any) {
    this.korisnik = item;
    this.ModalTitle = "Izmeni korisnika";
    this.ActivateIzmeniRadnikKomp = true;
    this.ActiveFormPromenaLozinke = false;
    this.ActivateDodajIzmeniRadnikKomp = false;
  }

  aktivirajNalog(item: any) {
    if (confirm('Da li ste sigurni da želite da aktivirate nalog korisnika')) {
      this.serviceKorisnik.aktivirajNalogKorisnika(item.idKorisnika).subscribe((response) => {
        this.toastService.success("Nalog je aktivan.");

        this.getAllKorisnici();
      })
    }
  }
  promenaLozinke(item: any) {
    this.korisnik = item;
    this.ModalTitle = "Promena lozinke";
    this.ActiveFormPromenaLozinke = true;
    this.ActivateIzmeniRadnikKomp = false;
    this.ActivateDodajIzmeniRadnikKomp = false;

  }
}
