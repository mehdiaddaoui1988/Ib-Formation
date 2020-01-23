using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Facturation.Models;

namespace Facturation.Controllers
{
    public class FacturesController : Controller
    {
        private readonly FacturationContext _context;

        public FacturesController(FacturationContext context)
        {
            _context = context;
        }

        // GET: Factures
        public async Task<IActionResult> Index()
        {
            var facturationContext = _context.Factures.Include(f => f.Client);
            return View(await facturationContext.ToListAsync());
        }
        public async Task<IActionResult> Valider(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facture = await _context.Factures.FindAsync(id);
            if (facture == null)
            {
                return NotFound();
            }
            if (facture.CanValidate)
            {
                facture.DateEdition = DateTime.Now;
                var annee = DateTime.Now.Year;
                var lastFacture = _context.Factures.Where(c => c.Numero.StartsWith(annee.ToString())).OrderBy(c => c.Numero).LastOrDefault();
                var nextNumero = annee.ToString() + "-0001";
                if (lastFacture != null)
                {
                    nextNumero = annee + "-" + (int.Parse(lastFacture.Numero.Substring(5, 4))+1).ToString("0000");
                }

                facture.Numero = nextNumero;
                _context.SaveChanges();
            }
            return RedirectToAction("Details", new { id = facture.Id });
        }


        // GET: Factures/Details/5
            public async Task<IActionResult> Details(Guid? id, Guid? selectedPrestation = null)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facture = await _context.Factures
                .Include(f => f.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facture == null)
            {
                return NotFound();
            }
            if (selectedPrestation != null)
            {
                ViewBag.SelectedPrestation = facture.Prestations.FirstOrDefault(c=>c.Id==selectedPrestation);
            }
            

            return View(facture);
        }

        // GET: Factures/Create
        public IActionResult Create(Guid idClient)
        {
            var client = _context.Clients.Find(idClient);
            var facture = new Facture() { IdClient = idClient,
            Client=client};
         
            return View(facture);
        }

        // POST: Factures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Reference,DateCreation,DateEdition,DateEcheance,Numero,Remarque,IdClient")] Facture facture)
        {
            if (ModelState.IsValid)
            {
           
                _context.Add(facture);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create","Prestations",new { idFacture = facture.Id});
            }
            facture.Client = _context.Clients.Find(facture.IdClient);
            return View(facture);
        }

        // GET: Factures/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facture = await _context.Factures.FindAsync(id);
            if (facture == null)
            {
                return NotFound();
            }
            return View(facture);
        }

        // POST: Factures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Reference,DateCreation,DateEdition,DateEcheance,Numero,Remarque,IdClient")] Facture facture)
        {
            if (id != facture.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FactureExists(facture.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            facture.Client = _context.Clients.Find(facture.IdClient);
            return View(facture);
        }

        // GET: Factures/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facture = await _context.Factures
                .Include(f => f.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facture == null)
            {
                return NotFound();
            }

            return View(facture);
        }

        // POST: Factures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var facture = await _context.Factures.FindAsync(id);
            _context.Factures.Remove(facture);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FactureExists(Guid id)
        {
            return _context.Factures.Any(e => e.Id == id);
        }
    }
}
