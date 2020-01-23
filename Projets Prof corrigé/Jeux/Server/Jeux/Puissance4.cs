using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Jeux
{
    public class Puissance4 : JeuBase
    {
        public override Partie Initialise(int sizeX, int sizeY)
        {
            var partie = new Partie()
            {
                SizeX = sizeX,
                SizeY = sizeY,
                Grid = new byte[sizeX * sizeY]
            };

         
            var r = new Random();
            partie.setCell(r.Next(sizeX), r.Next(sizeY), -1);
            return partie;
        }

        private void Play(Partie p,int x,int  v)
        {
            for (var y1 = p.SizeY - 1; y1 >= 0; y1--)
            {
                var val = p.getCell(x, y1);
                if (val == 0)
                {
                    p.setCell(x, y1, v);
                    break;
                }

            }
        }
        public override string Jouer(Partie p, int x, int y)
        {
            Play(p, x, 1);
            Play(p,new Random().Next(p.SizeX),2);

            return "Ok";
        }
    }
}
