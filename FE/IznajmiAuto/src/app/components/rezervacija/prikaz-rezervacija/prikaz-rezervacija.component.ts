import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { RezervacijaDetail } from 'src/app/models/entities/RezervacijaDetail';
import { RezervacijaService } from 'src/app/service/rezervacija.service';

@Component({
  selector: 'app-prikaz-rezervacija',
  templateUrl: './prikaz-rezervacija.component.html',
  styleUrls: ['./prikaz-rezervacija.component.css']
})
export class PrikazRezervacijaComponent implements OnInit {

  ListRezervacija: RezervacijaDetail[] = [];
  dataLoad: boolean = false;
  ModalTitle?: string;
  filterTerm!:string;
  rezervacija:any;
  ActivateDodajIzmeniModelKomp?: boolean;

  constructor(
    private rezervacijeService: RezervacijaService,
    private toastService:ToastrService
  ) { }

  ngOnInit(): void {
    this.getAllRezervacije();
  }

  getAllRezervacije() {
    this.rezervacijeService.getAllRezervacije().subscribe(res => {
      this.ListRezervacija = res.data;
      this.dataLoad = true;

    })
  }

  addEdit(item: any) {
    this.rezervacija = item;
    this.ModalTitle="Izmena rezervacije";
    this.ActivateDodajIzmeniModelKomp = true;
  }
  deleteClick(item: any) {
    if (confirm('Da li ste sigurni')) {
      this.rezervacijeService.deleteRezervacija(item).subscribe((response) => {
        this.toastService.error("Rezervacija je poništena.");
  
       this.getAllRezervacije();
      })
    }
  }
  closeClick(){
    this.ActivateDodajIzmeniModelKomp = false;
    this.getAllRezervacije();
  }
  addClick(){
    this.rezervacija = {
      idRezervacije:0
     }
     this.ModalTitle = "Dodaj rezervaciju";
     this.ActivateDodajIzmeniModelKomp = true;
  }
}
