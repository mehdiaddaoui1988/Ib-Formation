import { Injectable } from '@angular/core';
import { MeteoService } from './meteo.service';
import { Ville } from 'src/model/ville';
import { Prevision } from 'src/model/prevision';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MeteoHttpFormateurService extends MeteoService {

  // L'instance de HttpClient est fournie par l'injecteur de dépendance
  // A condition que le HttpClientModule soit référénce dans les imports de app.module
  constructor(private httpClient: HttpClient) {
    super();
  }

  getVilles(): Promise<Ville[]> {
    // Faire la requête au service en ligne

    // J'obtiens une promesse à partir de la requête
    return this.httpClient.get<any[]>('http://192.168.107.20/getVilles')
      .toPromise()
      .then(resultats => {
        // Resultats : tableau de DTO
        const villes = resultats.map(dto => {
          const pocoVille = new Ville(dto.n);
          pocoVille.latitude = dto.lat;
          pocoVille.longitude = dto.lon;

          return pocoVille;
        });

        return villes;
      });

  }
  getPrevisions(v: Ville): Promise<Prevision[]> {
    return this.httpClient.get<any[]>('http://192.168.107.20/getMeteoJours/' + v.nom)
      .toPromise()
      .then(resultats => {
        const previsions = resultats.map(dto => {
          const pocoPrevision = new Prevision();

          pocoPrevision.date = dto.d;
          pocoPrevision.nebulosite = dto.n;
          pocoPrevision.temperature = dto.t;
          pocoPrevision.probabilitePluie = dto.p;

          return pocoPrevision;
        });

        return previsions;
      });
  }

}
