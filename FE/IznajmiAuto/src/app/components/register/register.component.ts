import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/service/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerForm!: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private toastrService:ToastrService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.createLoginForm();
  }

  createLoginForm() {
    this.registerForm = this.formBuilder.group({
      ime: ["", Validators.required],
      prezime: ["", Validators.required],
      jmbg: ["", Validators.required],
      brojTelefona: ["", Validators.required],
      email: ["", Validators.required],
      lozinka: ["", Validators.required]
      // nazivUloge: ["", Validators.required]
    });
  }

  register() {
    if (this.registerForm?.valid) {

      let registerModel = Object.assign({}, this.registerForm?.value)
      registerModel.nazivUloge='kupac'
      this.authService.register(registerModel).subscribe(
        response => {
           this.toastrService.info(response.message + "")
          localStorage.setItem("token", response.data.token)
          setTimeout(() => { this.router.navigate(['/login']) }, 3000);
        },
        responseError => {
          console.log(responseError.error);
             this.toastrService.error(responseError.error)
        })
    }
  }

}
