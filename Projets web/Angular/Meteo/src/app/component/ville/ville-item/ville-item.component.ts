import { Component, OnInit, Input } from '@angular/core';
import { Ville } from 'src/model/ville';

@Component({
  selector: 'ville-item',
  templateUrl: './ville-item.component.html',
  styleUrls: ['./ville-item.component.scss']
})
export class VilleItemComponent implements OnInit {

  constructor() { }
  @Input()
  ville: Ville;

  @Input()
  couleurBulle = 'green';

  ngOnInit() {
  }


}
