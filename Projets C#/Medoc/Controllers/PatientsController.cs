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
    public class PatientsController : Controller
    {
        private DocContext db = new DocContext();

        // GET: Patients
        public ActionResult Index()
        {
            return View(db.Patients.ToList());
        }


        public ActionResult SwitchFait(Guid id,Guid idFait)
        {
            var patient = db.Patients.Find(id);
           var fait = db.Faits.Find(idFait);
       
            if (!patient.Faits.Contains(fait))
            { 
                patient.Faits.Add(fait);
            }
            else
            {
                patient.Faits.Remove(fait);
            }
            db.SaveChanges();
            return RedirectToAction("Details",new {id=id });
        }

        // GET: Patients/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            ViewBag.Faits = db.Faits.ToList();
 
            var diagnostics = db.Maladies.Select(c => new Diagnostic { IdMaladie=c.Id, Nom=c.Nom, Probabilite=50D }).ToList();
      
            foreach(var f in patient.Faits)
            {
                foreach(var r in f.Risques)
                {
                    var m = diagnostics.First(d => d.IdMaladie == r.IdMaladie);
                    m.Probabilite = (1 - (1 - ((Double)m.Probabilite)/100) * (1 - ((Double)r.Probabilite) / 100))*100;
                }
            }
            ViewBag.diagnostics = diagnostics.Where(c=>c.Probabilite>50); ;
           
            return View(patient);
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,Prenom")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                patient.Id = Guid.NewGuid();
                db.Patients.Add(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(patient);
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,Prenom")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        // GET: Patients/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
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
    public class Diagnostic
    {
        public Guid IdMaladie { get; set; }
        public string Nom { get; set; }
        public double Probabilite { get; set; }
    }
}
