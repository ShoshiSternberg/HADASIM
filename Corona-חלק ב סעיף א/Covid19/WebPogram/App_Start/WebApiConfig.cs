using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebPogram
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // Web API configuration and services

            // Web API routes     
            config.EnableCors();
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}/{name}/{grade}",
                defaults: new { id = RouteParameter.Optional,name=RouteParameter.Optional,grade= RouteParameter.Optional }
            );
        }
    }
}
