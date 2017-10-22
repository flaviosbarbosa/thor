using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace elroy.crusade.API
{
    /// <summary>
    /// Configuração geral das WEBApis
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Definição do registro do swagger
        /// </summary>
        /// <param name="config">Informe</param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services (Define para retornar em json)
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            // Habilita o CORS globalmente
            var corsAttr = new EnableCorsAttribute("http://www.elroy.com.br,http://localhost:51737", " * ", "*");
            config.EnableCors(corsAttr);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //SwaggerConfig.Register();
        }
    }
}
