using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using ServeurAlimentation.DAL;
namespace ServeurAlimentation
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Plat_DAO>("Plat_DAO");
            builder.EntitySet<Composition_DAO>("Compositions");
            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());

            // Configuration et services API Web

            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "recettes/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional, action="Get", controller="Plat" }
            );
        }
    }
}
