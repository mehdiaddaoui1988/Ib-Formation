import { Injectable } from '@angular/core';
import { MeteoService } from './meteo.service';
import { Ville } from 'src/model/ville';
import { Prevision } from 'src/model/prevision';
import { prepareEventListenerParameters } from '@angular/compiler/src/render3/view/template';


@Injectable({
  providedIn: 'root'
})
export class MeteoDurService extends MeteoService {

  constructor() {
    super();
    //#region generation villes

    const v1 = new Ville('Paris');
    v1.latitude = 21.84651151;
    v1.longitude = 72.79864531;
    this.villes.push(v1);

    const v2 = new Ville('Toulouse');
    v2.latitude = 15.84651521;
    v2.longitude = 4.136546158;
    this.villes.push(v2);

    const v3 = new Ville('Brest');
    v3.latitude = 45.24153861;
    v3.longitude = 10.24538661;
    this.villes.push(v3);
    //#endregion

    //#region generation previsions

    //#endregion

  }
  villes: Ville[] = [];


  getVilles(): Promise<Ville[]> {
    return Promise.resolve(this.villes);
  }
  getPrevisions(v: Ville): Promise<Prevision[]> {
    const resultats: Prevision[] = [];

    for (let i = 0; i < 7; i++) {
      const p = new Prevision();
      p.date = new Date(new Date().getTime() + (i * 24 * 3600 * 1000));
      p.temperature = Math.random() * 10 + 10;
      p.nebulosite = Math.floor(Math.random() * 6); // entre 0 et 5 entier;
      p.probabilitePluie = Math.floor(Math.random() * 101);
      resultats.push(p);
    }

    return Promise.resolve(resultats);
  }
}

