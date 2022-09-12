import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { AutoDetail } from 'src/app/models/entities/AutoDetail';
import { Slika } from 'src/app/models/entities/Slika';
import { AutoService } from 'src/app/service/auto.service';
import { SlikeService } from 'src/app/service/slike.service';

@Component({
  selector: 'app-slike-automobila',
  templateUrl: './slike-automobila.component.html',
  styleUrls: ['./slike-automobila.component.css']
})
export class SlikeAutomobilaComponent implements OnInit {
  autoDetails: AutoDetail[] = [];
  dataLoaded = false;
  ListaSlika?: Slika[] = [];
  dataload:boolean = false;
  slikaAddForm!:FormGroup;
  file!:any;
  constructor(
    private serviceSlike: SlikeService,
    private autoService: AutoService,
    private formBuilder: FormBuilder,
    private toastService:ToastrService
  ) { }

  ngOnInit(): void {
    this.createAutoAddForm();
    this.getAllSlike();
    this.getAllAutomobili();
  }

  getAllSlike(){
    this.serviceSlike.getAllSlike().subscribe(res=>{
      this.ListaSlika = res.data;
      this.dataload = true;
    });
  }

  getAllAutomobili() {
    this.autoService.getAutoDetails().subscribe((res) => {
      this.autoDetails = res.data;
      this.dataLoaded = true;
    });
  }
  createAutoAddForm() {
    this.slikaAddForm = this.formBuilder.group({
      idAutomobila: ["", Validators.required],
      slika: ["", Validators.required]
      
    });
  }
  addSlika(){
    if (this.slikaAddForm.valid) {
      let slikaModel = Object.assign({}, this.slikaAddForm.value);
      this.serviceSlike.addSlike(slikaModel.idAutomobila,slikaModel.slika).subscribe(
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
      this.toastService.error("The form is missing.", "Attention!")
    }


  }
}
