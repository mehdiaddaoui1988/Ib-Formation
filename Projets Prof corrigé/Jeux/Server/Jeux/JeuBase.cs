using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Jeux
{
    public abstract class JeuBase : IJeu
    {
        public IEnumerable<int> get9Cells(Partie p, int x, int y)
        {

            for (var i = -1; i <= 1; i++)
                for (var j = -1; j <= 1; j++)
                {
                    var v = p.getCell(x + i, y + j);
                    if (v != null) yield return v.Value;
                }
        }

        public abstract Partie Initialise(int sizeX, int sizeY);
        public abstract string Jouer(Partie p, int x, int y);

        public  string JouerDroit(Partie p, int x, int y)
        {
            return "";
        }
    }
}
