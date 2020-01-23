import { Voiture } from "./voiture";

export class Quatre4 extends Voiture {
  constructor(modele: string, marque: string) {
    super(modele, marque);
  }

  demarrer(){
      super.demarrer();
      
  }
}
