import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Istorija } from 'src/app/models/entities/Istorija';
import { IstorijaDetail } from 'src/app/models/entities/IstorijaDetail';
import { IstorijaIznajmljivanjaService } from 'src/app/service/istorija-iznajmljivanja.service';

@Component({
  selector: 'app-istorija-list',
  templateUrl: './istorija-list.component.html',
  styleUrls: ['./istorija-list.component.css']
})
export class IstorijaListComponent implements OnInit {

  ListIstorija: Istorija[] = [];
  dataLoaded: boolean = false;
  ListIstorijaDetail: IstorijaDetail[] = [];
  title = 'Istorija iznajmljivanja';
  filterTerm!: string;
  ukupnaZarada: number = 0;
  constructor(private serviceIstorija: IstorijaIznajmljivanjaService,
    private toastService: ToastrService
  ) { }

  ngOnInit(): void {
    this.getIstorijaDetail();
    setTimeout(() => {
      if (this.dataLoaded == true) {
        this.ListIstorijaDetail.forEach(t => {
          this.ukupnaZarada += Number(t.zarada);
        })
      }
    }, 1000)
  }

  getAllIstorija() {
    this.serviceIstorija.getAllIstorija().subscribe(res => {
      this.ListIstorija = res.data;
      this.dataLoaded = true;
    })
  }

  getIstorijaDetail() {
    this.serviceIstorija.getAllIstorijaDetail().subscribe(res => {
      this.ListIstorijaDetail = res.data;
      this.dataLoaded = true;
    });
  }
  deleteClick(item: any) {
    if (confirm('Da li ste sigurni')) {
      this.serviceIstorija.deleteIstorija(item).subscribe((response) => {
        this.toastService.error("Istorija je obrisana.");

        this.getIstorijaDetail();
      })
    }
  }

}
