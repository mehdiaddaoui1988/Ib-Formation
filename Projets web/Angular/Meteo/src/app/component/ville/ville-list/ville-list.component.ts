import { Component, OnInit } from '@angular/core';
import { MeteoService } from 'src/service/meteo.service';
import { Ville } from 'src/model/ville';


@Component({
  selector: 'ville-list',
  templateUrl: './ville-list.component.html',
  styleUrls: ['./ville-list.component.scss']
})
export class VilleListComponent implements OnInit {

  // Injection de dépendance
  constructor(private service: MeteoService) {
    // this.service.getVilles().then(listeVilles => {
    //   this.villesAffichees = listeVilles;
    // });
  }

  toutesLesVilles: Ville[];
  villesAffichees: Ville[];
  villeSelectionnee: Ville;
  texteRecherche: string;

  ChangeTextRecherche(t: string) {
    this.texteRecherche = t;
    this.villeSelectionnee = undefined;

    // this.villes = this.villes.filter(v => v.nom.indexOf(t)>-1);
    this.villesAffichees = this.toutesLesVilles.filter(v => v.nom.toUpperCase().includes(t.toUpperCase()));

  }

  ngOnInit() {
    this.service.getVilles().then(liste => {
      this.toutesLesVilles = liste;
      this.villesAffichees = liste;
    });
  }
}
