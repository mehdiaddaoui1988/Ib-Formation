using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjetVacances.DAL;
using ProjetVacances.DTO;

namespace ProjetVacances.Controllers
{
    public class EmptyFuseeController : ApiController
    {
        LancementsContext db = new LancementsContext();
        public IEnumerable<Fusee_DTO> GetFusees()
        {
            var resultats = db.Fusees.ToList();

            return resultats.Select(dao => new Fusee_DTO()
            {
                i = dao.Id,
                e = dao.Entreprise,
                m = dao.Modele,
                nv = dao.NombreDeVols
            });
        }
    }
}
