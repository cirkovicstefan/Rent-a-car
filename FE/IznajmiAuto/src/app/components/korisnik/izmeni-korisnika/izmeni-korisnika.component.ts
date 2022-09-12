import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/service/auth.service';
import { KorisnikService } from 'src/app/service/korisnik.service';

@Component({
  selector: 'app-izmeni-korisnika',
  templateUrl: './izmeni-korisnika.component.html',
  styleUrls: ['./izmeni-korisnika.component.css']
})
export class IzmeniKorisnikaComponent implements OnInit {

  @Input() korisnik: any;

  korisnikAddForm!: FormGroup;
  
  constructor(
    private serviceKorisnik: KorisnikService,
    private formBuilder: FormBuilder,
    private toastrService: ToastrService,
    private authService: AuthService
  ) { }

  ngOnInit(): void {
    this.createAddForm();
   
  }
  createAddForm() {
    this.korisnikAddForm = this.formBuilder.group({

      idKorisnika: ["", Validators.required],
      ime: ["", Validators.required],
      prezime: ["", Validators.required],
      jmbg: ["", Validators.required],
      brojTelefona: ["", Validators.required],
      email: ["", Validators.required]
    });
  }

  



  
  izmeniKorisnika() {
    
    this.korisnikAddForm.patchValue({ idKorisnika: this.korisnik.idKorisnika })
    if (this.korisnikAddForm.valid) {
      let korisnikModel = Object.assign({}, this.korisnikAddForm.value);
      this.serviceKorisnik.updateKorisnik(korisnikModel).subscribe(
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
