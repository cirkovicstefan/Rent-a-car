import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AutoDetail } from 'src/app/models/entities/AutoDetail';
import { CarImage } from 'src/app/models/entities/CarImage';
import { Slika } from 'src/app/models/entities/Slika';
import { AutoService } from 'src/app/service/auto.service';
import { IznajmiService } from 'src/app/service/iznajmi.service';

@Component({
  selector: 'app-auto',
  templateUrl: './auto.component.html',
  styleUrls: ['./auto.component.css']
})
export class AutoComponent implements OnInit {
  autoDetails: AutoDetail[] = [];
  dataLoaded = false;
  slikaPrazna = '6fa7ea97-4fe3-41cc-8c0b-927a7dfb49f2.jpg';
  // title = '  PRETRAŽI I IZNAJMI AUTOMOBIL JEDNOSTAVNO';
  title=`IZNAJMI AUTO`;
  filterTerm!: string;
  link?: any;
  nazivModela?: any;
  dostupan?: any;
  filterKriterijum!: string;
  slika: CarImage[] =[];

  constructor(private autoService: AutoService,
    private iznajmiService: IznajmiService,
    private toastrService: ToastrService,
    private activatedRoute: ActivatedRoute,
    private senitazer2: DomSanitizer
  ) { }

  izborProizvodjaca() {
    this.filterKriterijum = this.nazivModela;
  }
  dostupanFilter() {
    this.filterKriterijum = this.dostupan;
    console.log(this.dostupan);
  }
  ff() {
    this.autoDetails.forEach(item=>{
      // console.log(item.slikaPutanje[0].putanjaSlike!='undefine');
      //if(item.slikaPutanje==Array())
      // console.log(Array.isArray(item.slikaPutanje) && item.slikaPutanje.length>0)
      console.log(item.slikaPutanje!.length==0)
    })
  }
  ngOnInit(): void {
  
    this.activatedRoute.params.subscribe(params => {
      if (params["modelId"]) {
        this.getModelById(params["modelId"]);

      }

      else {
        this.getAllAutomobili();

      }
    });

  }

  Iznajmi(item: any) {

  }

  getModelById(modelId: Number) {
    this.autoService.getAutomobilisByModel(modelId).subscribe((res) => {
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
