using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GroazApi.Models;
using GroazApi.DTO;

namespace GroazApi.Controllers
{
    [Route("groaz")]
    [ApiController]
    public class GroazSetController : ControllerBase
    {
        private readonly GroazContext _context;

        public GroazSetController(GroazContext context)
        {
            _context = context;
        }

        // GET: api/GroazSet
        [HttpGet]
        public  IEnumerable<GroazItemDTO> GetGroazSet()
        {
            // Pour la liste des Groaz, l'Id et le Trut suffisent
            return _context.GroazSet
                            .AsEnumerable()
                            .Select(g=>new GroazItemDTO(){ i=g.Id, t=g.Trut });
        }

        // GET: groaz/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroazDTO>> GetGroaz(Guid id)
        {
            var groaz = await _context.GroazSet.FindAsync(id);

            if (groaz == null)
            {
                return NotFound();
            }

            return new GroazDTO { i=groaz.Id, 
                                dn=groaz.DateNaissance,
                                    ip=groaz.IdParain,
                                        nb=groaz.NiveauDeBins, t=groaz.Trut};
        }

        // PUT: api/GroazSet/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroaz(Guid id, Groaz groaz)
        {
            if (id != groaz.Id)
            {
                return BadRequest();
            }

            _context.Entry(groaz).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroazExists(id))
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

        // POST: api/GroazSet
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Groaz>> PostGroaz(Groaz groaz)
        {
            _context.GroazSet.Add(groaz);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroaz", new { id = groaz.Id }, groaz);
        }

        // DELETE: api/GroazSet/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Groaz>> DeleteGroaz(Guid id)
        {
            var groaz = await _context.GroazSet.FindAsync(id);
            if (groaz == null)
            {
                return NotFound();
            }

            _context.GroazSet.Remove(groaz);
            await _context.SaveChangesAsync();

            return groaz;
        }

        private bool GroazExists(Guid id)
        {
            return _context.GroazSet.Any(e => e.Id == id);
        }
    }
}
