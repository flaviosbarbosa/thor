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
    /// Registro das mensagens que foram enviadas pela App Mobile
    /// </summary>
    public class MensagemEntranteController : ApiController
    {
        /// <summary>
        /// Retorna uma Mensagem Entrante por código
        /// </summary>
        /// <param name="id">Informe o código a ser retornado</param>
        /// <remarks>Retorna uma Mensagem Entrante </remarks>
        [Route("API/BuscaMensagemEntrante/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(String id)
        {
            try
            {
                MensagemEntranteBLL mensagementranteBLL = new MensagemEntranteBLL();
                var msgE = mensagementranteBLL.Busca(id);

                if (!String.IsNullOrEmpty(msgE.Id))
                    return Request.CreateResponse(HttpStatusCode.OK, msgE);
                else
                    throw new KeyNotFoundException();
            }
            catch (KeyNotFoundException )
            {
                string mensagem = string.Format("Não foi possivel localizar a Mensagem Entrante {0]", id);
                HttpError error = new HttpError(mensagem);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, error);
            }
        }

        /// <summary>
        /// Retorna uma lista de Mensagens Entrantes
        /// </summary>
        /// <remarks>Retorna uma lista de mensagens entrantes</remarks>
        [Route("API/ListaMensagensEntrante")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                MensagemEntranteBLL MensagemEntranteBLL = new MensagemEntranteBLL();
                var listaMensagem = MensagemEntranteBLL.ListaMensagemEntrante();

                if (listaMensagem.Count > 0)
                    return Request.CreateResponse(HttpStatusCode.OK, listaMensagem);
                else
                    throw new KeyNotFoundException();
            }
            catch (KeyNotFoundException )
            {
                string mensagem = string.Format("Não foi possivel localizar nenhuma Mensagem Entrante");
                HttpError error = new HttpError(mensagem);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, error);
            }
        }

        /// <summary>
        /// Insere Mensagem Entrante
        /// </summary>
        /// <param name="mensagemEntrante">Informe a nova mensagem</param>
        /// <remarks>Retorna mensagem entrante</remarks>
        [Route("API/GravaMensagemEntrante")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] MensagemEntrante mensagemEntrante)
        {
            MensagemEntranteBLL MensagemEntranteBLL = new MensagemEntranteBLL();
            var msgEret = MensagemEntranteBLL.Grava(mensagemEntrante);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            string location = Url.Link("DefaultApi", new { Controller = "mensagementrante", id = msgEret.Id });
            response.Headers.Location = new Uri(location);

            return response;
        }

        /// <summary>
        /// Excluir Mensagem Entrante
        /// </summary>
        /// <param name="id">Informe o codigo da mensagem a ser excluida</param>
        /// <remarks>Retorna mensagem excluida</remarks>
        [Route("API/DeletaMensagemEntrante/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete([FromUri] String id)
        {
            MensagemEntranteBLL mensagemEntranteBLL = new MensagemEntranteBLL();
            mensagemEntranteBLL.Deleta(mensagemEntranteBLL.Busca(id));
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Atualiza Mensaagem Entrante
        /// </summary>
        /// <param name="mensagementrante">Informe os dados a serem atualizados</param>
        /// <param name="id">Informa o código da mensagem a ser atualizada</param>
        /// <remarks>Retorna mensagem atualizada</remarks>
        [Route("API/AtualizaMensagemEntrante/{id}")]
        [HttpPut]
        public HttpResponseMessage Put([FromBody]MensagemEntrante mensagementrante, [FromUri] int id)
        {
            MensagemEntranteBLL MensagemEntranteBLL = new MensagemEntranteBLL();

            MensagemEntranteBLL.Grava(mensagementrante);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}