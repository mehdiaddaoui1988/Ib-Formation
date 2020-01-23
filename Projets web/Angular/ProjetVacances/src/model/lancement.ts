import { EtatAtterrissage } from "./etat-atterrissage.enum";
import { Fusee } from './fusee';

export class Lancement {
  id: string;
  dateLancement: Date;
  chargeUtile: string;
  poidsChargeUtile: number;
  etatAtterrissage: EtatAtterrissage;
  descriptionMission: string;
  fusee: Fusee;
}
