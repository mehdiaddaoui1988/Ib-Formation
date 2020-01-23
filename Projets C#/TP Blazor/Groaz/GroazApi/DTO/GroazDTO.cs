using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroazApi.DTO
{
    public class GroazDTO
    {

        public Guid i { get; set; }
        public string t { get; set; }
        public int nb { get; set; }

        public DateTime dn { get; set; }
        public Guid? ip { get; set; }

    }
}
