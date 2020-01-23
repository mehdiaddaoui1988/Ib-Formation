import { Component, OnInit } from "@angular/core";
import { JeuService } from "src/services/jeu.service";
import { PartieInfo } from "src/models/partie-info";
import { Router } from "@angular/router";

@Component({
  selector: "app-partie-list",
  templateUrl: "./partie-list.component.html",
  styleUrls: ["./partie-list.component.scss"]
})
export class PartieListComponent implements OnInit {
  parties: PartieInfo;
  constructor(private jeuService: JeuService, private router: Router) {}

  count = 0;

  increment() {
    this.count++;
  }

  async ngOnInit() {
    this.parties = await this.jeuService.getParties();
  }

  async createPartie(name: string) {
    var partie = await this.jeuService.createPartie(name);
    this.router.navigateByUrl("/partie/" + partie.id);
  }
}
