import { Grid } from "./../models/grid";
import { environment } from "./../environments/environment";
import { Injectable } from "@angular/core";
import { JeuService } from "./jeu.service";
import { PlayResult } from "./PlayResult";
import { HttpClient } from "@angular/common/http";
import { PartieInfo } from "src/models/partie-info";
import { Partie } from "src/models/partie";

@Injectable({
  providedIn: "root"
})
export class JeuCoreApiService extends JeuService {
  constructor(private httpClient: HttpClient) {
    super();
  }
  getParties(): Promise<PartieInfo> {
    return this.httpClient
      .get<any>(environment.serviceUrl + "/Parties")
      .toPromise()
      .then(tab =>
        tab.map(c => {
          var r = new PartieInfo();
          r.id = c.id;
          r.nomJeu = c.nomJeu;
          r.name = c.name;
          (r.sizeX = c.sizeX), (r.sizeY = c.sizeY);
          return r;
        })
      );
  }
  getPartie(id: string): Promise<Partie> {
    return this.httpClient
      .get<any>(environment.serviceUrl + "/Parties/GetPartie/" + id)
      .toPromise()
      .then(c => {
        var r = new Partie();
        r.sizeX = c.sizeX;
        r.sizeY = c.sizeY;
        r.digest(c.grid);
        r.name = c.name;
        r.nomJeu = c.nomJeu;
        r.type = c.type;
        r.id = c.id;
        return r;
      });
  }
  createPartie(name: string): Promise<Partie> {
    return this.httpClient
      .get<any>(environment.serviceUrl + `/Parties/Create/${name}/10/10`)
      .toPromise()
      .then(c => {
        var r = new Partie();
        r.sizeX = c.sizeX;
        r.sizeY = c.sizeY;
        // Transformation du tableau 1D à 2D
        r.digest(c.grid);
        r.name = c.name;
        r.id = c.id;
        return r;
      });
  }
  playGrid(id: string, x: number, y: number): Promise<PlayResult> {
    return this.httpClient
      .get<any>(environment.serviceUrl + `/Parties/Play/${id}/${x}/${y}`)
      .toPromise()
      .then(c => {
        var r = new PlayResult();
        r.grid = c.grid;
        r.message = c.message;
        return r;
      });
  }
}
