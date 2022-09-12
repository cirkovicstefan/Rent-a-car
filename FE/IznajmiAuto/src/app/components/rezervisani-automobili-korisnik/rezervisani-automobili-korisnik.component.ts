import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Korisnik } from 'src/app/models/entities/Korisnik';
import { RezervacijaDetail } from 'src/app/models/entities/RezervacijaDetail';
import { KorisnikService } from 'src/app/service/korisnik.service';
import { RezervacijaService } from 'src/app/service/rezervacija.service';

@Component({
  selector: 'app-rezervisani-automobili-korisnik',
  templateUrl: './rezervisani-automobili-korisnik.component.html',
  styleUrls: ['./rezervisani-automobili-korisnik.component.css']
})
export class RezervisaniAutomobiliKorisnikComponent implements OnInit {
  email?: string;
  korisnik?: Korisnik;
  ListRezervacija: RezervacijaDetail[] = [];
  dataLoad: boolean = false;
  ModalTitle?: string;
  filterTerm!:string;
  rezervacija:any;
  idKorisnika?:number;
  ime?:string;
  ActivateDodajIzmeniModelKomp?: boolean;
  constructor(
    private rezervacijeService: RezervacijaService,
    private toastService:ToastrService,
    private korisnikService:KorisnikService
  ) { }

  ngOnInit(): void {
    this.email = localStorage.getItem("email")?.toString();

    this.korisnikService.getKorisnikByEmail(this.email!).subscribe(res => {
      this.korisnik = res.data;
      this.ime = this.korisnik.ime;
      console.log(this.korisnik);
      this.getAllRezervacije(Number(this.korisnik!.idKorisnika));
    });
    
  }
  getAllRezervacije(idKorisnika:number) {
   console.log(idKorisnika)
    this.rezervacijeService.rezervisaniautomobilibyIdKorisnik(idKorisnika).subscribe(res => {
      this.ListRezervacija = res.data;
      this.dataLoad = true;

    })
  }
  deleteClick(item: any) {
    if (confirm('Da li ste sigurni')) {
      this.rezervacijeService.deleteRezervacija(item).subscribe((response) => {
        this.toastService.error("Rezervacija je poništena.");
  
       this.getAllRezervacije(Number(this.korisnik!.idKorisnika));
      })
    }
  }
  closeClick(){
    this.ActivateDodajIzmeniModelKomp = false;
    //this.getAllRezervacije();
  }
}
