import { Component, OnInit, Input } from '@angular/core';
import { Ville } from 'src/model/ville';
import { Prevision } from 'src/model/prevision';
import { MeteoService } from 'src/service/meteo.service';
import { GetMoonIlluminationResult } from 'suncalc';

@Component({
  selector: 'ville-details',
  templateUrl: './ville-details.component.html',
  styleUrls: ['./ville-details.component.scss']
})
export class VilleDetailsComponent implements OnInit {

  constructor(private service: MeteoService) { }


  private _ville: Ville;

  @Input()
  public get ville(): Ville {
    return this._ville;
  }
  public set ville(value: Ville) {
    this._ville = value;
    // Appel au service
    this.service.getPrevisions(this.ville).then(resultats => {
      // Récupération du résultat du service dans this.previsions
      this.previsions = resultats;

    });
  }

  previsions: Prevision[];


  ngOnInit() {
  }

}
