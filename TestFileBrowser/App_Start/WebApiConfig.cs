using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace TestFileBrowser
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы веб-API

            // Маршруты веб-API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

           config.Routes.MapHttpRoute(
        name: "ApiActions",
        routeTemplate: "api/{controller}/{action}/{id}",
        defaults: new { action = RouteParameter.Optional, id = RouteParameter.Optional }
    );
            config.Formatters.JsonFormatter.MediaTypeMappings.Add(new UriPathExtensionMapping("json", "application/json"));
            config.Formatters.XmlFormatter.MediaTypeMappings.Add(new UriPathExtensionMapping("xml", "application/xml"));

            config.Formatters.JsonFormatter.AddQueryStringMapping("responseContentType","json","application/json");
            config.Formatters.XmlFormatter.AddQueryStringMapping("responseContentType", "xml", "application/xml");
        }
    }
}
