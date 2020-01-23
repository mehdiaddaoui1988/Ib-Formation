using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Partie
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public byte[] Grid { get; set; }
        public string NomJeu { get; set; }
        public string Type { get; set; }
        public  void setCell(int x, int y,byte v)
        {
            if (x < 0 || x >= SizeX) return ;
            if (y < 0 || y >= SizeY) return ;
            Grid[y * SizeX + x] = (byte)v;
        }
        public  byte? getCell(int x,int y)
        {
            if (x < 0 || x >= SizeX) return null;
            if (y < 0 || y >= SizeY) return null;
                var index = y * SizeX + x;
            return Grid[index];
        }
    }
}
