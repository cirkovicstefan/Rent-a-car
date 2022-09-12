import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { CenaPoDanu } from 'src/app/models/entities/CenaPoDanu';
import { CenaPoDanuDetail } from 'src/app/models/entities/CenaPoDanuDetail';
import { AutoService } from 'src/app/service/auto.service';
import { CenaService } from 'src/app/service/cena.service';

@Component({
  selector: 'app-cena-prikaz',
  templateUrl: './cena-prikaz.component.html',
  styleUrls: ['./cena-prikaz.component.css']
})
export class CenaPrikazComponent implements OnInit {
  ModalTitle?: any;
  ListaCenaPoDanu?: CenaPoDanuDetail[];
  ActivateDodajIzmeniModelKomp?: boolean;
  cena?: any;
  filterTerm!: string;
  constructor(private serviceCena: CenaService,
    private serviceAuto:AutoService,
    private toastService:ToastrService
    ) { }

  ngOnInit(): void {
    this.getAllCene();
  }

  

  getAllCene() {
    this.serviceCena.getAllCenaDetail().subscribe(res => {
      this.ListaCenaPoDanu = res.data;
    });
  }

  addClick() {
    this.cena = {
      idCena:0
  
  
    }
    this.ModalTitle = "Dodaj cenu iznajmljivanja";
    this.ActivateDodajIzmeniModelKomp = true;
  }
  closeClick() {
    this.ActivateDodajIzmeniModelKomp = false;
    this.getAllCene();
  }

  addEdit(item: any) {
    this.cena = item;
    this.ModalTitle = "Izmeni cenu iznajmljivanja";
    this.ActivateDodajIzmeniModelKomp = true;
  }
  deleteClick(item: any) {
    if (confirm('Da li ste sigurni')) {
      this.serviceCena.deleteCena(item).subscribe((response) => {
        this.toastService.error("Cena je obrisan.");
  
       this.getAllCene();
      })
    }
  }
}
