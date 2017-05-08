using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace TimetableServer
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Enable CORS for front-end
            var corsData = new EnableCorsAttribute("157.158.16.186:3000,localhost:8080", "*", "*");
            config.EnableCors(corsData);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Schedules",
                routeTemplate: "{controller}/{id}/{typeOfSchedule}",
                defaults: new {id = "", typeOfSchedule = ""});
            config.Routes.MapHttpRoute(
                name: "TimeSuggestion",
                routeTemplate: "{controller}/{id}",
                defaults: new { });
            config.Routes.MapHttpRoute(
                name: "GroupsList",
                routeTemplate: "{controller}",
                defaults: new {}
            );

            //config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
        }
    }
}
