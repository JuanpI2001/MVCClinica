using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCClinica
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Especialidad",
                url: "{controller}/traerespecialidad/{especialidad}",
                defaults: new
                {
                    controller = "Medico",
                    action = "BuscarEspecialidad"
                });
            //routes.MapRoute(
            //    name: "NombreApellido",
            //    url: "{controller}/traerMedico/{nombre}/{apellido}",
            //    defaults: new
            //    {
            //        controller = "Medico",
            //        action = "BuscarNombreApellido"
            //    });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
