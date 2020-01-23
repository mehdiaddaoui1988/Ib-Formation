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
    public class IngredientController : ApiController
    {
        RecettesContext db = new RecettesContext();

        public IEnumerable<Ingredient_DTO> GetIngredients()
        {
            var resultats = db.Ingredients.ToList();
            return resultats.Select(dao => new Ingredient_DTO
            {
                i = dao.Id,
                n = dao.Nom,
                b = dao.EstBio,
                g = dao.ContientGluten
            });
        }
    }
}
