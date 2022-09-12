import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import {ReactiveFormsModule,FormsModule} from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ToastrModule } from "ngx-toastr";
import { AutoComponent } from './components/auto/auto.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { HttpClientModule } from '@angular/common/http';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { HeaderComponent } from './components/header/header.component';
import { CarouselModule } from 'ngx-owl-carousel-o';
import { DetaljiOAutomobiluComponent } from './components/detalji-o-automobilu/detalji-o-automobilu.component';

import { AutoListComponent } from './components/auto-list/auto-list.component';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { ModelAutaComponent } from './components/model-auta/model-auta.component';
import { ModelAutaPrikazComponent } from './components/model-auta/model-auta-prikaz/model-auta-prikaz.component';

import { DodajIzmeniModelComponent } from './components/model-auta/dodaj-izmeni-model/dodaj-izmeni-model.component';
import { ProizvodjacAutomobilaComponent } from './components/proizvodjac-automobila/proizvodjac-automobila.component';
import { PrikazProizvodjacaComponent } from './components/proizvodjac-automobila/prikaz-proizvodjaca/prikaz-proizvodjaca.component';
import { DodajIzmeniProizvodjacaComponent } from './components/proizvodjac-automobila/dodaj-izmeni-proizvodjaca/dodaj-izmeni-proizvodjaca.component';
import { KorisnikComponent } from './components/korisnik/korisnik.component';
import { PrikazKorisnikaComponent } from './components/korisnik/prikaz-korisnika/prikaz-korisnika.component';
import { DodajIzmeniKorisnikaComponent } from './components/korisnik/dodaj-izmeni-korisnika/dodaj-izmeni-korisnika.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CenaIznajmljivanjaComponent } from './components/cena-iznajmljivanja/cena-iznajmljivanja.component';
import { CenaPrikazComponent } from './components/cena-iznajmljivanja/cena-prikaz/cena-prikaz.component';
import { DodajIzmeniCenuComponent } from './components/cena-iznajmljivanja/dodaj-izmeni-cenu/dodaj-izmeni-cenu.component';
import { PromeniLozinkuComponent } from './components/korisnik/promeni-lozinku/promeni-lozinku.component';
import { IzmeniKorisnikaComponent } from './components/korisnik/izmeni-korisnika/izmeni-korisnika.component';
import { IznajmiAutoComponent } from './components/iznajmi-auto/iznajmi-auto.component';
import { IznajmiListComponent } from './components/iznajmi-list/iznajmi-list.component';
import { IstorijaListComponent } from './components/istorija-list/istorija-list.component';
import { SlikeAutomobilaComponent } from './components/slike-automobila/slike-automobila.component';
import { RezervacijaComponent } from './components/rezervacija/rezervacija.component';
import { PrikazRezervacijaComponent } from './components/rezervacija/prikaz-rezervacija/prikaz-rezervacija.component';
import { DodajIzmeniRezervacijuComponent } from './components/rezervacija/dodaj-izmeni-rezervaciju/dodaj-izmeni-rezervaciju.component';


import { AutoDodajIzmeniComponent } from './components/auto-list/auto-dodaj-izmeni/auto-dodaj-izmeni.component';
import { PrikazAutomobilaComponent } from './components/auto-list/prikaz-automobila/prikaz-automobila.component';
import { PocetnaComponent } from './components/pocetna/pocetna.component';
import { AutomobiliRezervacijeComponent } from './components/automobili-rezervacije/automobili-rezervacije.component';
import { RezervisiAutomobilFormaComponent } from './components/rezervisi-automobil-forma/rezervisi-automobil-forma.component';
import { NavbarKorisnikComponent } from './components/navbar-korisnik/navbar-korisnik.component';
import { RezervisaniAutomobiliKorisnikComponent } from './components/rezervisani-automobili-korisnik/rezervisani-automobili-korisnik.component';
import { IstorijaIznajmljivanjaKorisnikComponent } from './components/istorija-iznajmljivanja-korisnik/istorija-iznajmljivanja-korisnik.component';
import { ProfilKorisnikaComponent } from './components/profil-korisnika/profil-korisnika.component';
import { PromenaLozinkeKorisnikaComponent } from './components/promena-lozinke-korisnika/promena-lozinke-korisnika.component';
import { NavbarGostComponent } from './components/navbar-gost/navbar-gost.component';


@NgModule({
  declarations: [
    AppComponent,
  
    AutoComponent,
    NavbarComponent,
    LoginComponent,
    RegisterComponent,
    HeaderComponent,
    DetaljiOAutomobiluComponent,
 
    AutoListComponent,
    ModelAutaComponent,
    ModelAutaPrikazComponent,
    DodajIzmeniModelComponent,
    ProizvodjacAutomobilaComponent,
    PrikazProizvodjacaComponent,
    DodajIzmeniProizvodjacaComponent,
    KorisnikComponent,
    PrikazKorisnikaComponent,
    DodajIzmeniKorisnikaComponent,
    CenaIznajmljivanjaComponent,
    CenaPrikazComponent,
    DodajIzmeniCenuComponent,
    PromeniLozinkuComponent,
    IzmeniKorisnikaComponent,
    IznajmiAutoComponent,
    IznajmiListComponent,
    IstorijaListComponent,
    SlikeAutomobilaComponent,
    RezervacijaComponent,
    PrikazRezervacijaComponent,
    DodajIzmeniRezervacijuComponent,


     AutoDodajIzmeniComponent,
     PrikazAutomobilaComponent,
     PocetnaComponent,
     AutomobiliRezervacijeComponent,
     RezervisiAutomobilFormaComponent,
     NavbarKorisnikComponent,
     RezervisaniAutomobiliKorisnikComponent,
     IstorijaIznajmljivanjaKorisnikComponent,
     ProfilKorisnikaComponent,
     PromenaLozinkeKorisnikaComponent,
     NavbarGostComponent

   
  ],
  imports: [
    CarouselModule,
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    ToastrModule.forRoot({positionClass:"toast-bottom-right"}),
    Ng2SearchPipeModule,
    BrowserAnimationsModule
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
