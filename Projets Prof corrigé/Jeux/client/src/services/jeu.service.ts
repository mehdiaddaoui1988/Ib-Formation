import { Injectable } from "@angular/core";
import { PlayResult } from "./PlayResult";
import { PartieInfo } from "src/models/partie-info";
import { Partie } from "src/models/partie";

@Injectable({
  providedIn: "root"
})
export abstract class JeuService {
  constructor() {}
  abstract getParties(): Promise<PartieInfo>;
  abstract getPartie(id: string): Promise<Partie>;
  abstract createPartie(name: string): Promise<Partie>;
  abstract playGrid(id: string, x: number, y: number): Promise<PlayResult>;
}
