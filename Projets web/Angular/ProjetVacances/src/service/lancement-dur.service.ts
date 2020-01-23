import { Injectable } from '@angular/core';
import { LancementService } from './lancement.service';
import { Fusee } from 'src/model/fusee';
import { Lancement } from 'src/model/lancement';
import { EtatAtterrissage } from 'src/model/etat-atterrissage.enum';

@Injectable({
  providedIn: 'root'
})
export class LancementDurService extends LancementService {
  constructor() {
    super();

    const f1 = new Fusee();
    f1.entreprise = 'SpaceX';
    f1.modele = 'Falcon 9';
    f1.nombreDeVols = 0;
    this.fusees.push(f1);

    const f2 = new Fusee();
    f2.entreprise = 'SpaceX';
    f2.modele = 'Falcon Heavy';
    f2.nombreDeVols = 1;
    this.fusees.push(f2);

    const f3 = new Fusee();
    f3.entreprise = 'Blue Origin';
    f3.modele = 'New Shepard';
    f3.nombreDeVols = 4;
    this.fusees.push(f3);

    const l1 = new Lancement();
    l1.chargeUtile = '60 Starlink version 1 satellites';
    l1.poidsChargeUtile = 15400;
    l1.etatAtterrissage = EtatAtterrissage.Reussite;
    l1.dateLancement = new Date('04/01/2020');
    l1.descriptionMission =
      'SpaceX\'s first flight of 2020 will launch the second batch of Starlink version 1 satellites into orbit aboard a Falcon 9 rocket.';
    l1.fusee = f1;
    this.lancements.push(l1);

    const l2 = new Lancement();
    l2.chargeUtile = 'Elon\'s midnight cherry Tesla Roadster';
    l2.poidsChargeUtile = 1305;
    l2.etatAtterrissage = EtatAtterrissage.Reussite;
    l2.dateLancement = new Date('06/02/2018');
    l2.descriptionMission =
      'SpaceX\'s test flight of Falcon Heavy. Core stage landing not successful, side core landings successful. Vehicle is sucessfully put to orbit.';
    this.lancements.push(l2);
    l2.fusee = f2;

    const l3 = new Lancement();
    l3.chargeUtile = 'test';
    l3.poidsChargeUtile = 1305;
    l3.etatAtterrissage = EtatAtterrissage.Echec;
    l3.dateLancement = new Date('06/02/2018');
    l3.descriptionMission = 'test';
    this.lancements.push(l3);
    l3.fusee = f2;
  }

  enumEtat: EtatAtterrissage;
  fusees: Fusee[] = [];
  lancements: Lancement[] = [];

  getLancementsFusee(f: Fusee): Promise<Lancement[]> {
    return Promise.resolve(this.lancements.filter(l => l.fusee === f));
  }
  getLancements(): Promise<Lancement[]> {
    return Promise.resolve(this.lancements);
  }
  getFusees(): Promise<Fusee[]> {
    return Promise.resolve(this.fusees);
  }
}
