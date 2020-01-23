using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FirstApp.Models;

namespace FirstApp.Controllers
{
    public class ReponsesController : Controller
    {
        private StatistiquesContext db = new StatistiquesContext();

        // GET: Reponses
        public ActionResult Index()
        {
            var reponses = db.Reponses.Include(r => r.Question).Include(r => r.Utilisateur);
            return View(reponses.ToList());
        }

        // GET: Reponses/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reponse reponse = db.Reponses.Find(id);
            if (reponse == null)
            {
                return HttpNotFound();
            }
            return View(reponse);
        }

        // GET: Reponses/Create
        public ActionResult Create()
        {
            ViewBag.IdQuestion = new SelectList(db.Questions, "Id", "Text");
            ViewBag.IdUtilisateur = new SelectList(db.Utilisateurs, "Id", "Nom");
            return View();
        }

        // POST: Reponses/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUtilisateur,IdQuestion,Valeur,DateReponse")] Reponse reponse)
        {
            if (ModelState.IsValid)
            {
                reponse.IdUtilisateur = Guid.NewGuid();
                db.Reponses.Add(reponse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdQuestion = new SelectList(db.Questions, "Id", "Text", reponse.IdQuestion);
            ViewBag.IdUtilisateur = new SelectList(db.Utilisateurs, "Id", "Nom", reponse.IdUtilisateur);
            return View(reponse);
        }

        // GET: Reponses/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reponse reponse = db.Reponses.Find(id);
            if (reponse == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdQuestion = new SelectList(db.Questions, "Id", "Text", reponse.IdQuestion);
            ViewBag.IdUtilisateur = new SelectList(db.Utilisateurs, "Id", "Nom", reponse.IdUtilisateur);
            return View(reponse);
        }

        // POST: Reponses/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUtilisateur,IdQuestion,Valeur,DateReponse")] Reponse reponse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reponse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdQuestion = new SelectList(db.Questions, "Id", "Text", reponse.IdQuestion);
            ViewBag.IdUtilisateur = new SelectList(db.Utilisateurs, "Id", "Nom", reponse.IdUtilisateur);
            return View(reponse);
        }

        // GET: Reponses/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reponse reponse = db.Reponses.Find(id);
            if (reponse == null)
            {
                return HttpNotFound();
            }
            return View(reponse);
        }

        // POST: Reponses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Reponse reponse = db.Reponses.Find(id);
            db.Reponses.Remove(reponse);
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
