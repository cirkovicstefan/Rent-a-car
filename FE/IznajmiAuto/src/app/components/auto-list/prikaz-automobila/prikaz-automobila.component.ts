import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AutoDetail } from 'src/app/models/entities/AutoDetail';
import { AutoService } from 'src/app/service/auto.service';

@Component({
  selector: 'app-prikaz-automobila',
  templateUrl: './prikaz-automobila.component.html',
  styleUrls: ['./prikaz-automobila.component.css']
})
export class PrikazAutomobilaComponent implements OnInit {

  filterTerm!: string;
  automobili: AutoDetail[] = [];
  auto:any;
  ActivateDodajIzmeniKomp?: boolean;
  ModalTitle?: any;

  constructor(
    private serviceAuto: AutoService,
    private toastrService: ToastrService
  ) { }

  ngOnInit(): void {
    this.getAllAutomobili();
  }


  getAllAutomobili() {
    this.serviceAuto.getAutoDetails().subscribe(res => {
      this.automobili = res.data;
    });
  }
  deleteAuto(item: AutoDetail) {
    this.serviceAuto.deleteAuto(item).subscribe((response) => {
      this.toastrService.error("Automobil je obrisan.");

      setTimeout(() => { window.location.reload(); }, 1000);
    })
  }
  addClick(){
    this.auto = {
      idAutomobil:0
     }
     this.ModalTitle = "Dodaj podatke o automobil";
     this.ActivateDodajIzmeniKomp = true;
  }
  closeClick(){
    this.ActivateDodajIzmeniKomp = false;
    this.getAllAutomobili();
  }
  addEdit(item:any){
    this.auto = item;
    this.ModalTitle = "Izmeni podataka o automobilu";
    this.ActivateDodajIzmeniKomp = true;
  }
  deleteClick(item:any){
    if (confirm('Da li ste sigurni')) {
      this.serviceAuto.deleteAuto(item).subscribe((response) => {
        this.toastrService.error("Automobil je obrisan.");
  
       this.getAllAutomobili();
      })
    }
  }
}
