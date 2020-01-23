using MarmeladeAPI.Models.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarmeladeAPI.Models
{
    public class Skill : GameItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Cost { get; set; }
        public int Value { get; set; }
        public Status? StatusEffect { get; set; }
        public ETarget TargetGroup { get; set; }
    }
}
