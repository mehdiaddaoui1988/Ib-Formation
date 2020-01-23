import { Component, OnInit, Input } from '@angular/core';
import { Recette } from 'src/model/recette';
import { RecettesService } from 'src/service/recettes.service';
import { Ingredient } from 'src/model/ingredient';

@Component({
  selector: 'recette-list',
  templateUrl: './recette-list.component.html',
  styleUrls: ['./recette-list.component.scss']
})
export class RecetteListComponent implements OnInit {

  @Input()
  recettes: Recette[];
  recetteSelectionne: Recette;
  constructor(private service: RecettesService) { }




  // système async
  async ngOnInit() {
    this.recettes = await this.service.getRecette();

  }
}


