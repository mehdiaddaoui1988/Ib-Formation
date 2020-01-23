import { Component, OnInit } from "@angular/core";
import { JeuService } from "src/services/jeu.service";
import { ActivatedRoute } from "@angular/router";
import { Partie } from "src/models/partie";

@Component({
  selector: "app-partie-play",
  templateUrl: "./partie-play.component.html",
  styleUrls: ["./partie-play.component.scss"]
})
export class PartiePlayComponent implements OnInit {
  partie: Partie;
  message: string;
  constructor(
    private jeuService: JeuService,
    private activatedRoute: ActivatedRoute
  ) {}

  async ngOnInit() {
    this.activatedRoute.params.subscribe(async params => {
      var id = params.id;
      this.partie = await this.jeuService.getPartie(id);
    });
  }

  async play(x: number, y: number) {
    var resultat = await this.jeuService.playGrid(this.partie.id, x, y);
    this.partie.digest(resultat.grid);
    this.message = resultat.message;
  }
}
