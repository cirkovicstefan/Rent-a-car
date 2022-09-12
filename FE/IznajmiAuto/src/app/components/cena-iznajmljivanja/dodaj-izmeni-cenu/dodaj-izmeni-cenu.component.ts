import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Model } from 'src/app/models/entities/Model';
import { CenaService } from 'src/app/service/cena.service';
import { ModelService } from 'src/app/service/model.service';

@Component({
  selector: 'app-dodaj-izmeni-cenu',
  templateUrl: './dodaj-izmeni-cenu.component.html',
  styleUrls: ['./dodaj-izmeni-cenu.component.css']
})
export class DodajIzmeniCenuComponent implements OnInit {

  @Input() cena?: any;
  ListaModela?: Model[];
  autoAddForm!: FormGroup;
  constructor(
    private modelService: ModelService,
    private cenaService: CenaService,
    private formBuilder: FormBuilder,
    private toastService:ToastrService
  ) { }

  ngOnInit(): void {
    this.createAutoAddForm();
    this.getAllModeli();
  }

  getAllModeli(){
    this.modelService.getModeli().subscribe(item=>{
      this.ListaModela = item.data;
    });
  }
  createAutoAddForm() {
    this.autoAddForm = this.formBuilder.group({

      idCena: ["", Validators.required],
      datum: ["", Validators.required],
      cena: ["", Validators.required],
      idModelAutomobila: ["", Validators.required]
    });
  }
  addCena(){
    if (this.autoAddForm.valid) {
      let cenaModel = Object.assign({}, this.autoAddForm.value);
      this.cenaService.addCena(cenaModel).subscribe(
        response => {
          this.toastService.success(response.message, "Uspešno");
          window.location.reload();
       
        },
        responseError => {
          if (responseError.error.ValidationErrors.length > 0) {
            for (let i = 0; i < responseError.error.ValidationErrors.length; i++) {
              this.toastService.error(responseError.error.ValidationErrors[i].ErrorMessage, "Greška pri validaciji")
            }
          }
        })
    }
    else {
      this.toastService.error("Nepotpuna forma.", "Upozorenje!")
    }
  }
  izmeniCenu(){
    this.autoAddForm.patchValue({ idCena: this.cena.idCena })
    if (this.autoAddForm.valid) {
      let cenaModel = Object.assign({}, this.autoAddForm.value);
      this.cenaService.updateCena(cenaModel).subscribe(
        response => {
          this.toastService.success(response.message, "Uspešno");
          window.location.reload();
        },
        responseError => {
          if (responseError.error.ValidationErrors.length > 0) {
            for (let i = 0; i < responseError.error.ValidationErrors.length; i++) {
              this.toastService.error(responseError.error.ValidationErrors[i].ErrorMessage, "Greška pri validaciji")
            }
          }
        })
    }
    else {
      this.toastService.error("Nepotpuna forma.", "Upozorenje!")
    }
  }
 

}
