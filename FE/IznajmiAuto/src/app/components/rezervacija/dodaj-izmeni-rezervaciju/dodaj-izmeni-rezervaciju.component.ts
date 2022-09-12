import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { AutoDetail } from 'src/app/models/entities/AutoDetail';
import { Korisnik } from 'src/app/models/entities/Korisnik';
import { AutoService } from 'src/app/service/auto.service';
import { KorisnikService } from 'src/app/service/korisnik.service';
import { RezervacijaService } from 'src/app/service/rezervacija.service';

@Component({
  selector: 'app-dodaj-izmeni-rezervaciju',
  templateUrl: './dodaj-izmeni-rezervaciju.component.html',
  styleUrls: ['./dodaj-izmeni-rezervaciju.component.css']
})
export class DodajIzmeniRezervacijuComponent implements OnInit {
  @Input() rezervacija: any;
  rezervacijaAddForm!: FormGroup;
  ListaAutomobila: AutoDetail[] = [];
  ListaKorisnika: Korisnik[] = [];
  constructor(
    private serviceRezervacija: RezervacijaService,
    private serviceAuto: AutoService,
    private formBuilder: FormBuilder,
    private toastrService: ToastrService,
    private korisnikService: KorisnikService
  ) { }

  ngOnInit(): void {
    this.createRezervacijeAddForm();
    this.getAllAutomobili();
    this.getAllKorisnici();
   
  }

  getAllAutomobili() {
    this.serviceAuto.getAutoDetails().subscribe(res => {
      this.ListaAutomobila = res.data;
      this.ListaAutomobila = this.ListaAutomobila.filter(x => x.dostupan == true);
    })
  }

  createRezervacijeAddForm() {
    this.rezervacijaAddForm = this.formBuilder.group({
      idRezervacije: ["", Validators.required],
      datum: ["", Validators.required],
      idKorisnika: ["", Validators.required],
      idAutomobila: ["", Validators.required]
    });
  }

  getAllKorisnici() {
    this.korisnikService.getKorisniciKlijenti().subscribe(res => {
      this.ListaKorisnika = res.data;
    })
  }
  addRezervacija() {
    if (this.rezervacijaAddForm.valid) {
      let rezervacijeModel = Object.assign({}, this.rezervacijaAddForm.value);
      this.serviceRezervacija.addRezervacije(rezervacijeModel).subscribe(
        response => {
          if (response.message == 'Nalog korisnika nije aktivan') {
            this.toastrService.error(response.message, "Greška");
            setTimeout(() => {
              window.location.reload();
            }, 1000)
            return;
          }
          this.toastrService.success(response.message, "Uspešno");
          window.location.reload();
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
  IzmeniRezervaciju() {
    this.rezervacijaAddForm.patchValue({ idRezervacije: this.rezervacija.idRezervacije })
    if (this.rezervacijaAddForm.valid) {
      let rezervacijaModel = Object.assign({}, this.rezervacijaAddForm.value);
      this.serviceRezervacija.updateRezervacija(rezervacijaModel).subscribe(
        response => {
          this.toastrService.success(response.message, "Successful");
          window.location.reload();
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
