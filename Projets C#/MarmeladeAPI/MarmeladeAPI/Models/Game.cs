using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarmeladeAPI.Models
{
    public class Game
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Score { get; set; }
        public double Bonus { get; set; }
        public double HighestBonus { get; set; }
        public int Level { get; set; }
        public int Coins { get; set; }
        public List<Weapon> Weapons { get; set; }
        public List<Warrior> TeamComp { get; set; }
    }
}
