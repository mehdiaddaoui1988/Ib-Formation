using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazap.DTOs
{
    public class GroazDTO : GroazItemDTO
    {

        public int nb { get; set; }

        public DateTime dn { get; set; }
        public Guid? ip { get; set; }

    }
}
