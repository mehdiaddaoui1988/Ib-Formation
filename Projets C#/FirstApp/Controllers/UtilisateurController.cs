using FirstApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FirstApp.Controllers
{
    public class UtilisateurController : Controller
    {
        StatistiquesContext db = new StatistiquesContext();
        // GET: Question
        public ActionResult Index(int page=1)
        {
            var utilisateurs = db.Utilisateurs.ToList().Skip((page-1)*10).Take(10);
            ViewBag.Pages = db.Utilisateurs.Count() / 10 + 1;
            return View(utilisateurs);
        }

        public ActionResult Details(Guid id)
        {
            var utilisateur = db.Utilisateurs.Find(id);
            return View(utilisateur);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var utilisateur = new Utilisateur();
           // utilisateur.Nom = "---";
            return View(utilisateur);
        }
        [HttpPost]
        public ActionResult Create(Utilisateur u, string Pass)
        {
        
            if (!ModelState.IsValid)
            {
                
                ViewBag.Error = "Il y a quelque chose qui ne va pas";
                return View(u);
            }
            // je récupère le contenu du input name="Pass" du formulaire
            // J'utilise la fonction de hashage sur le mot de passe
            u.Password = SHA256.Create().ComputeHash(Encoding.Unicode.GetBytes(Pass));

            // Sauvegarde de l'utilisateur dans ma BDD
            db.Utilisateurs.Add(u);
            db.SaveChanges();
            // redirection de l'utilisateur vers l'action Index
            return RedirectToAction("Index");
        }
    }
}