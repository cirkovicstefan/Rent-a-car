import { ParseSpan } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router, UrlSegment } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'IznajmiAuto';
  pom?:string;
  indikator: boolean = false;
  constructor(router: Router,route: ActivatedRoute) {
  
   
  }
  

  ngOnInit(): void {
    
    this.pom=window.location.pathname;
    console.log(this.pom)
    var role = localStorage.getItem('IdRole')?.toString();

    if(this.pom=='/login' || this.pom=='/register' || this.pom=='/rezervacijegost' || Number(role)==2 || this.pom=='/' ){
      this.indikator = true;
    }
  
  }
 

}
