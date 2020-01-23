
using FirstApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstApp.Controllers
{
    public class QuestionController : Controller
    {
        StatistiquesContext db = new StatistiquesContext();
        // GET: Question
        public ActionResult Index()
        {
            var questions = db.Questions.ToList();
            
            return View(questions);
        }

        public ActionResult Details(Guid id)
        {
            var question = db.Questions.Find(id);
            ViewBag.NombreReponsesVraies = question.Reponses.Where(c => c.Valeur).Count();
            ViewBag.NombreReponsesFausses = question.Reponses.Where(c => !c.Valeur).Count();

            return View(question);
        }
    }


}