import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AutoDetail } from 'src/app/models/entities/AutoDetail';
import { Korisnik } from 'src/app/models/entities/Korisnik';
import { AuthService } from 'src/app/service/auth.service';
import { AutoService } from 'src/app/service/auto.service';
import { KorisnikService } from 'src/app/service/korisnik.service';
import { RezervacijaService } from 'src/app/service/rezervacija.service';

@Component({
  selector: 'app-rezervisi-automobil-forma',
  templateUrl: './rezervisi-automobil-forma.component.html',
  styleUrls: ['./rezervisi-automobil-forma.component.css']
})
export class RezervisiAutomobilFormaComponent implements OnInit {
  email?: string;
  korisnik?: Korisnik;
  prezime?: string;
  ime?: string;
  autoDetails: AutoDetail[] = [];
  idKorisnika?:number;
  rezervacijaAddForm!: FormGroup;
  constructor(
    private korisnikService: KorisnikService,
    private authService: AuthService,
    private activatedRoute: ActivatedRoute,
    private autoService: AutoService,
    private formBuilder: FormBuilder,
    private serviceRezervacija:RezervacijaService,
    private toastrService:ToastrService
  ) { }
 
  ngOnInit(): void {
     this.createRezervacijeAddForm();
    this.email = localStorage.getItem("email")?.toString();

    this.korisnikService.getKorisnikByEmail(this.email!).subscribe(res => {
      this.korisnik = res.data;
      this.ime = this.korisnik.ime;
      this.prezime = this.korisnik.prezime;
      console.log(this.korisnik);
      
    });

    this.activatedRoute.params.subscribe(params => {
      if (params["autoId"]) {
        this.getAutomobiliById(params["autoId"]);
      }

    });
  }
  createRezervacijeAddForm() {
    this.rezervacijaAddForm = this.formBuilder.group({
      
      datum: ["", Validators.required],
      idKorisnika: ["", Validators.required],
      idAutomobila: ["", Validators.required]
    });
  }
  getAutomobiliById(autoId: number) {
    this.autoService.getAutomobiliById(autoId).subscribe((res) => {
      this.autoDetails = res.data;
     // this.dataLoaded = true;
    });
  }
  Rezervisi(){
    if (this.rezervacijaAddForm.valid) {
      let rezervacijeModel = Object.assign({}, this.rezervacijaAddForm.value);
      this.serviceRezervacija.addRezervacije(rezervacijeModel).subscribe(
        response => {
          if(response.message=='Automobil nije dostupan'){
            this.toastrService.error(response.message,"Nedostupan");
            return;
          }
          this.toastrService.success(response.message, "Uspešno");
         // window.location.reload();
        },
        responseError => {
          if (responseError.error.ValidationErrors.length > 0) {
            for (let i = 0; i < responseError.error.ValidationErrors.length; i++) {
              this.toastrService.error(responseError.error.ValidationErrors[i].ErrorMessage, "Greška pri validaciji")
            }
          }
        })
    }
    else {
      this.toastrService.error("Nepotpuna forma.", "Upozorenje!")
    }
  }

}
