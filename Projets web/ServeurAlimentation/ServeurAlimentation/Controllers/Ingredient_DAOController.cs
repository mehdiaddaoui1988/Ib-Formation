using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ServeurAlimentation.DAL;

namespace ServeurAlimentation.Controllers
{
    public class Ingredient_DAOController : ApiController
    {
        private RecettesContext db = new RecettesContext();

        // GET: api/Ingredient_DAO
        public IQueryable<Ingredient_DAO> GetIngredients()
        {
            return db.Ingredients;
        }

        // GET: api/Ingredient_DAO/5
        [ResponseType(typeof(Ingredient_DAO))]
        public IHttpActionResult GetIngredient_DAO(Guid id)
        {
            Ingredient_DAO ingredient_DAO = db.Ingredients.Find(id);
            if (ingredient_DAO == null)
            {
                return NotFound();
            }

            return Ok(ingredient_DAO);
        }

        // PUT: api/Ingredient_DAO/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIngredient_DAO(Guid id, Ingredient_DAO ingredient_DAO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ingredient_DAO.Id)
            {
                return BadRequest();
            }

            db.Entry(ingredient_DAO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Ingredient_DAOExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Ingredient_DAO
        [ResponseType(typeof(Ingredient_DAO))]
        public IHttpActionResult PostIngredient_DAO(Ingredient_DAO ingredient_DAO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ingredients.Add(ingredient_DAO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Ingredient_DAOExists(ingredient_DAO.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ingredient_DAO.Id }, ingredient_DAO);
        }

        // DELETE: api/Ingredient_DAO/5
        [ResponseType(typeof(Ingredient_DAO))]
        public IHttpActionResult DeleteIngredient_DAO(Guid id)
        {
            Ingredient_DAO ingredient_DAO = db.Ingredients.Find(id);
            if (ingredient_DAO == null)
            {
                return NotFound();
            }

            db.Ingredients.Remove(ingredient_DAO);
            db.SaveChanges();

            return Ok(ingredient_DAO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Ingredient_DAOExists(Guid id)
        {
            return db.Ingredients.Count(e => e.Id == id) > 0;
        }
    }
}