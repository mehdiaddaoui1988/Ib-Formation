using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Medoc.Models;

namespace Medoc.Controllers
{
    public class RisquesController : Controller
    {
        private DocContext db = new DocContext();

        SelectList listeProbabilites(Decimal value)
        {
           
                var r = new List<SelectListItem>();
                for (var i = 0; i <= 100; i++)
                {
                    r.Add(new SelectListItem() { Value = i.ToString(), Text = i.ToString() });
                }
                return new SelectList(r, "Value","Text",value);
          
        }
    // GET: Risques
    public ActionResult Index()
        {
            var risques = db.Risques.Include(r => r.Fait).Include(r => r.Maladie);
            return View(risques.ToList());
        }

        // GET: Risques/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Risque risque = db.Risques.Find(id);
            if (risque == null)
            {
                return HttpNotFound();
            }
            return View(risque);
        }

        // GET: Risques/Create
        public ActionResult Create()
        {
            ViewBag.IdFait = new SelectList(db.Faits, "Id", "Decsription");
            ViewBag.IdMaladie = new SelectList(db.Maladies, "Id", "Nom");
         
            ViewBag.Probabilite = listeProbabilites(0.5M);

            return View();
        }

        // POST: Risques/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdMaladie,IdFait,Probabilite")] Risque risque)
        {
            if (ModelState.IsValid)
            {
                risque.Id = Guid.NewGuid();
                db.Risques.Add(risque);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
      
            ViewBag.Probabilite = listeProbabilites(risque.Probabilite);
            ViewBag.IdFait = new SelectList(db.Faits, "Id", "Decsription", risque.IdFait);
            ViewBag.IdMaladie = new SelectList(db.Maladies, "Id", "Nom", risque.IdMaladie);
            return View(risque);
        }

        // GET: Risques/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Risque risque = db.Risques.Find(id);
            if (risque == null)
            {
                return HttpNotFound();
            }

            ViewBag.Probabilite = listeProbabilites(risque.Probabilite);
            ViewBag.IdFait = new SelectList(db.Faits, "Id", "Decsription", risque.IdFait);
            ViewBag.IdMaladie = new SelectList(db.Maladies, "Id", "Nom", risque.IdMaladie);
            return View(risque);
        }

        // POST: Risques/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdMaladie,IdFait,Probabilite")] Risque risque)
        {
            if (ModelState.IsValid)
            {
                db.Entry(risque).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Probabilite = listeProbabilites(risque.Probabilite);
            ViewBag.IdFait = new SelectList(db.Faits, "Id", "Decsription", risque.IdFait);
            ViewBag.IdMaladie = new SelectList(db.Maladies, "Id", "Nom", risque.IdMaladie);
            return View(risque);
        }

        // GET: Risques/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Risque risque = db.Risques.Find(id);
            if (risque == null)
            {
                return HttpNotFound();
            }
            return View(risque);
        }

        // POST: Risques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Risque risque = db.Risques.Find(id);
            db.Risques.Remove(risque);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
