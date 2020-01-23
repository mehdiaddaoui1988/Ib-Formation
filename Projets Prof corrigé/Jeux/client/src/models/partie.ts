import { Grid } from "./grid";

import { PartieInfo } from "./partie-info";

export class Partie extends PartieInfo {
  grid: Grid;

  type: string;
  digest(flatGrid: number[]) {
    this.grid = [];
    flatGrid.forEach((e, i) => {
      var x = i % this.sizeX;
      var y = Math.floor(i / this.sizeX);
      if (x == 0) {
        this.grid[y] = [];
      }
      this.grid[y][x] = e;
    });
  }
}
