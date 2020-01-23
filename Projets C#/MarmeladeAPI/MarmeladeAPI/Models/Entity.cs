using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarmeladeAPI.Models
{
    public abstract class Entity : GameItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int HP { get; set; }
        public int Resistance { get; set; }
        public int Energy { get; set; }
        public int Damage { get; set; }
        public int Agility { get; set; }
        public float CritLuck { get; set; }
        public int Value { get; set; }
    }
}
