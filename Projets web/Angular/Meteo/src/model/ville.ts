export class Ville {
  constructor(nom: string) {
    this.nom = nom;
  }

  private _nom: string;
  public get nom(): string {
    return this._nom;
  }
  public set nom(value: string) {
    // Exécuté lorsqu'on set la valeur du nom
    if (!value) {
      throw new Error('Le nom doit être correctement renseigné');
    }
    if (!new RegExp('^[A-Z].{1,49}$').test(value)) {
      throw new Error('Le nom n\'est pas correct');
    }
    this._nom = value.trim();
  }

  latitude: number;
  longitude: number;
}

