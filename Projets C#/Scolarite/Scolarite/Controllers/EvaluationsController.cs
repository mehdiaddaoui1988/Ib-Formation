using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scolarite.Models;

namespace Scolarite.Controllers
{
    public class EvaluationsController : Controller
    {
        EcoleContext _context = null;
        public EvaluationsController(EcoleContext context)
        {
            this._context = context;
        }
        [HttpGet]



        [HttpPost]
        public IActionResult CreateOrUpdate(Evaluation evaluation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }



            //var evaluationDansBDD = _context.Evaluations.FirstOrDefault(e => 
            //                                             e.IdEleve == evaluation.IdEleve 
            //                                           && e.IdMatiere == evaluation.IdMatiere 
            //                                         && e.Date == evaluation.Date);
            //if (evaluationDansBDD != null)
            //{
            //    evaluationDansBDD.Note = evaluation.Note;
            //    evaluationDansBDD.Appreciation = evaluation.Appreciation;
            //    _context.SaveChanges();
            //}


            if (_context.Evaluations.Any(e => e.IdEleve == evaluation.IdEleve && e.IdMatiere == evaluation.IdMatiere && e.Date == evaluation.Date)) {
                // Il existe dèja une évaluation pour ce jour, cet élève, et cette matière
                _context.Update(evaluation);
                _context.SaveChanges();
            } else
            {
                //_context.Add(evaluation);
                // <=>
                _context.Entry(evaluation).State = EntityState.Added;
                _context.SaveChanges();

            }
            return RedirectToAction("Notes", "Matieres",new { id=evaluation.IdMatiere,date=evaluation.Date});
        }
    }
}