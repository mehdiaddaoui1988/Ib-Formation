import { Component, OnInit, Input } from '@angular/core';
import { Lancement } from 'src/model/lancement';
import { LancementService } from 'src/service/lancement.service';
import { EtatAtterrissage } from 'src/model/etat-atterrissage.enum';
import { Fusee } from 'src/model/fusee';

@Component({
  selector: 'app-lancement-liste',
  templateUrl: './lancement-liste.component.html',
  styleUrls: ['./lancement-liste.component.scss']
})
export class LancementListeComponent implements OnInit {
  @Input()
  tousLancements: Lancement[];

  @Input()
  fusees: Fusee[];
  fuseeSelectionne: Fusee;
  lancementsAffiches: Lancement[];

  enumEtat = EtatAtterrissage;

  constructor(private service: LancementService) {}

  async ngOnInit() {
    this.fusees = await this.service.getFusees();
    this.tousLancements = await this.service.getLancements();
    this.lancementsAffiches = await this.service.getLancements();
  }

  afficheListeLancementsTotal() {
    this.service.getLancements().then(liste => {
      this.lancementsAffiches = liste;
    });
  }
  afficheListeLancements(f: Fusee) {
    this.service.getLancementsFusee(this.fuseeSelectionne).then(liste => {
      this.lancementsAffiches = liste;
    });
  }
}
