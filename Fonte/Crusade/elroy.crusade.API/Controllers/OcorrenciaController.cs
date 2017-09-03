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
    /// Registro de ocorrencias durante o tratamento das mensagens
    /// </summary>
    public class OcorrenciaController : ApiController
    {
        /// <summary>
        /// Retorna uma ocorrencia por código
        /// </summary>
        /// <param name="id">Informe o código</param>
        /// <remarks>Retorna uma ocorrência</remarks>
        [Route("API/BuscaOcorrencia/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                OcorrenciaBLL ocorrenciaBLL = new OcorrenciaBLL();
                var Eventos = ocorrenciaBLL.BuscaPorCodigo(id);

                if (Eventos.id != 0)
                    return Request.CreateResponse(HttpStatusCode.OK, Eventos);
                else
                    throw new KeyNotFoundException();
            }
            catch (KeyNotFoundException )
            {
                string mensagem = string.Format("Não foi possivel localizar a Ocorrência {0]", id);
                HttpError error = new HttpError(mensagem);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, error);
            }
        }

        /// <summary>
        /// Retorna uma lista de ocorrencias
        /// </summary>
        /// <remarks>Retorna uma lista de ocorrencias</remarks>
        [Route("API/ListaOcorrencias")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                OcorrenciaBLL ocorrenciaBLL = new OcorrenciaBLL();
                var listaEventos = ocorrenciaBLL.ListaOcorrencia();

                if (listaEventos.Count > 0)
                    return Request.CreateResponse(HttpStatusCode.OK, listaEventos);
                else
                    throw new KeyNotFoundException();
            }
            catch (KeyNotFoundException )
            {
                string mensagem = string.Format("Não foi possivel localizar nenhuma Ocorrência");
                HttpError error = new HttpError(mensagem);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, error);
            }
        }

        /// <summary>
        /// Insere uma nova ocorrencia
        /// </summary>
        /// <param name="ocorrencia">Informe os dados da nova ocorrencia</param>
        /// <remarks>Retorna ocorrencia registrada</remarks>
        [Route("API/GravaOcorrencia")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Ocorrencia ocorrencia)
        {
            OcorrenciaBLL ocorrenciaBLL = new OcorrenciaBLL();
            var ocorrenciaret = ocorrenciaBLL.Grava(ocorrencia);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            string location = Url.Link("DefaultApi", new { Controller = "eventos", id = ocorrenciaret.id });
            response.Headers.Location = new Uri(location);

            return response;
        }

        /// <summary>
        /// Exclui uma ocorrência
        /// </summary>
        /// <param name="id">Informe o codigo da ocorrência</param>
        /// <remarks>Retorna ocorrencia excluida</remarks>
        [Route("API/DeletaOcorrencia/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete([FromUri] int id)
        {
            OcorrenciaBLL OcorrenciaBLL = new OcorrenciaBLL();
            OcorrenciaBLL.Deleta(OcorrenciaBLL.BuscaPorCodigo(id));
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Atualiza uma ocorrencia
        /// </summary>
        /// <param name="ocorrencia">Informe os dados a serem atualizados</param>
        /// <param name="id">Informe o codigo a ser atualizado</param>
        /// <remarks>Retorna Ocorrencia atualizada</remarks>
        [Route("API/AtualizaOcorrencia/{id}")]
        [HttpPut]
        public HttpResponseMessage Put([FromBody]Ocorrencia ocorrencia, [FromUri] int id)
        {
            OcorrenciaBLL OcorrenciaBLL = new OcorrenciaBLL();

            OcorrenciaBLL.Grava(ocorrencia);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}