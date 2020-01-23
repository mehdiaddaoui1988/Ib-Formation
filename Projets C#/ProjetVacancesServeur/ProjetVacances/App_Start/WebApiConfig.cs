using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using ProjetVacances.DAL;

namespace ProjetVacances
{
    public static class WebApiConfig
    {


        public static void Register(HttpConfiguration config)
        {
            // Configuration et services API Web
            
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            config.EnableCors();
            builder.EntitySet<Lancement_DAO>("Lancement_DAO");
            builder.EntitySet<Fusee_DAO>("Fusee_DAO");
            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "spatioport/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
                
            );
        }
    }
}
