import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Korisnik } from 'src/app/models/entities/Korisnik';
import { AuthService } from 'src/app/service/auth.service';
import { KorisnikService } from 'src/app/service/korisnik.service';

@Component({
  selector: 'app-promena-lozinke-korisnika',
  templateUrl: './promena-lozinke-korisnika.component.html',
  styleUrls: ['./promena-lozinke-korisnika.component.css']
})
export class PromenaLozinkeKorisnikaComponent implements OnInit {
  email?: string;
  korisnik?: Korisnik;
  korisnikAddForm!: FormGroup;
  constructor(
    private serviceKorisnik: KorisnikService,
    private formBuilder: FormBuilder,
    private toastrService: ToastrService,
    private authService: AuthService
  ) { }

  ngOnInit(): void {
    this.createAutoAddForm();
    this.email = localStorage.getItem("email")?.toString();

    this.serviceKorisnik.getKorisnikByEmail(this.email!).subscribe(res => {
      this.korisnik = res.data;

      // console.log(this.korisnik);

    });
  }
  createAutoAddForm() {
    this.korisnikAddForm = this.formBuilder.group({
      id: ["", Validators.required],
      trenutnaLozinka: ["", Validators.required],
      novaLozinka: ["", Validators.required]
    });
  }
  promeniLozinku() {
    this.korisnikAddForm.patchValue({ id: this.korisnik?.idKorisnika })
    if (this.korisnikAddForm.valid) {
      let korisnikModel = Object.assign({}, this.korisnikAddForm.value);
      this.authService.updateUserPassword(korisnikModel).subscribe(
        response => {
          this.toastrService.success(response.message, "Uspešno izmenjena lozinka");
          //      window.location.reload();
          setTimeout(() => {

            window.location.reload();

          }, 1000);
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
