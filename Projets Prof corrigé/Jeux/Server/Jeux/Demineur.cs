using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Jeux
{

    public class Demineur : JeuBase
    {

        public override Partie Initialise(int sizeX, int sizeY)
        {
            var partie = new Partie()
            {
                SizeX = sizeX,
                SizeY = sizeY,
                Grid = new byte[sizeX * sizeY],
                Type = "dem",
                NomJeu = "Démineur"
            };
           
         for(var i = 0; i < partie.Grid.Length; i++) {
                partie.Grid[i] = 253;
                }
            
            var r = new Random();
            var nbMines = 0;
            while(nbMines < 15)
            {
                var x = r.Next(sizeX);
                var y = r.Next(sizeY);
                if(partie.getCell(x, y) == 253){
                    partie.setCell(x,y, 255);
                    nbMines++;
                }
               
               
            }
         
  
         
            return partie;
        }
      
        public override string Jouer(Partie p, int x, int y)
        {
           
            var val = p.getCell(x, y);
            if (val != null)
            {
                if (val == 255)
                {
                    p.setCell(x, y, 254);
                    return "perdu !";
                }
                else
                {
                    if (val == 253)
                    {
                 var nb = get9Cells(p, x, y).Where(c => c == 255).Count();

                    p.setCell(x, y,(byte) nb);
                    if (nb == 0)
                    {
                   
                        for (var i = -1; i <= 1; i++)
                            for (var j = -1; j <= 1; j++)
                                Jouer(p, x + i, y + j);
                    };
                    }
   
                }
            }


            if (!p.Grid.Any(c => c == 253)) return "Gagné";
            return "Ok";
        }


    }
}
