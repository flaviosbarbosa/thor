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
    /// Classificação das mensagens entrantes e saintes
    /// </summary>
    public class TipoMensagemController : ApiController
    {

        /// <summary>
        /// Retorna por código
        /// </summary>
        /// <param name="id">Informe o código</param>
        /// <remarks>Retorna um Tipo de Mensaagem</remarks>
        [Route("API/BuscaTipoMensagem/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                TipoMensagemBLL tipobll = new TipoMensagemBLL();
                var tipomensagemret = tipobll.BuscaPorCodigo(id);

                if (tipomensagemret.Id != 0)
                    return Request.CreateResponse(HttpStatusCode.OK, tipomensagemret);
                else
                    throw new KeyNotFoundException();
            }
            catch (KeyNotFoundException)
            {
                string mensagem = string.Format("Tipo de mensagem {0} não encontrado", id);
                HttpError error = new HttpError(mensagem);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, error);
            }
        }

        /// <summary>
        /// Retorna lista de tipos de mensagens
        /// </summary>
        /// <remarks>Retorna lista de menagens</remarks>
        [Route("API/ListaTipoMensagens")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                TipoMensagemBLL tipobll = new TipoMensagemBLL();
                IEnumerable<TipoMensagem> listatipo = tipobll.ListaTipoMensagem();

                if (listatipo.Count() > 0)
                    return Request.CreateResponse(HttpStatusCode.OK, listatipo);
                else
                    throw new KeyNotFoundException();
            }
            catch (KeyNotFoundException)
            {
                string mensagem = string.Format("Não há tipos de mensagens registrados");
                HttpError error = new HttpError(mensagem);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, error);
            }

        }

        /// <summary>
        /// Insere novo registro
        /// </summary>
        /// <param name="tipo">Informe os dados do novo registro</param>
        /// <remarks>Retorna Tipo de Mensagem inserido</remarks>
        [Route("API/GravaTipoMensagem")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] TipoMensagem tipo)
        {
            TipoMensagemBLL tipobll = new TipoMensagemBLL();
            var tiporet = tipobll.Grava(tipo);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            string location = Url.Link("DefaultApi", new { Controller = "tipomensagem", id = tiporet.Id });
            response.Headers.Location = new Uri(location);

            return response;
        }

        /// <summary>
        /// Exclui registro
        /// </summary>
        /// <param name="id">Informe o código</param>
        /// <remarks>Retorna tipo mensagem excluída</remarks>
        [Route("API/DeletaTipoMensagem/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete([FromUri] int id)
        {
            TipoMensagemBLL tipobll = new TipoMensagemBLL();
            tipobll.Deleta(tipobll.BuscaPorCodigo(id));
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Atualiza Tipo de Mensagem
        /// </summary>
        /// <param name="tipo">Informe os dados a serem atualizados</param>
        /// <param name="id">Informe o codigo</param>
        /// <remarks>Retorna Tipo Mensagem atualizada</remarks>
        [Route("API/AtualizaTipoMensagem/{id}")]
        [HttpPut]
        public HttpResponseMessage Put([FromBody]TipoMensagem tipo, [FromUri] int id)
        {
            TipoMensagemBLL tipobll = new TipoMensagemBLL();

            tipobll.Grava(tipo);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}