import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Proizvodjac } from 'src/app/models/entities/Proizvodjac';
import { ModelService } from 'src/app/service/model.service';
import { ProizvodjacService } from 'src/app/service/proizvodjac.service';

@Component({
  selector: 'app-dodaj-izmeni-model',
  templateUrl: './dodaj-izmeni-model.component.html',
  styleUrls: ['./dodaj-izmeni-model.component.css']
})
export class DodajIzmeniModelComponent implements OnInit {
  @Input() modelAutomobila: any;
  ListaProizvodjaca?: Proizvodjac[];
  autoAddForm!: FormGroup;
  constructor(
    private serviceProizvodjaci: ProizvodjacService,
    private serviceModel: ModelService,
    private formBuilder: FormBuilder,
    private toastrService: ToastrService,
    private router: Router
  ) { }

  ngOnInit(): void {

    this.createAutoAddForm();
    this.getAllProizvodjaci();
  }
  createAutoAddForm() {
    this.autoAddForm = this.formBuilder.group({

      idModelAutomobila: ["", Validators.required],
      idProizvodjacAutomobila: ["", Validators.required],
      naziv: ["", Validators.required],
      gorivo: ["", Validators.required],
      kubikaza: ["", Validators.required],
      brojSedista: ["", Validators.required],
      menjac: ["", Validators.required]
    });
  }
  getAllProizvodjaci() {
    this.serviceProizvodjaci.getProizvodjaci().subscribe(res => {
      this.ListaProizvodjaca = res.data;
    });
  }


  addModelAuta() {
    if (this.autoAddForm.valid) {
      let autoModel = Object.assign({}, this.autoAddForm.value);
      this.serviceModel.addModel(autoModel).subscribe(
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
  izmeniModelAuta() {
    this.autoAddForm.patchValue({ idModelAutomobila: this.modelAutomobila.idModelAutomobila })
    if (this.autoAddForm.valid) {
      let autoModel = Object.assign({}, this.autoAddForm.value);
      this.serviceModel.updateModel(autoModel).subscribe(
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



