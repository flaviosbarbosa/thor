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
    /// Registro dos ministérios existentes na igreja
    /// </summary>
    public class MinisterioController : ApiController
    {
        /// <summary>
        /// Retorna um ministerio por código
        /// </summary>
        /// <param name="id">Informe o codigo a ser retornado</param>
        /// <remarks>Retorna um Ministerio</remarks>
        [Route("API/BuscaMinisterio/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                MinisterioBLL ministerioBLL = new MinisterioBLL();
                var ministerio = ministerioBLL.BuscaPorCodigo(id);

                if (ministerio.id != 0)
                    return Request.CreateResponse(HttpStatusCode.OK, ministerio);
                else
                    throw new KeyNotFoundException();
            }
            catch (KeyNotFoundException )
            {
                string mensagem = string.Format("Não foi possivel localizar o Ministério {0]", id);
                HttpError error = new HttpError(mensagem);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, error);
            }
        }

        /// <summary>
        /// Retorna uma lista de Ministérios
        /// </summary>
        /// <remarks>Retorna lista de ministérios</remarks>
        [Route("API/ListaMinisterios")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                MinisterioBLL ministerioBLL = new MinisterioBLL();
                var listaMinisterio = ministerioBLL.ListaMinisterio();

                if (listaMinisterio.Count > 0)
                    return Request.CreateResponse(HttpStatusCode.OK, listaMinisterio);
                else
                    throw new KeyNotFoundException();
            }
            catch (KeyNotFoundException )
            {
                string mensagem = string.Format("Não foi possivel localizar nenhum ministério");
                HttpError error = new HttpError(mensagem);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, error);
            }
        }

        /// <summary>
        /// Insere um novo ministério
        /// </summary>
        /// <param name="ministerio">Informe os dados do novo ministério</param>
        /// <remarks>Retorna ministerior registrado</remarks>
        [Route("API/GravaMinisterio")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Ministerio ministerio)
        {
            MinisterioBLL ministerioBLL = new MinisterioBLL();
            var beneret = ministerioBLL.Grava(ministerio);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            string location = Url.Link("DefaultApi", new { Controller = "ministerio", id = beneret.id });
            response.Headers.Location = new Uri(location);

            return response;
        }

        /// <summary>
        /// Exclui um Ministério
        /// </summary>
        /// <param name="id">Informe o código a ser excluido</param>
        /// <remarks>Retor4na ministério excluído</remarks>
        [Route("API/DeletaMinisterio/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete([FromUri] int id)
        {
            MinisterioBLL MinisterioBLL = new MinisterioBLL();
            MinisterioBLL.Deleta(MinisterioBLL.BuscaPorCodigo(id));
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Atualiza Ministério
        /// </summary>
        /// <param name="Ministerio">Informe os dados a serem atualizados</param>
        /// <param name="id">Informe o código do Ministério</param>
        /// <remarks>Retorna ministerio atualizado</remarks>
        [Route("API/AtualizaMinisterio/{id}")]
        [HttpPut]
        public HttpResponseMessage Put([FromBody]Ministerio Ministerio, [FromUri] int id)
        {
            MinisterioBLL MinisterioBLL = new MinisterioBLL();

            MinisterioBLL.Grava(Ministerio);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
