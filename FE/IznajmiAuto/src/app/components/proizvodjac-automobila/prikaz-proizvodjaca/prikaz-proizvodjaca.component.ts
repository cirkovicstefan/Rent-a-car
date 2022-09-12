import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Proizvodjac } from 'src/app/models/entities/Proizvodjac';
import { ProizvodjacService } from 'src/app/service/proizvodjac.service';

@Component({
  selector: 'app-prikaz-proizvodjaca',
  templateUrl: './prikaz-proizvodjaca.component.html',
  styleUrls: ['./prikaz-proizvodjaca.component.css']
})
export class PrikazProizvodjacaComponent implements OnInit {

  constructor(private serviceProizvodjac:ProizvodjacService,private toastService:ToastrService) { }

  ModalTitle?: any;
  ListaProizvodjacaAutomobila?: Proizvodjac[];
  ActivateDodajIzmeniModelKomp?: boolean;
  proizvodjacAutomobila?: any;
  filterTerm!: string;
  ngOnInit(): void {
    this.getAllProizvodjacAutomobila();
  }


getAllProizvodjacAutomobila(){
  this.serviceProizvodjac.getProizvodjaci().subscribe(res=>{
    this.ListaProizvodjacaAutomobila = res.data;
  });
}

  addClick() {
    this.proizvodjacAutomobila = {
      idProizvodjacAutomobila:0,
      naziv: "",
      drzava: "",
  
    }
    this.ModalTitle = "Dodaj proizvođača automobila";
    this.ActivateDodajIzmeniModelKomp = true;
    
  }
  closeClick() {
    this.ActivateDodajIzmeniModelKomp = false;
    this.getAllProizvodjacAutomobila();
  }
  addEdit(item: any) {
    this.proizvodjacAutomobila = item;
    this.ModalTitle = "Izmeni proizvođača automobila";
    this.ActivateDodajIzmeniModelKomp = true;
  }

  deleteClick(item: Proizvodjac) {
    if (confirm('Da li ste sigurni')) {
      this.serviceProizvodjac.deleteProizvodjac(item).subscribe((response) => {
        this.toastService.error(response.message);
  
       this.getAllProizvodjacAutomobila();
      })
    }
  }

}
