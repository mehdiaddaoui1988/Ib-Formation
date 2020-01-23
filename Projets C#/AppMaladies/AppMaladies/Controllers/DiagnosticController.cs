using AppMaladies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppMaladies.Controllers
{
    public class DiagnosticController : Controller
    {
        DoctorContext db = new DoctorContext();


        // GET: Diagnostic
        public ActionResult Index()
        {
            var faits = db.Faits.ToList();


            return View(faits);
        }
    }
}