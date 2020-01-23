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
    public class IngredientOldController : ApiController
    {
        RecettesContext db = new RecettesContext();
        public IEnumerable<Ingredient_DTO> GetIngredients()
        {
            return db.Ingredients.ToArray().Select(dao => new Ingredient_DTO()
            {
                i = dao.Id,
                n = dao.Nom,
                cg = dao.ContientGluten,
                eb = dao.EstBio
            });
        }
    }
}
