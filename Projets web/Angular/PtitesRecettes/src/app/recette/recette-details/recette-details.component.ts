import { Component, OnInit, Input } from '@angular/core';
import { RecettesService } from 'src/service/recettes.service';
import { Ingredient } from 'src/model/ingredient';
import { ViewportScroller } from '@angular/common';
import { Recette } from 'src/model/recette';

@Component({
  selector: 'recette-details',
  templateUrl: './recette-details.component.html',
  styleUrls: ['./recette-details.component.scss']
})
export class RecetteDetailsComponent implements OnInit {

  constructor(private service: RecettesService) { }

  private _recette: Recette;
  @Input()
  public get recette(): Recette {
    return this._recette;
  }
  public set recette(value: Recette) {
    this._recette = value;
    this.service.getIngredients(value).then(resultats => {
      this.ingredients = resultats;
    });
  }
  ingredients: Ingredient[];


  ngOnInit() {
  }

}
