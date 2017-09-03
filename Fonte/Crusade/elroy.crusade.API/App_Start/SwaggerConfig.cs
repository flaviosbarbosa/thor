using System.Web.Http;
using WebActivatorEx;
using elroy.crusade.API;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace elroy.crusade.API
{
    /// <summary>
    /// Configuração do Swagger
    /// </summary>
    public class SwaggerConfig
    {
        /// <summary>
        /// Configuração do registro do Swagger
        /// </summary>
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "elroy.crusade.API.xml");
                    c.IncludeXmlComments(GetXmlCommentsPath());
                })
                .EnableSwaggerUi(c =>
                {

                });
        }

        /// <summary>
        /// Definição do caminho do XML das Apis
        /// </summary>
        /// <returns></returns>
        protected static string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}\bin\elroy.crusade.API.xml", System.AppDomain.CurrentDomain.BaseDirectory);
        }    
    }
}
