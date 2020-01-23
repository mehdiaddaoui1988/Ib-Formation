import { Injectable } from '@angular/core';
import { Recette } from 'src/model/recette';
import { Ingredient } from 'src/model/ingredient';

@Injectable({
  providedIn: 'root'
})
export abstract class RecettesService {

  calculEnergie(i: Ingredient) {
    return null;
  }

  abstract getRecette(): Promise<Recette[]>;
  abstract getIngredients(r: Recette): Promise<Ingredient[]>;

}
