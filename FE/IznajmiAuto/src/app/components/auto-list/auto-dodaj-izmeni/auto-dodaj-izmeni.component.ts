import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Model } from 'src/app/models/entities/Model';
import { Proizvodjac } from 'src/app/models/entities/Proizvodjac';
import { AutoService } from 'src/app/service/auto.service';
import { ModelService } from 'src/app/service/model.service';
import { ProizvodjacService } from 'src/app/service/proizvodjac.service';

@Component({
  selector: 'app-auto-dodaj-izmeni',
  templateUrl: './auto-dodaj-izmeni.component.html',
  styleUrls: ['./auto-dodaj-izmeni.component.css']
})
export class AutoDodajIzmeniComponent implements OnInit {

  @Input() auto: any;
  ListaProiz?: Proizvodjac[] = [];
  ListaModela?: Model[] = [];
  submitted:boolean = false;

  autoAddForm!: FormGroup;
  constructor(
    private serviceAuto: AutoService,
    private modelService: ModelService,
    private proizvodjacService: ProizvodjacService,
    private toastrService: ToastrService,
    private formBuilder: FormBuilder,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.createAutoAddForm();
    this.getAllModels();
    // this.getAllProizvodjaci();
  }
  createAutoAddForm() {
    this.autoAddForm = this.formBuilder.group({
      idAutomobil: ["", Validators.required],
      idModelAutomobila: ["", Validators.required],
      brojRegistracije: ["", Validators.required],
      boja: ["", Validators.required],
      dostupan: ["", Validators.required],
      rezervisan: ["", Validators.required],
      godiste: ["", Validators.required]
    });
  }

  getAllModels() {
    this.modelService.getModeli().subscribe(res => {
      this.ListaModela = res.data;
    })
  }
  getAllProizvodjaci() {
    this.proizvodjacService.getProizvodjaci().subscribe(res => {
      this.ListaProiz = res.data;
    })
  }


  addAuto() {
    if (this.autoAddForm.valid) {
      let autoModel = Object.assign({}, this.autoAddForm.value);
      this.serviceAuto.addAuto(autoModel).subscribe(
        response => {
          this.toastrService.success(response.message, "Uspešno");
          window.location.reload();
          //this.router.navigate(['/prikaz-cena']);
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
  updateAuto() {
    this.autoAddForm.patchValue({ idAutomobil: this.auto.idAutomobil })
    if (this.autoAddForm.valid) {
      let autoModel = Object.assign({}, this.autoAddForm.value);
      this.serviceAuto.updateAuto(autoModel).subscribe(
        response => {
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

}
