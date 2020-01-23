using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppMaladies.Models;

namespace AppMaladies.Controllers
{
    public class RisquesController : Controller
    {
        private DoctorContext db = new DoctorContext();

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
            ViewBag.IdFait = new SelectList(db.Faits, "Id", "Intitule");
            ViewBag.IdMaladie = new SelectList(db.Maladies, "Id", "Intitule");
            return View();
        }

        // POST: Risques/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMaladie,IdFait,Probabilite")] Risque risque)
        {
            if (ModelState.IsValid)
            {
                risque.IdMaladie = Guid.NewGuid();
                db.Risques.Add(risque);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdFait = new SelectList(db.Faits, "Id", "Intitule", risque.IdFait);
            ViewBag.IdMaladie = new SelectList(db.Maladies, "Id", "Intitule", risque.IdMaladie);
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
            ViewBag.IdFait = new SelectList(db.Faits, "Id", "Intitule", risque.IdFait);
            ViewBag.IdMaladie = new SelectList(db.Maladies, "Id", "Intitule", risque.IdMaladie);
            return View(risque);
        }

        // POST: Risques/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMaladie,IdFait,Probabilite")] Risque risque)
        {
            if (ModelState.IsValid)
            {
                db.Entry(risque).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdFait = new SelectList(db.Faits, "Id", "Intitule", risque.IdFait);
            ViewBag.IdMaladie = new SelectList(db.Maladies, "Id", "Intitule", risque.IdMaladie);
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
