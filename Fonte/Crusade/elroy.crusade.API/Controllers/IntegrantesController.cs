using elroy.crusade.dominio;
using elroy.crusade.Infra;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace elroy.crusade.API.Controllers
{
    /// <summary>
    /// Registro dos Beneficiarios que participam de Ministerios
    /// </summary>
    public class IntegrantesController : ApiController
    {
        /// <summary>
        /// Retorna um integrande por código
        /// </summary>
        /// <param name="id">Informe o código do integrante</param>
        /// <remarks>Retorna o integrante solicitado</remarks>
        [Route("API/BuscaIntegrante/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                IntegrantesBLL integrantesbll = new IntegrantesBLL();
                var Integrantes = integrantesbll.BuscaPorCodigo(id);

                if (Integrantes.id != 0)
                    return Request.CreateResponse(HttpStatusCode.OK, Integrantes);
                else
                    throw new KeyNotFoundException();
            }
            catch (KeyNotFoundException )
            {
                string mensagem = string.Format("Não foi possivel localizar o integrante {0]", id);
                HttpError error = new HttpError(mensagem);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, error);
            }
        }

        /// <summary>
        /// Retorna uma lista de integrantes
        /// </summary>
        /// <remarks>Retorna uma lista de integrantes</remarks>
        [Route("API/ListaIntegrantes")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                IntegrantesBLL integrantesBll = new IntegrantesBLL();
                var listaIntegrantes = integrantesBll.ListaIntegrantes();

                if (listaIntegrantes.Count > 0)
                    return Request.CreateResponse(HttpStatusCode.OK, listaIntegrantes);
                else
                    throw new KeyNotFoundException();
            }
            catch (KeyNotFoundException )
            {
                string mensagem = string.Format("Não foi possivel localizar nenhum integrante do Ministério.");
                HttpError error = new HttpError(mensagem);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, error);
            }
        }

        /// <summary>
        /// Insere um novo integrante
        /// </summary>
        /// <param name="integrantes">Informe o integrante a ser inserido</param>
        /// <remarks>Retona integrante inserido</remarks>
        [Route("API/GravaIntegrante")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Integrantes integrantes)
        {
            IntegrantesBLL integrantesBll = new IntegrantesBLL();
            var integranteret = integrantesBll.Grava(integrantes);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            string location = Url.Link("DefaultApi", new { Controller = "integrantes", id = integranteret.id });
            response.Headers.Location = new Uri(location);

            return response;
        }

        /// <summary>
        /// Exclui integrante
        /// </summary>
        /// <param name="id">Informe o codigo do integrante a ser excluido</param>
        /// <remarks>Retorna integrante excluido</remarks>
        [Route("API/DeletaIntegrante/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete([FromUri] int id)
        {
            IntegrantesBLL integrantesBll = new IntegrantesBLL();
            integrantesBll.Deleta(integrantesBll.BuscaPorCodigo(id));
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Atualiza integrante
        /// </summary>
        /// <param name="integrantes">Informe o integrante com os dados a serem atualizados </param>
        /// <param name="id">Informe o codigo do integrante a ser atualizado</param>
        /// <remarks>Retorna integrante atualizado</remarks>
        [Route("API/AtualizaIntegrante/{id}")]
        [HttpPut]
        public HttpResponseMessage Put([FromBody]Integrantes integrantes, [FromUri] int id)
        {
            IntegrantesBLL integrantesBll = new IntegrantesBLL();

            integrantesBll.Grava(integrantes);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
