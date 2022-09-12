import { Component, OnInit, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/service/auth.service';
import { KorisnikService } from 'src/app/service/korisnik.service';

@Component({
  selector: 'app-dodaj-izmeni-korisnika',
  templateUrl: './dodaj-izmeni-korisnika.component.html',
  styleUrls: ['./dodaj-izmeni-korisnika.component.css']
})
export class DodajIzmeniKorisnikaComponent implements OnInit {

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
      jmbg: ['', [Validators.required,Validators.minLength(13)]],
      brojTelefona: ["", Validators.required],
      email: ["", [Validators.required,Validators.email]],
      lozinka: ["", [Validators.required,Validators.minLength(8)]],
      nazivUloge: ["", Validators.required]
    });
  }

  



  addKorisnik() {
   
    if (this.korisnikAddForm.valid) {
      let korisnikModel = Object.assign({}, this.korisnikAddForm.value);
      this.authService.register(korisnikModel).subscribe(
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
