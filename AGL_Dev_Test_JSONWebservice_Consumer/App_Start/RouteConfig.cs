using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AGL.DevTest.JSONWebserviceConsumer
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Update default route to point to people controller GetPetsByOwnerGenderAsc
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "People", action = "GetPetsByOwnerGenderAsc", id = UrlParameter.Optional }
            );
        }
    }
}
