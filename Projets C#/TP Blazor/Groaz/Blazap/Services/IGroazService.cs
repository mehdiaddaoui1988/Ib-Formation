using Blazap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazap.Services
{
    public interface IGroazService
    {
        Task<IEnumerable<Groaz>> getGroazSet();
        Task<Groaz> getDetails(Guid id);
    }
}
