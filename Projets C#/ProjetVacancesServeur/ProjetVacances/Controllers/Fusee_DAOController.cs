using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using ProjetVacances.DAL;

namespace ProjetVacances.Controllers
{
    public class Fusee_DAOController : ODataController
    {
        private LancementsContext db = new LancementsContext();

        // GET: odata/Fusee_DAO
        [EnableQuery]
        public IQueryable<Fusee_DAO> GetFusee_DAO()
        {
            return db.Fusees;
        }

        // GET: odata/Fusee_DAO(5)
        [EnableQuery]
        public SingleResult<Fusee_DAO> GetFusee_DAO([FromODataUri] Guid key)
        {
            return SingleResult.Create(db.Fusees.Where(fusee_DAO => fusee_DAO.Id == key));
        }

        // PUT: odata/Fusee_DAO(5)
        public IHttpActionResult Put([FromODataUri] Guid key, Delta<Fusee_DAO> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Fusee_DAO fusee_DAO = db.Fusees.Find(key);
            if (fusee_DAO == null)
            {
                return NotFound();
            }

            patch.Put(fusee_DAO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Fusee_DAOExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(fusee_DAO);
        }

        // POST: odata/Fusee_DAO
        public IHttpActionResult Post(Fusee_DAO fusee_DAO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Fusees.Add(fusee_DAO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Fusee_DAOExists(fusee_DAO.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(fusee_DAO);
        }

        // PATCH: odata/Fusee_DAO(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] Guid key, Delta<Fusee_DAO> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Fusee_DAO fusee_DAO = db.Fusees.Find(key);
            if (fusee_DAO == null)
            {
                return NotFound();
            }

            patch.Patch(fusee_DAO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Fusee_DAOExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(fusee_DAO);
        }

        // DELETE: odata/Fusee_DAO(5)
        public IHttpActionResult Delete([FromODataUri] Guid key)
        {
            Fusee_DAO fusee_DAO = db.Fusees.Find(key);
            if (fusee_DAO == null)
            {
                return NotFound();
            }

            db.Fusees.Remove(fusee_DAO);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Fusee_DAO(5)/Lancements
        [EnableQuery]
        public IQueryable<Lancement_DAO> GetLancements([FromODataUri] Guid key)
        {
            return db.Fusees.Where(m => m.Id == key).SelectMany(m => m.Lancements);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Fusee_DAOExists(Guid key)
        {
            return db.Fusees.Count(e => e.Id == key) > 0;
        }
    }
}
