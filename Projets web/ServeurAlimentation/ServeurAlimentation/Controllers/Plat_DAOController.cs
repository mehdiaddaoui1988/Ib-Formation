using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using ServeurAlimentation.DAL;

namespace ServeurAlimentation.Controllers
{
    /*
    La classe WebApiConfig peut exiger d'autres modifications pour ajouter un itinéraire à ce contrôleur. Fusionnez ces instructions dans la méthode Register de la classe WebApiConfig, le cas échéant. Les URL OData sont sensibles à la casse.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using ServeurAlimentation.DAL;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Plat_DAO>("Plat_DAO");
    builder.EntitySet<Composition_DAO>("Compositions"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class Plat_DAOController : ODataController
    {
        private RecettesContext db = new RecettesContext();

        // GET: odata/Plat_DAO
        [EnableQuery]
        public IQueryable<Plat_DAO> GetPlat_DAO()
        {
            return db.Plats;
        }

        // GET: odata/Plat_DAO(5)
        [EnableQuery]
        public SingleResult<Plat_DAO> GetPlat_DAO([FromODataUri] Guid key)
        {
            return SingleResult.Create(db.Plats.Where(plat_DAO => plat_DAO.Id == key));
        }

        // PUT: odata/Plat_DAO(5)
        public IHttpActionResult Put([FromODataUri] Guid key, Delta<Plat_DAO> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Plat_DAO plat_DAO = db.Plats.Find(key);
            if (plat_DAO == null)
            {
                return NotFound();
            }

            patch.Put(plat_DAO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Plat_DAOExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(plat_DAO);
        }

        // POST: odata/Plat_DAO
        public IHttpActionResult Post(Plat_DAO plat_DAO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Plats.Add(plat_DAO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Plat_DAOExists(plat_DAO.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(plat_DAO);
        }

        // PATCH: odata/Plat_DAO(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] Guid key, Delta<Plat_DAO> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Plat_DAO plat_DAO = db.Plats.Find(key);
            if (plat_DAO == null)
            {
                return NotFound();
            }

            patch.Patch(plat_DAO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Plat_DAOExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(plat_DAO);
        }

        // DELETE: odata/Plat_DAO(5)
        public IHttpActionResult Delete([FromODataUri] Guid key)
        {
            Plat_DAO plat_DAO = db.Plats.Find(key);
            if (plat_DAO == null)
            {
                return NotFound();
            }

            db.Plats.Remove(plat_DAO);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Plat_DAO(5)/Compositions
        [EnableQuery]
        public IQueryable<Composition_DAO> GetCompositions([FromODataUri] Guid key)
        {
            return db.Plats.Where(m => m.Id == key).SelectMany(m => m.Compositions);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Plat_DAOExists(Guid key)
        {
            return db.Plats.Count(e => e.Id == key) > 0;
        }
    }
}
