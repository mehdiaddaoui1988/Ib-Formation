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
    public class MaladiesController : Controller
    {
        private DocContext db = new DocContext();

        // GET: Maladies
        public ActionResult Index()
        {
            return View(db.Maladies.ToList());
        }

        // GET: Maladies/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maladie maladie = db.Maladies.Find(id);
            if (maladie == null)
            {
                return HttpNotFound();
            }
            return View(maladie);
        }

        // GET: Maladies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Maladies/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,Prescription")] Maladie maladie)
        {
            if (ModelState.IsValid)
            {
                maladie.Id = Guid.NewGuid();
                db.Maladies.Add(maladie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(maladie);
        }

        // GET: Maladies/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maladie maladie = db.Maladies.Find(id);
            if (maladie == null)
            {
                return HttpNotFound();
            }
            return View(maladie);
        }

        // POST: Maladies/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,Prescription")] Maladie maladie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maladie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(maladie);
        }

        // GET: Maladies/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maladie maladie = db.Maladies.Find(id);
            if (maladie == null)
            {
                return HttpNotFound();
            }
            return View(maladie);
        }

        // POST: Maladies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Maladie maladie = db.Maladies.Find(id);
            db.Maladies.Remove(maladie);
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
