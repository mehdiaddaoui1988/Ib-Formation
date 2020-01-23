import { Guid } from "guid-typescript";

export class PartieInfo {
  id: string = Guid.create().toString();
  name: string;
  sizeX: number;
  sizeY: number;
  nomJeu: string;
}
