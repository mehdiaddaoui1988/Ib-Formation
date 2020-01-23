import { Injectable } from '@angular/core';
import { RecettesService } from './recettes.service';
import { HttpClient } from '@angular/common/http';
import { Recette } from 'src/model/recette';
import { Ingredient } from 'src/model/ingredient';

@Injectable({
  providedIn: 'root'
})

export class RecetteHttpService extends RecettesService {
  constructor(private httpClient: HttpClient) {
    super();
  }
  getRecette(): Promise<Recette[]> {

    return this.httpClient.get<any[]>('http://192.168.107.20/getPlats')
      .toPromise()
      .then(resultats => {
        const recettes = resultats.map(dto => {
          const pocoRecette = new Recette();
          pocoRecette.nom = dto.n;
          pocoRecette.imageUrl = dto.iu;
          pocoRecette.prix = dto.p + Math.floor(Math.random() * 40);
          pocoRecette.categorie = dto.c;
          pocoRecette.contientGluten = dto.g;
          pocoRecette.id = dto.i;
          pocoRecette.description = dto.d;
          return pocoRecette;
        });
        return recettes;
      });

  }
  getIngredients(r: Recette): Promise<Ingredient[]> {
    return this.httpClient.get<any[]>('http://192.168.107.20/getComposition/' + r.id)
      .toPromise()
      .then(resultats => {
        const ingredients = resultats.map(dto => {
          const pocoIngredient = new Ingredient();
          pocoIngredient.nom = dto.nom;
          pocoIngredient.isBio = dto.bio;
          pocoIngredient.poids = dto.quantite;
          return pocoIngredient;
        });
        return ingredients;
      });
  }


}
