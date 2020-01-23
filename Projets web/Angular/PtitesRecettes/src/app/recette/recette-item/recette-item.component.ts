import { Component, OnInit, Input } from '@angular/core';
import { Recette } from 'src/model/recette';
import { Categorie } from 'src/model/categorie';

@Component({
  selector: 'recette-item',
  templateUrl: './recette-item.component.html',
  styleUrls: ['./recette-item.component.scss']
})
export class RecetteItemComponent implements OnInit {

  @Input()
  recette: Recette;

  categorie = Categorie;
  constructor() { }

  ngOnInit() {
  }

}
