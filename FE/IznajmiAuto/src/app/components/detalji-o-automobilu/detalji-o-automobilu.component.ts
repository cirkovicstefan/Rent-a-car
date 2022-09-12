import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AutoDetail } from 'src/app/models/entities/AutoDetail';
import { AutoService } from 'src/app/service/auto.service';
import { IznajmiService } from 'src/app/service/iznajmi.service';

@Component({
  selector: 'app-detalji-o-automobilu',
  templateUrl: './detalji-o-automobilu.component.html',
  styleUrls: ['./detalji-o-automobilu.component.css']
})
export class DetaljiOAutomobiluComponent implements OnInit {

  autoDetails: AutoDetail[] = [];
  dataLoaded = false;
  title = 'Detalji o automobilima';
  IdRole:any;

  constructor(private autoService: AutoService,
    private iznajmiService: IznajmiService,
    private toastrService: ToastrService,
    private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      if (params["autoId"]) {
        this.getAutomobiliById(params["autoId"]);
      }

    });
    this.IdRole = localStorage.getItem('IdRole')?.toString();
    // console.log(this.IdRole)
  }

  addToCart(item:any){

  }

  setCarouselClassName(index:number){
    if(index == 0){
      return "carousel-item active";
    }
    else {
      return "carousel-item";
    }
  }

  getAutomobiliById(autoId: number) {
    this.autoService.getAutomobiliById(autoId).subscribe((res) => {
      this.autoDetails = res.data;
      this.dataLoaded = true;
    });
  }
  getAllAutomobili() {
    this.autoService.getAutoDetails().subscribe((res) => {
      this.autoDetails = res.data;
      this.dataLoaded = true;
    });
  }

}
