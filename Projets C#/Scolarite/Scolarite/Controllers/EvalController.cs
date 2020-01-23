using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scolarite.Models;

namespace Scolarite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvalController : ControllerBase
    {
        private readonly EcoleContext _context;

        public EvalController(EcoleContext context)
        {
            _context = context;
        }

        // GET: api/Eval
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evaluation>>> GetEvaluations()
        {
            return await _context.Evaluations.ToListAsync();
        }

        // GET: api/Eval/5
        [HttpGet("{idMatiere:Guid}/{idEleve:Guid}/{date}")]
        public async Task<ActionResult<Evaluation>> GetEvaluation(Guid idEleve,Guid idMatiere, DateTime date)
        {
            var evaluation = await _context.Evaluations.FindAsync(idEleve,idMatiere,date);

            if (evaluation == null)
            {
                return NotFound();
            }

            return evaluation;
        }

        // PUT: api/Eval/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvaluation(Guid id, Evaluation evaluation)
        {
            if (id != evaluation.IdEleve)
            {
                return BadRequest();
            }

            _context.Entry(evaluation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EvaluationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Eval
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Evaluation>> PostEvaluation(Evaluation evaluation)
        {
            _context.Evaluations.Add(evaluation);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EvaluationExists(evaluation.IdEleve))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEvaluation", new { id = evaluation.IdEleve }, evaluation);
        }

        // DELETE: api/Eval/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Evaluation>> DeleteEvaluation(Guid id)
        {
            var evaluation = await _context.Evaluations.FindAsync(id);
            if (evaluation == null)
            {
                return NotFound();
            }

            _context.Evaluations.Remove(evaluation);
            await _context.SaveChangesAsync();

            return evaluation;
        }

        private bool EvaluationExists(Guid id)
        {
            return _context.Evaluations.Any(e => e.IdEleve == id);
        }
    }
}
