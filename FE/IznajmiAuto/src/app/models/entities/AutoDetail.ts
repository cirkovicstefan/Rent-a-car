import { CarImage } from "./CarImage";

export class AutoDetail{
    idAutomobil?: number;
    idModelAutomobila?: number;
    nazivProizvodjaca?: string;
    nazivModela?: string;
    brojRegistracije?: string;
    boja?: string;
    dostupan?: boolean;
    rezervisan?: boolean;
    godiste?: number;
    cena?:number;
    gorivo?: string;
    kubikaza?: string;
    brojSedista?:number;
    menjac?: string;
    slikaPutanje?: CarImage[];
}