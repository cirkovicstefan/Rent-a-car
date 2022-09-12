import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Model } from 'src/app/models/entities/Model';
import { ModelAutomobilaDetail } from 'src/app/models/entities/ModelAutomobilaDetail';
import { ModelService } from 'src/app/service/model.service';

@Component({
  selector: 'app-model-auta-prikaz',
  templateUrl: './model-auta-prikaz.component.html',
  styleUrls: ['./model-auta-prikaz.component.css']
})
export class ModelAutaPrikazComponent implements OnInit {

  constructor(private service: ModelService, private toastService: ToastrService) { }
  ModalTitle?: any;
  ListaModelAutomobila?: Model[];
  ActivateDodajIzmeniModelKomp?: boolean;
  modelAutomobila?: any;
  filterTerm!: string;
  ListaModelaAutomobilaDetail?: ModelAutomobilaDetail[];
  ngOnInit(): void {
    this.getAllModelAutomolila();
    this.getModelAutomobilaDetail();
  }
  getAllModelAutomolila() {
    this.service.getModeli().subscribe(res => {
      this.ListaModelAutomobila = res.data;
    });

  }
  getModelAutomobilaDetail() {
    this.service.getModeliDetail().subscribe(res => {
      this.ListaModelaAutomobilaDetail = res.data;
    });
  }

  addClick() {
    this.modelAutomobila = {
      idModelAutomobila: 0,
      Proizvodjac_Id: 0,
      Naziv_Modela: "",
      Gorivo: "",
      Kubikaza: "",
      Menjac: "",
      Broj_Sedista: 0
    }
    this.ModalTitle = "Dodaj model automobila";
    this.ActivateDodajIzmeniModelKomp = true;

  }
  closeClick() {
    this.ActivateDodajIzmeniModelKomp = false;
    this.getAllModelAutomolila();
  }
  addEdit(item: any) {
    this.modelAutomobila = item;
    this.ModalTitle = "Izmeni model automobila";
    this.ActivateDodajIzmeniModelKomp = true;
  }

  deleteClick(item: Model) {
    if (confirm('Da li ste sigurni')) {
      this.service.deleteModel(item).subscribe((response) => {
        this.toastService.error(response.message);

        this.getAllModelAutomolila();
      })
    }
  }

}
