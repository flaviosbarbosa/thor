using elroy.crusade.dominio;
using elroy.crusade.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace elroy.crusade.API.Controllers
{
    /// <summary>
    ///  Registro dos parametros utilizados pela igreja no sistema
    /// </summary>
    public class ParametrosController : ApiController
    {
        /// <summary>
        /// Retorna um registro de parametro por codigo
        /// </summary>
        /// <param name="id">Informe o codigo do parametro </param>
        /// <remarks>Retorna Parametro</remarks>
        [Route("API/BuscaParametro/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                ParametroBLL parametrosbll = new ParametroBLL();
                var parametros = parametrosbll.BuscaPorCodigo(id);

                if (parametros.id != 0)
                    return Request.CreateResponse(HttpStatusCode.OK, parametros);
                else
                    throw new KeyNotFoundException();
            }
            catch (KeyNotFoundException )
            {
                string mensagem = string.Format("Não foi possivel localizar o Parametro {0]", id);
                HttpError error = new HttpError(mensagem);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, error);
            }
        }

        /// <summary>
        /// Registra um novo parametro
        /// </summary>
        /// <param name="parametros">Informe os dados do parametro</param>
        /// <remarks>Retorna parametro registrado</remarks>
        [Route("API/GravaParametro")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Parametros parametros)
        {
            ParametroBLL ParametrosBll = new ParametroBLL();
            var paramret = ParametrosBll.Grava(parametros);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            string location = Url.Link("DefaultApi", new { Controller = "parametros", id = paramret.id });
            response.Headers.Location = new Uri(location);

            return response;
        }

        /// <summary>
        /// Exclui um parametro
        /// </summary>
        /// <param name="id">Informe o codigo</param>
        /// <remarks>Parametro excluido</remarks>
        [Route("API/DeletaParametro/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete([FromUri] int id)
        {
            ParametroBLL ParametrosBll = new ParametroBLL();
            ParametrosBll.Deleta(ParametrosBll.BuscaPorCodigo(id));
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Atualiza Parametro
        /// </summary>
        /// <param name="parametros">Informe os dados a serem atualizados</param>
        /// <param name="id">Informe o codigo</param>
        /// <remarks>Parametros atualizados</remarks>
        [Route("API/AtualizaParametro/{id}")]
        [HttpPut]
        public HttpResponseMessage Put([FromBody]Parametros parametros, [FromUri] int id)
        {
            ParametroBLL ParametrosBll = new ParametroBLL();

            ParametrosBll.Grava(parametros);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}