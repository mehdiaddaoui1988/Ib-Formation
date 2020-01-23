import { Component, OnInit, Input } from "@angular/core";
import { Fusee } from "src/model/fusee";

@Component({
  selector: "app-fusee-item",
  templateUrl: "./fusee-item.component.html",
  styleUrls: ["./fusee-item.component.scss"]
})
export class FuseeItemComponent implements OnInit {
  @Input()
  fusee: Fusee;
  constructor() {}

  ngOnInit() {}
}
