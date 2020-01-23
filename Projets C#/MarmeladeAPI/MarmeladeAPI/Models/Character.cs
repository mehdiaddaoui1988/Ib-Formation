using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarmeladeAPI.Models
{
    public class Character : ValuedItem
    {
        public List<Skill> Skills { get; set; }
        public List<Status> Statuses { get; set; }
    }
}
