import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AutoListComponent } from './components/auto-list/auto-list.component';
import { PrikazAutomobilaComponent } from './components/auto-list/prikaz-automobila/prikaz-automobila.component';

import { AutoComponent } from './components/auto/auto.component';
import { AutomobiliRezervacijeComponent } from './components/automobili-rezervacije/automobili-rezervacije.component';
import { CenaPrikazComponent } from './components/cena-iznajmljivanja/cena-prikaz/cena-prikaz.component';
import { DetaljiOAutomobiluComponent } from './components/detalji-o-automobilu/detalji-o-automobilu.component';
import { IstorijaIznajmljivanjaKorisnikComponent } from './components/istorija-iznajmljivanja-korisnik/istorija-iznajmljivanja-korisnik.component';
import { IstorijaListComponent } from './components/istorija-list/istorija-list.component';
import { IznajmiAutoComponent } from './components/iznajmi-auto/iznajmi-auto.component';
import { IznajmiListComponent } from './components/iznajmi-list/iznajmi-list.component';
import { PrikazKorisnikaComponent } from './components/korisnik/prikaz-korisnika/prikaz-korisnika.component';
import { LoginComponent } from './components/login/login.component';
import { ModelAutaPrikazComponent } from './components/model-auta/model-auta-prikaz/model-auta-prikaz.component';

import { NavbarComponent } from './components/navbar/navbar.component';
import { PocetnaComponent } from './components/pocetna/pocetna.component';
import { ProfilKorisnikaComponent } from './components/profil-korisnika/profil-korisnika.component';

import { PrikazProizvodjacaComponent } from './components/proizvodjac-automobila/prikaz-proizvodjaca/prikaz-proizvodjaca.component';
import { PromenaLozinkeKorisnikaComponent } from './components/promena-lozinke-korisnika/promena-lozinke-korisnika.component';
import { RegisterComponent } from './components/register/register.component';
import { PrikazRezervacijaComponent } from './components/rezervacija/prikaz-rezervacija/prikaz-rezervacija.component';
import { RezervisaniAutomobiliKorisnikComponent } from './components/rezervisani-automobili-korisnik/rezervisani-automobili-korisnik.component';
import { RezervisiAutomobilFormaComponent } from './components/rezervisi-automobil-forma/rezervisi-automobil-forma.component';
import { SlikeAutomobilaComponent } from './components/slike-automobila/slike-automobila.component';

import { LoginGuard } from './guards/LoginGuard';
import { LoginGuardKorisnik } from './guards/LoginGuardKorisnik';

const routes: Routes = [
  //{path: '**', component: LoginComponent},
 {
  path: '',
  redirectTo: '/rezervacijegost',
  pathMatch: 'full'
},
  //{ path: "", pathMatch: "full", component: LoginComponent },
  { path: "login", component: LoginComponent },
  { path: "pocetna", component: PocetnaComponent, canActivate: [LoginGuard] },
  { path: "navbar", component: NavbarComponent, canActivate: [LoginGuard] },
  { path: "register", component: RegisterComponent },
  { path: "auto", component: AutoComponent, canActivate: [LoginGuard] },
  { path: "autodetail/:autoId", component: DetaljiOAutomobiluComponent, canActivate: [LoginGuard] },

  { path: "auto-list", component: PrikazAutomobilaComponent, canActivate: [LoginGuard] },

  { path: "prikaz-modela", component: ModelAutaPrikazComponent, canActivate: [LoginGuard] },
  { path: "prikaz-proizvodjaca", component: PrikazProizvodjacaComponent, canActivate: [LoginGuard] },
  { path: "prikaz-korisnika", component: PrikazKorisnikaComponent, canActivate: [LoginGuard] },
  { path: "prikaz-cena", component: CenaPrikazComponent, canActivate: [LoginGuard] },
  { path: "iznajmi-auto/:autoId", component: IznajmiAutoComponent, canActivate: [LoginGuard] },
  { path: "lista-iznjmljenih", component: IznajmiListComponent, canActivate: [LoginGuard] },
  { path: "lista-istorija", component: IstorijaListComponent, canActivate: [LoginGuard] },
  { path: "lista-rezervacija", component: PrikazRezervacijaComponent, canActivate: [LoginGuard] },
  { path: "rezervacijegost", component: AutomobiliRezervacijeComponent},
  { path: "rezervacije", component: AutomobiliRezervacijeComponent, canActivate: [LoginGuardKorisnik]},
  { path: "autodetailKorisnik/:autoId", component: DetaljiOAutomobiluComponent},
  { path: "rezervisi-automobil/:autoId", component: RezervisiAutomobilFormaComponent, canActivate: [LoginGuardKorisnik] },
  { path: "rezervisi-automobil-korisnik", component: RezervisaniAutomobiliKorisnikComponent, canActivate: [LoginGuardKorisnik] },
  { path: "istorija-iznjamljivanja-korisnik", component: IstorijaIznajmljivanjaKorisnikComponent, canActivate: [LoginGuardKorisnik] },
  { path: "profil-korisnika", component: ProfilKorisnikaComponent, canActivate: [LoginGuardKorisnik] },
  { path: "promena-lozinke-korisnika", component: PromenaLozinkeKorisnikaComponent, canActivate: [LoginGuardKorisnik] },
 
  { path: "upload-slike", component: SlikeAutomobilaComponent, canActivate: [LoginGuard] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
