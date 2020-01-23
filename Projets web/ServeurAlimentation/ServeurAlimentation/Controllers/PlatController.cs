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
            // J'obtiens les données de la base de données
            // Ce sont des DAO
            // Ils contiennent généralement trop d'informations
            var resultats = db.Plats.ToList();

            return resultats.Select(dao => new Plat_DTO()
            {
                i = dao.Id,
                n = dao.Nom,
                d = dao.Description,

            });
        }




        [HttpPost]
        public Guid InsertPlat(Plat_DTO dto)
        {
            var dao = new Plat_DAO()
            {
                Id = dto.i,
                Nom = dto.n,
                Description = dto.d

            };
            db.Plats.Add(dao);
            db.SaveChanges();
            return dao.Id;
        }


        [HttpDelete]
        public void DeletePlat(Guid id)
        {
            var platASupprimer = db.Plats.Find(id);
            db.Plats.Remove(platASupprimer);
            db.SaveChanges();
           
        }



    }
}
