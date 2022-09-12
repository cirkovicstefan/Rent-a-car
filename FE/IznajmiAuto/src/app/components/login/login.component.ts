import { Component, HostBinding, OnInit, Input } from '@angular/core';
import { FormControl, FormBuilder, Validators, FormGroup, AbstractControl } from '@angular/forms';

import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/service/auth.service';
import { LocalStorageService } from 'src/app/service/local-storage.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm!: FormGroup;

  constructor(private formBuilder: FormBuilder,
    private authService: AuthService,
    private localStorage: LocalStorageService,
    private toastrService: ToastrService,
    private router: Router) { }

  ngOnInit(): void {
    this.createLoginForm();
  }

  createLoginForm() {
    this.loginForm = this.formBuilder.group({
      email: ["", [Validators.required,Validators.email]],
      lozinka: ["", Validators.required]
    })
  }

  login() {
    if (this.loginForm.valid) {

      let loginModel = Object.assign({}, this.loginForm.value)

      this.authService.login(loginModel).subscribe(
        response => {
          this.toastrService.success("Logovanje uspešno.");
          this.localStorage.set("token", response.data.token);
          this.localStorage.set("IdRole", response.data.idRole);
          this.localStorage.set("email", this.loginForm?.get("email")?.value);
       
          var rola = response.data.idRole;
          if(rola == 1){
            setTimeout(() => {
              this.router.navigate(['/auto']).then(() => {
                window.location.reload();
              });
            }, 1000);
          }else{
            setTimeout(() => {
              this.router.navigate(['/rezervacije']).then(() => {
                window.location.reload();
              });
            }, 1000);
          }
         
          

        },
        responseError => {
          this.toastrService.error(responseError.error)
        })
    }
  }

}
