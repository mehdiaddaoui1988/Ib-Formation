import { Vendable } from "./vendable";

export class Voiture implements Vendable {
  vendre(): void {
    // Implémentation de vendre
  }
  constructor(
    public modele: string,
    marque: string = "Peugeot",
    public prix: number = 1000
  ) {
    this.marque = marque;
  }

  estDemarree = false;

  private _marque?: string;
  get marque() {
    return this._marque;
  }
  set marque(value: string | undefined) {
    if (!value) {
      throw new Error("La valeur doit être fournie");
    }
    this._marque = value;
  }

  // Démarrer la voiture
  demarrer() {
    if (this.estDemarree) {
      new Error("La voiture est déjà démarrée");
    }
    this.estDemarree = true;
  }

  f(a: number, c: Voiture[], b: string): number;
  f(a: number, c: Voiture): string;
  f(a: number, c: Voiture[] | Voiture, b?: string): number | string {
    if (c instanceof Voiture) {
      return "";
    } else {
      return 0;
    }
  }
}
