using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Facturation.Models;
using Microsoft.AspNetCore.Mvc;

namespace Facturation.Controllers
{
    public class StatsController : Controller
    {
        private readonly FacturationContext _context;

        public StatsController(FacturationContext context)
        {
            _context = context;
        }

        public IActionResult Operations(int? annee, Guid? idClient)
        {
            var operations = _context.GetOperations();
            if (annee != null) operations = operations.Where(c => c.Date.Year == annee);
            if (idClient != null) operations = operations.Where(c => c.IdClient == idClient);

            return View(operations.OrderByDescending(c=>c.Date));
        }
    }
}