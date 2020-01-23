using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Jeux;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartiesController : ControllerBase
    {
        private JeuContext _context;
        private IJeu jeu;
        

        public PartiesController(JeuContext context, IJeu jeu)
        {
            this.jeu = jeu;
            this._context = context;
        }


        // Renvoit les parties
        [HttpGet("")]
        public object Get()
        {
            return this._context.Parties.Select(c=>new { id=c.Id,name=c.Name, sizeX=c.SizeX, sizeY=c.SizeY }).ToList();
        }

        [HttpGet("Create/{name}/{sizeX:int}/{sizeY:int}")]
        public object Create(string name,int sizeX,int sizeY)
        {
            var partie = jeu.Initialise(sizeX, sizeY);

            partie.Name = name;
            this._context.Parties.Add(partie);
            this._context.SaveChanges();
            return new { id = partie.Id, 
                        name = partie.Name, 
                        sizeX = partie.SizeX, 
                        sizeY = partie.SizeY, 
                        type=partie.Type,
                        nomJeu=partie.NomJeu,
                        grid = partie.Grid.Select(c => (int)c).ToArray() };
        }
        [HttpGet("GetPartie/{id:Guid}")]
        public object GetPartie(Guid id)
        {
            var c = this._context.Parties.Find(id);
            return new { id = c.Id, name = c.Name, sizeX = c.SizeX, sizeY = c.SizeY,
                type=c.Type,
                            nomJeu = c.NomJeu, grid = c.Grid.Select(c => (int)c).ToArray()};
        }


        [HttpGet("Play/{id:Guid}/{x:int}/{y:int}")]
        public object Play(Guid id, int x, int y )
        {
            var partie = this._context.Parties.Find(id);

            var message= this.jeu.Jouer(partie, x, y);
           
            this._context.Entry(partie).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this._context.SaveChanges();
            return new { message=message, grid = partie.Grid.Select(c => (int)c).ToArray() };
        }
    }
}