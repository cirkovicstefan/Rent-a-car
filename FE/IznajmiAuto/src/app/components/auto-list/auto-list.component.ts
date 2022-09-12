import { Component, OnInit } from '@angular/core';
import { auto } from '@popperjs/core';
import { ToastrService } from 'ngx-toastr';
import { Auto } from 'src/app/models/entities/Auto';
import { AutoDetail } from 'src/app/models/entities/AutoDetail';
import { AutoService } from 'src/app/service/auto.service';

@Component({
  selector: 'app-auto-list',
  templateUrl: './auto-list.component.html',
  styleUrls: ['./auto-list.component.css']
})
export class AutoListComponent implements OnInit {
  filterTerm!: string;
  automobili?: AutoDetail[];
  model_auta?: any;
  ActivateDodajIzmeniKomp?: boolean;
  ModalTitle?: any;
  constructor(
    private serviceAuto: AutoService,
    private toastrService: ToastrService
  ) { }

  ngOnInit(): void {
    this.getAllAutomobili();
  }


  getAllAutomobili() {
    this.serviceAuto.getAutoDetails().subscribe(res => {
      this.automobili = res.data;
    });
  }
  deleteAuto(item: AutoDetail) {
    this.serviceAuto.deleteAuto(item).subscribe((response) => {
      this.toastrService.error("Automobil je obrisan.");

      setTimeout(() => { window.location.reload(); }, 1000);
    })
  }

}
