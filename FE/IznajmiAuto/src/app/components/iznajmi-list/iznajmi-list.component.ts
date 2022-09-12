import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UgovorIznajmljivanja } from 'src/app/models/entities/UgovorIznajmljivanja';
import { UgovorIznajmljivanjaDetail } from 'src/app/models/entities/UgovorIznajmljivanjaDetail';
import { IstorijaIznajmljivanjaService } from 'src/app/service/istorija-iznajmljivanja.service';
import { IznajmiService } from 'src/app/service/iznajmi.service';

@Component({
  selector: 'app-iznajmi-list',
  templateUrl: './iznajmi-list.component.html',
  styleUrls: ['./iznajmi-list.component.css']
})
export class IznajmiListComponent implements OnInit {

  title = "Prikaz iznajmljenih automobila";
  ListaUgovorIznajmljivanja: UgovorIznajmljivanjaDetail[] = [];
  dataLoad: boolean = false;
  filterTerm!: string;
  constructor(
    private service: IznajmiService,
    private router: Router,
    private toastService: ToastrService,
    private istorijaService: IstorijaIznajmljivanjaService
  ) { }

  ngOnInit(): void {
    this.getAllIznjamljeniAutomobili();
    // this.ListaUgovorIznajmljivanja = this.ListaUgovorIznajmljivanja.filter(x => x.status == false);
    console.log(this.ListaUgovorIznajmljivanja);
  }

  getAllIznjamljeniAutomobili() {
    this.service.getAllUgovorIznjamljivanjaDetail().subscribe(res => {
      this.ListaUgovorIznajmljivanja = res.data.filter(t => t.status == false);
      this.dataLoad = true;
      //this.ListaUgovorIznajmljivanja = this.ListaUgovorIznajmljivanja
    });
  }

  deleteClick(item: any) {
    if (confirm('Da li ste sigurni')) {
      this.service.deleteUgovorIznjamljivanja(item).subscribe((response) => {
        this.toastService.error("Iznajmljeni automobil je obrisan");

        this.getAllIznjamljeniAutomobili();
        this.ListaUgovorIznajmljivanja = this.ListaUgovorIznajmljivanja.filter(x => x.status == false);
      })
    }
  }
  Iznajmi() {
    this.router.navigate(['/auto']);
  }

  returnAuto(item: any) {
    if (confirm('Da li ste sigurni da želite da vratite automobil')) {
      this.service.returnAuto(item).subscribe((response) => {

        this.toastService.success(response.message);

        this.getAllIznjamljeniAutomobili();
        this.ListaUgovorIznajmljivanja = this.ListaUgovorIznajmljivanja.filter(x => x.status == false);
      });
      this.istorijaService.addIstorija(item).subscribe(res => {
        console.log("Uspesno")
      });
    }
  }
}
