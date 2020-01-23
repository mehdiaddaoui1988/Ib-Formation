using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstApp.Controllers
{
    public class IntroController : Controller
    {
        // GET: Intro
        public ActionResult Index()
        {
            ViewBag.ToutDeSuite = DateTime.Now;
            return View();
        }
        public ActionResult Addition(int a, int b)
        {
            ViewBag.a = a;
            ViewBag.b = b;
            ViewBag.resultat = a + b;
            //ViewBag.toto = "Bonjour";
            //ViewBag.tutu = ViewBag.toto + a;

            return View();
        }

        
        public ActionResult Compteur(int valeurCompteur=0)
        {
            ViewBag.avertissement = "<b>Attention ! <script>location.replace('http://www.google.fr');</script></b>";
            ViewBag.valeurCompteur=valeurCompteur;
            return View();
        }
    }
}