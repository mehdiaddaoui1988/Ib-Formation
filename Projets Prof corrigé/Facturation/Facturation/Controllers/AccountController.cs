using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Facturation.Models;
using JWT.Algorithms;
using JWT.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Facturation.Controllers
{
    public class AccountController : Controller
    {
        private FacturationContext context;

        public AccountController(FacturationContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Connection()
        {
            return View();
        }
  

        [HttpGet]
        public IActionResult Deconnection()
        {
            ControllerContext.HttpContext.Response.Cookies.Delete("security_token");
            return RedirectToAction("Index","Clients");
        }
        [HttpGet]
        public IActionResult Connect( string login, string password)
        {
           // recherche du client avec le mot de passe hashé
            var sha1 = SHA256.Create();
            var inputBytes = Encoding.ASCII.GetBytes(password);
            var hash = sha1.ComputeHash(inputBytes);
            var client = context.Clients.First();
            client.Mail = login;
            client.MotDePasse = hash;
            context.SaveChanges();

            client = context.Clients.FirstOrDefault(c=>c.Mail==login && c.MotDePasse==hash);
            if (client != null)
            {
                // Création du token d'authentification
                // Chiffré avec la clé
                var token = new JwtBuilder()
                      .WithAlgorithm(new HMACSHA256Algorithm())
                      .WithSecret("123456")
                      .AddClaim("mail", client.Mail)
                      .AddClaim("raisonSociale", client.RaisonSociale)
                      .AddClaim("idClient", client.Id.ToString())
                      .Build();
                ControllerContext.HttpContext.Response.Cookies.Append("security_token", token,new CookieOptions() { MaxAge=TimeSpan.FromSeconds(3600) });
                return RedirectToAction("Details", "Clients", new { id = client.Id });
            }
            else
            { 
                return View(); 
            }
        }
    }
}