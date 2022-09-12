import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Auto } from 'src/app/models/entities/Auto';
import { AutoDetail } from 'src/app/models/entities/AutoDetail';
import { CenaPoDanu } from 'src/app/models/entities/CenaPoDanu';
import { Korisnik } from 'src/app/models/entities/Korisnik';
import { AutoService } from 'src/app/service/auto.service';
import { CenaService } from 'src/app/service/cena.service';
import { IznajmiService } from 'src/app/service/iznajmi.service';
import { KorisnikService } from 'src/app/service/korisnik.service';

@Component({
  selector: 'app-iznajmi-auto',
  templateUrl: './iznajmi-auto.component.html',
  styleUrls: ['./iznajmi-auto.component.css']
})
export class IznajmiAutoComponent implements OnInit {

  autoDetails: AutoDetail[] = [];
  klijenti?: Korisnik[];
  ListCena?: CenaPoDanu[];
  auto?: Auto;
  CenaNajnovija?: number;
  BrojDana?: number;
  UkupnaCena?: number;
  IdCena?: number;


  iznajmiAddForm!: FormGroup;
  dataLoaded = false;
  constructor(
    private autoService: AutoService,
    private toastService: ToastrService,
    private activatedRoute: ActivatedRoute,
    private formBuilder: FormBuilder,
    private korisnikService: KorisnikService,
    private serviceCena: CenaService,
    private iznajmiService: IznajmiService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.createAutoAddForm();
    this.iznajmiAddForm.controls['cena'].disable();
    this.iznajmiAddForm.controls['broj_dana'].disable();
    this.iznajmiAddForm.controls['cena_po_danu'].disable();
    this.activatedRoute.params.subscribe(params => {
      if (params["autoId"]) {
        this.getAutomobiliById(params["autoId"]);
        this.getAllKlijenti();
        this.getCene();

      }
    });
  }

  cena() {
    let ind = true;
    let IznajmiModel = Object.assign({}, this.iznajmiAddForm.value);
    const date1 = new Date(IznajmiModel.iznajmljivanjeOd).getTime();
    const date2 = new Date(IznajmiModel.iznajmljivanjeDo).getTime();
    if (date1 > date2) {
      this.toastService.error("Pri izboru datuma", "Greška");
      ind = false;
    }


    this.BrojDana = this.IzracunajBrojaDanaIznajmljivanja(IznajmiModel);
    this.CenaNajnovija = this.NajnovijaCena(this.ListCena!, IznajmiModel.idModelAutomobila);
    this.UkupnaCena = this.BrojDana * this.CenaNajnovija;

    this.IdCena = this.NajnovijaCenaById(this.ListCena!, IznajmiModel.idModelAutomobila);
    return ind;
  }


  getCene() {
    this.serviceCena.getAllCenaDetail().subscribe(res => {
      this.ListCena = res.data;
    });
  }



  Iznajmi() {
    if (this.iznajmiAddForm.valid) {
      let ind = this.cena();
      if (ind == true) {
        let IznajmiModel = Object.assign({}, this.iznajmiAddForm.value);
        this.iznajmiService.addUgovorIznjamljivanja(IznajmiModel).subscribe(
          response => {

            if (response.message == 'Automobil nije dostupan.') {
              this.toastService.error(response.message, "");
              return;
            }
            if (response.message == 'Nalog korisnika nije aktivan') {
              this.toastService.error(response.message, "");
              return;
            }
            this.toastService.success(response.message, "");
            this.router.navigate(['/lista-iznjmljenih']);
            // window.location.reload();

          },
          responseError => {
            if (responseError.error.ValidationErrors.length > 0) {
              for (let i = 0; i < responseError.error.ValidationErrors.length; i++) {
                this.toastService.error(responseError.error.ValidationErrors[i].ErrorMessage, "Greška pri validaciji")
              }
            }
          })
      }
      else{
        this.toastService.error("Pri izboru datuma", "Greška");
      }

    }
    else {
      this.toastService.error("Nepotpuna forma.", "Upozorenje!")
    }

  }





  NajnovijaCena(lista: any[], idModela: number) {

    var max = Number.MIN_VALUE;
    var cena = 0;
    lista.forEach(item => {
      if (item.idModelAutomobila == idModela) {
        const datum = new Date(item.datum!);
        var vrednostMax = datum.getTime();
        if (max < vrednostMax) {
          max = vrednostMax;
          cena = item.cena;
        }
      }
    });
    return cena;
  }

  NajnovijaCenaById(lista: any[], idModela: number) {

    var max = Number.MIN_VALUE;
    var idCena = 0;
    lista.forEach(item => {
      if (item.idModelAutomobila == idModela) {
        const datum = new Date(item.datum!);
        var vrednostMax = datum.getTime();
        if (max < vrednostMax) {
          max = vrednostMax;
          idCena = item.idCena;
        }
      }
    });
    return idCena;
  }

  IzracunajBrojaDanaIznajmljivanja(item: any) {
    const date1 = new Date(item.iznajmljivanjeOd);
    const date2 = new Date(item.iznajmljivanjeDo);
    var xDate = (date2.getTime() - date1.getTime()) / (1000 * 60 * 60 * 24);
    return xDate;
  }

  createAutoAddForm() {
    this.iznajmiAddForm = this.formBuilder.group({
      idAutomobila: ["", Validators.required],
      idKorisnika: ["", Validators.required],
      iznajmljivanjeOd: ["", Validators.required],
      iznajmljivanjeDo: ["", Validators.required],
      nacinPlacanja: ["", Validators.required],
      idModelAutomobila: ["", Validators.required],
      cena: ["", Validators.required],
      broj_dana: ["", Validators.required],
      cena_po_danu: ["", Validators.required],
      idCena: ["", Validators.required]


    });
  }

  getAllKlijenti() {
    this.korisnikService.getKorisniciKlijenti().subscribe(res => {
      this.klijenti = res.data;
    });
  }
  getAutomobiliById(autoId: number) {
    this.autoService.getAutomobiliById(autoId).subscribe((res) => {
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
}
