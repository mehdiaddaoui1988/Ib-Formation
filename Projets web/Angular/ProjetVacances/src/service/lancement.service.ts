import { Injectable } from "@angular/core";
import { Lancement } from "src/model/lancement";
import { Fusee } from "src/model/fusee";

@Injectable({
  providedIn: "root"
})
export abstract class LancementService {
  constructor() {}

  abstract getLancements(): Promise<Lancement[]>;
  abstract getLancementsFusee(f: Fusee): Promise<Lancement[]>;
  abstract getFusees(): Promise<Fusee[]>;
}
