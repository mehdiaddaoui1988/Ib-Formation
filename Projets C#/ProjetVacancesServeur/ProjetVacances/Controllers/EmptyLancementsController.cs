using ProjetVacances.DAL;
using ProjetVacances.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjetVacances.Controllers
{
    public class EmptyLancementsController : ApiController
    {
        LancementsContext db = new LancementsContext();

        [HttpGet]
        public string Hello()
        {
            return "Hello world !";
        }
        [HttpGet]
        public IEnumerable<Lancement_DTO> GetLancements()
        {
            var resultats = db.Lancements.ToList();
            return resultats.Select(dao => new Lancement_DTO()
            {
                i = dao.Id,
                c = dao.ChargeUtile,
                pc = dao.PoidsChargeUtile,
                dt = dao.DateLancement.ToShortDateString(),
                d = dao.DescriptionMission,
                e = dao.EtatAtterrissage
            });
        }

        [HttpPost]
        public Guid InsertLancement(Lancement_DTO dto)
        {
            var lancement = new Lancement_DAO
            {
                DescriptionMission = dto.d,
                PoidsChargeUtile = dto.pc,
                ChargeUtile = dto.c,
                DateLancement = DateTime.Parse(dto.dt),
                EtatAtterrissage = dto.e,

            };
            db.Lancements.Add(lancement);
            db.SaveChanges();
            return lancement.Id;
        }
       
    }
}
