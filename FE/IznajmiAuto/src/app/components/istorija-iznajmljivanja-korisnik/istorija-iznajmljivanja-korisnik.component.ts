import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Istorija } from 'src/app/models/entities/Istorija';
import { IstorijaDetail } from 'src/app/models/entities/IstorijaDetail';
import { Korisnik } from 'src/app/models/entities/Korisnik';
import { IstorijaIznajmljivanjaService } from 'src/app/service/istorija-iznajmljivanja.service';
import { KorisnikService } from 'src/app/service/korisnik.service';

@Component({
  selector: 'app-istorija-iznajmljivanja-korisnik',
  templateUrl: './istorija-iznajmljivanja-korisnik.component.html',
  styleUrls: ['./istorija-iznajmljivanja-korisnik.component.css']
})
export class IstorijaIznajmljivanjaKorisnikComponent implements OnInit {
  email?: string;
  korisnik?: Korisnik;
  ListIstorija: Istorija[] = [];
  dataLoaded: boolean = false;
  ListIstorijaDetail: IstorijaDetail[] = [];
  title = 'Istorija iznajmljivanja';
  filterTerm!: string;
  constructor(private serviceIstorija: IstorijaIznajmljivanjaService,
    private toastService: ToastrService,
    private korisnikService:KorisnikService
  ) { }

  ngOnInit(): void {
    this.email = localStorage.getItem("email")?.toString();

    this.korisnikService.getKorisnikByEmail(this.email!).subscribe(res => {
      this.korisnik = res.data;
      // this.ime = this.korisnik.ime;
      console.log(this.korisnik);
      this.getIstorijaDetailByIdKorisnik(Number(this.korisnik!.idKorisnika));
    });
  }

  

  getIstorijaDetailByIdKorisnik(idKorisnika:number) {
    this.serviceIstorija.getAllIstorijaDetailByIdKorisnika(idKorisnika).subscribe(res => {
      this.ListIstorijaDetail = res.data;
      this.dataLoaded = true;
    });
  }
  deleteClick(item: any) {
    if (confirm('Da li ste sigurni')) {
      this.serviceIstorija.deleteIstorija(item).subscribe((response) => {
        this.toastService.error("Istorija je obrisana.");

      //  this.getIstorijaDetail();
      })
    }
  }
}
