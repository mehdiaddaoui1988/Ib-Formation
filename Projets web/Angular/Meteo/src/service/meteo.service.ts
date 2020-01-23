import { Injectable } from '@angular/core';
import { Ville } from 'src/model/ville';
import { Prevision } from 'src/model/prevision';
import * as SunCalc from 'suncalc'

@Injectable({
  providedIn: 'root'
})
export abstract class MeteoService {
  // Fonction valable pour tout type de service météo
  celsiusToFahrenheit(c: number) {
    return (9 / 5) * c + 32;
  }

  getMoonPhase(date: Date = new Date()) {
    return SunCalc.getMoonIllumination(date);
  }

  // Renvoie une promise d'un tableau de ville. On va chercher dans un service, donc il faut une promesse
  abstract getVilles(): Promise<Ville[]>;

  abstract getPrevisions(v: Ville): Promise<Prevision[]>;


}
