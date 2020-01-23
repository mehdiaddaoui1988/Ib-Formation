using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarmeladeAPI.Models
{
    public abstract class GameItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
