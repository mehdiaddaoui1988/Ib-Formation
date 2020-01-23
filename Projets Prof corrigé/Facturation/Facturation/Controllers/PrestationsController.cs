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
    public class PrestationsController : Controller
    {
        private readonly FacturationContext _context;

        public PrestationsController(FacturationContext context)
        {
            _context = context;
        }






        // GET: Prestations/Create
        public IActionResult Create(Guid idFacture)
        {
            var facture = _context.Factures.Find(idFacture);
            ViewBag.Title = $"Prestation sur Facture {facture.Numero} pour {facture.Client.RaisonSociale}";
            var prestation = new Prestation() { 
                IdFacture = idFacture 
            };

              return View(prestation);
        }

        // POST: Prestations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,MontantHT,TauxTVA,Remarque,IdFacture")] Prestation prestation)
        {
            var facture = _context.Factures.Find(prestation.IdFacture);
            ViewBag.Title = $"Prestation sur Facture {facture.Numero} pour {facture.Client.RaisonSociale}";

            if (ModelState.IsValid)
            {
                prestation.Id = Guid.NewGuid();
                _context.Add(prestation);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Factures", new { id=prestation.IdFacture});
            }
            return View(prestation);
        }

        // GET: Prestations/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestation = await _context.Prestations.FindAsync(id);
            if (prestation == null)
            {
                return NotFound();
            }
            var facture = _context.Factures.Find(prestation.IdFacture);
            ViewBag.Title = $"Prestation sur Facture {facture.Numero} pour {facture.Client.RaisonSociale}";
            return View(prestation);
        }

        // POST: Prestations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Description,MontantHT,TauxTVA,Remarque,IdFacture")] Prestation prestation)
        {
            if (id != prestation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prestation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrestationExists(prestation.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details","Factures",new {id=prestation.IdFacture });
            }
            var facture = _context.Factures.Find(prestation.IdFacture);
            ViewBag.Title = $"Prestation sur Facture {facture.Numero} pour {facture.Client.RaisonSociale}";
            return View(prestation);
        }



        // POST: Prestations/Delete/5
        [HttpGet, ActionName("Delete")]

        public async Task<IActionResult> Delete(Guid id)
        {
            var prestation = await _context.Prestations.FindAsync(id);
            _context.Prestations.Remove(prestation);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details","Factures",new { id = prestation.IdFacture });
        }

        private bool PrestationExists(Guid id)
        {
            return _context.Prestations.Any(e => e.Id == id);
        }
    }
}
