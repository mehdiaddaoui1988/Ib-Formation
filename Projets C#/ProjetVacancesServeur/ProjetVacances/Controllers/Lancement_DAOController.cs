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

    public class Lancement_DAOController : ODataController
    {
        private LancementsContext db = new LancementsContext();

        // GET: odata/Lancement_DAO
        [EnableQuery]
        public IQueryable<Lancement_DAO> GetLancement_DAO()
        {
            return db.Lancements;
        }

        // GET: odata/Lancement_DAO(5)
        [EnableQuery]
        public SingleResult<Lancement_DAO> GetLancement_DAO([FromODataUri] Guid key)
        {
            return SingleResult.Create(db.Lancements.Where(lancement_DAO => lancement_DAO.Id == key));
        }

        // PUT: odata/Lancement_DAO(5)
        public IHttpActionResult Put([FromODataUri] Guid key, Delta<Lancement_DAO> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Lancement_DAO lancement_DAO = db.Lancements.Find(key);
            if (lancement_DAO == null)
            {
                return NotFound();
            }

            patch.Put(lancement_DAO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Lancement_DAOExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(lancement_DAO);
        }

        // POST: odata/Lancement_DAO
        public IHttpActionResult Post(Lancement_DAO lancement_DAO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lancements.Add(lancement_DAO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Lancement_DAOExists(lancement_DAO.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(lancement_DAO);
        }

        // PATCH: odata/Lancement_DAO(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] Guid key, Delta<Lancement_DAO> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Lancement_DAO lancement_DAO = db.Lancements.Find(key);
            if (lancement_DAO == null)
            {
                return NotFound();
            }

            patch.Patch(lancement_DAO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Lancement_DAOExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(lancement_DAO);
        }

        // DELETE: odata/Lancement_DAO(5)
        public IHttpActionResult Delete([FromODataUri] Guid key)
        {
            Lancement_DAO lancement_DAO = db.Lancements.Find(key);
            if (lancement_DAO == null)
            {
                return NotFound();
            }

            db.Lancements.Remove(lancement_DAO);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Lancement_DAO(5)/Fusee
        [EnableQuery]
        public SingleResult<Fusee_DAO> GetFusee([FromODataUri] Guid key)
        {
            return SingleResult.Create(db.Lancements.Where(m => m.Id == key).Select(m => m.Fusee));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Lancement_DAOExists(Guid key)
        {
            return db.Lancements.Count(e => e.Id == key) > 0;
        }
    }
}
