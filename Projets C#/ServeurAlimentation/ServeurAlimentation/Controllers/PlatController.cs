using ServeurAlimentation.DAL;
using ServeurAlimentation.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServeurAlimentation.Controllers
{
    
    public class PlatController : ApiController
    {

        RecettesContext db = new RecettesContext();

        [HttpGet]
        public IEnumerable<Plat_DTO> GetPlats()
        {
            var resultats = db.Plats.ToList();
            return resultats.Select(dao => new Plat_DTO
            {
                i = dao.Id,
                n = dao.Nom,
                d = dao.Description,
                p = dao.Prix
            }) ;
        }
        [HttpPost]
        public void InsertPlat(Plat_DTO dto)
        {
            var dao = new Plat_DAO()
            {
                Id = dto.i,
                Nom = dto.n,
                Description = dto.d,
                Prix = dto.p
            };
            db.Plats.Add(dao);
            db.SaveChanges();
        }

        [HttpDelete]
        public void DeletePlat(Guid id)
        {
            var PlatASupprimer = db.Plats.Find(id);
            db.Plats.Remove(PlatASupprimer);
            db.SaveChanges();
        }
    }
}
