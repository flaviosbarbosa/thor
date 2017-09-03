using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

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
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
           // SwaggerConfig.Register();
        }
    }
}
