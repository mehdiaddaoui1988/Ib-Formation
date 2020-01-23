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
    public class FaitsController : Controller
    {
        private DocContext db = new DocContext();

        // GET: Faits
        public ActionResult Index()
        {
            return View(db.Faits.ToList());
        }

        // GET: Faits/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fait fait = db.Faits.Find(id);
            if (fait == null)
            {
                return HttpNotFound();
            }
            return View(fait);
        }

        // GET: Faits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Faits/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Decsription")] Fait fait)
        {
            if (ModelState.IsValid)
            {
                fait.Id = Guid.NewGuid();
                db.Faits.Add(fait);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fait);
        }

        // GET: Faits/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fait fait = db.Faits.Find(id);
            if (fait == null)
            {
                return HttpNotFound();
            }
            return View(fait);
        }

        // POST: Faits/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Decsription")] Fait fait)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fait).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fait);
        }

        // GET: Faits/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fait fait = db.Faits.Find(id);
            if (fait == null)
            {
                return HttpNotFound();
            }
            return View(fait);
        }

        // POST: Faits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Fait fait = db.Faits.Find(id);
            db.Faits.Remove(fait);
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
