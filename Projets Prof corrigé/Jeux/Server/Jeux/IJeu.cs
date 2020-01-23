using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Jeux
{
    public interface IJeu
    {
       
        Partie Initialise(int sizeX, int sizeY);
        string Jouer(Partie p, int x, int y);
        string JouerDroit(Partie p, int x, int y);
    }
}
