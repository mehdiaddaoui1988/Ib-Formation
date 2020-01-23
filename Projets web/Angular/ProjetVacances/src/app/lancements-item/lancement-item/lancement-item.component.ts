import { Component, OnInit, Input } from "@angular/core";
import { Lancement } from "src/model/lancement";

@Component({
  selector: "app-lancement-item",
  templateUrl: "./lancement-item.component.html",
  styleUrls: ["./lancement-item.component.scss"]
})
export class LancementItemComponent implements OnInit {
  options = { weekday: "long", year: "numeric", month: "long", day: "numeric" };

  @Input()
  lancement: Lancement;
  constructor() {}

  ngOnInit() {}
}
