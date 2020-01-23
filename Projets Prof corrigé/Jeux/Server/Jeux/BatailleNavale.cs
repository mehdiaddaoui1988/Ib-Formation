using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Jeux
{
    public class BatailleNavale : JeuBase
    {
       
        public enum CellValue : Byte
        {
            Rien =0,
            Bateau=1,
            ALeau=2,
            Touche=3,
            Coule=7
        }
        public bool PutBoat(Partie p, int nbCells)
        {
            // Générateur de nombre aléatoires
            var random = new Random();
           
            var reussi = false;
            for (var essai = 0; essai < 1000; essai++)
            {
                var direction = random.Next(4);
                var dx = (direction < 2 ? 1 : 0) * (direction % 2 == 0 ? 1 : -1);
                var dy = (direction < 2 ? 0 : 1) * (direction % 2 == 0 ? 1 : -1);
                var x = random.Next(p.SizeX);
                var y = random.Next(p.SizeY);
                reussi = true;
                for (var i = 0; i < nbCells; i++)
                {
                    var posx = x + dx * i;
                    var posy = y + dy * i;
                    if ( get9Cells(p, posx, posy).Any(c => c != 0))
                    {
                        // La cellule n'est pas compatible avec un bateau
                        reussi = false;
                        break;
                    }
                }
                if (reussi)
                {
                    for (var i = 0; i < nbCells; i++)
                    {
                        var posx = x + dx * i;
                        var posy = y + dy * i;
                        p.setCell(posx, posy, 1);
                    }
                    return true;
                }
           
            }
            return false;
        }
        public override Partie Initialise(int sizeX, int sizeY)
        {
            var partie = new Partie()
            {
                SizeX = sizeX,
                SizeY = sizeY,
                Grid = new byte[sizeX * sizeY],
                Type = "bn",
                NomJeu="Bataille navale"
            };

            for (var i = 0; i < 1; i++) PutBoat(partie, 5);
            for (var i = 0; i < 2; i++) PutBoat(partie, 4);
            for (var i = 0; i < 3; i++) PutBoat(partie, 3);
            for (var i = 0; i < 4; i++) PutBoat(partie, 2);
            return partie;
        }
        public override string Jouer(Partie p, int x, int y)
        {
            if (p.getCell(x, y) == 0) p.setCell(x, y, 2);
            if (p.getCell(x, y) == 1) p.setCell(x, y, 3);
            var reste = p.Grid.Where(c => c == 1).Count();

            return reste==0 ? "Gagné" : "Reste : "+reste;
        }

    }
}
