import { Injectable } from '@angular/core';
import { RecettesService } from './recettes.service';
import { Recette } from 'src/model/recette';
import { Ingredient } from 'src/model/ingredient';
import { Categorie } from 'src/model/categorie';

@Injectable({
  providedIn: 'root'
})
export class RecettesDurService extends RecettesService {

  constructor() {
    super();

    const r1 = new Recette();
    r1.nom = 'Hamburger de poulet et galettes de riz';
    r1.categorie = Categorie.Plat;
    r1.description = 'Hamburger de galette de riz garni de poulet et de salade';
    r1.contientGluten = false;
    this.recettes.push(r1);

    const r2 = new Recette();
    r2.nom = 'Gâteau au Yaourt Sans Gluten';
    r2.categorie = Categorie.Dessert;
    r2.description = 'Gâteau au Yaourt';
    r2.contientGluten = false;
    this.recettes.push(r2);

    const r3 = new Recette();
    r3.nom = 'Raclette';
    r3.categorie = Categorie.Plat;
    r3.description = 'Recette de cuisine à base de fromage fondu raclé, avec des pommes de terre et accompagnée de légumes au vinaigre';
    r3.contientGluten = true;
    this.recettes.push(r3);
    const r4 = new Recette();
    r4.nom = 'Soju';
    r4.categorie = Categorie.Alcool;
    r4.description = 'Alcool Coréen';
    r4.contientGluten = true;
    this.recettes.push(r4);
  }

  recettes: Recette[] = [];

  getRecette(): Promise<Recette[]> {
    // promise
    return Promise.resolve(this.recettes);
  }
  getIngredients(r: Recette): Promise<Ingredient[]> {
    const resultats: Ingredient[] = [];


    for (let index = 1; index < 6; index++) {
      const i = new Ingredient();
      i.isBio = Math.random() > 0.5 ? false : true;
      i.nom = 'Ingrédient ' + index;
      i.poids = Math.floor(Math.random() * 101);
      resultats.push(i);
    }
    return Promise.resolve(resultats);
  }



}
