using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace TimetableServer
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
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

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}
