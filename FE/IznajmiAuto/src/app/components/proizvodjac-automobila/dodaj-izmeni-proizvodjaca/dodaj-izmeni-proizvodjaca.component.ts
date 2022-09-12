import { Component,Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ProizvodjacService } from 'src/app/service/proizvodjac.service';

@Component({
  selector: 'app-dodaj-izmeni-proizvodjaca',
  templateUrl: './dodaj-izmeni-proizvodjaca.component.html',
  styleUrls: ['./dodaj-izmeni-proizvodjaca.component.css']
})
export class DodajIzmeniProizvodjacaComponent implements OnInit {
  @Input() proizvodjacAutomobila: any;
 
  autoAddForm!: FormGroup;

  constructor(
    private serviceProizvodjaci: ProizvodjacService,
    private formBuilder: FormBuilder,
    private toastrService: ToastrService
  ) { }

  ngOnInit(): void {

    this.createAutoAddForm();
   
  }
  createAutoAddForm() {
    this.autoAddForm = this.formBuilder.group({

     
      idProizvodjacAutomobila: ["", Validators.required],
      naziv: ["", Validators.required],
      drzava: ["", Validators.required]
     
    });
  }
 


  addProizvodjacaAuta() {
    if (this.autoAddForm.valid) {
      let autoModel = Object.assign({}, this.autoAddForm.value);
      this.serviceProizvodjaci.addProizvodjaci(autoModel).subscribe(
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
  izmeniProizvodjacaAuta() {
    this.autoAddForm.patchValue({ idProizvodjacAutomobila: this.proizvodjacAutomobila.idProizvodjacAutomobila })
    if (this.autoAddForm.valid) {
      let autoModel = Object.assign({}, this.autoAddForm.value);
      this.serviceProizvodjaci.updateProizvodjac(autoModel).subscribe(
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

