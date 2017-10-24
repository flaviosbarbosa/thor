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
    /// Registro das mensagens que são enviadas pela Igreja para a app mobile
    /// </summary>
    public class MensagemSainteController : ApiController
    {
        /// <summary>
        /// Retorna uma mensagem sainte por código
        /// </summary>
        /// <param name="id">Informe o código a ser retornado</param>
        /// <remarks>Retorna uma mensagem sainte</remarks>
        [Route("API/BuscaMensagensSainte/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                MensagemSainteBLL mensagemsainteBLL = new MensagemSainteBLL();
                var msgS = mensagemsainteBLL.BuscaPorCodigo(id);

                if (msgS.Id != 0)
                    return Request.CreateResponse(HttpStatusCode.OK, msgS);
                else
                    throw new KeyNotFoundException();
            }
            catch (KeyNotFoundException )
            {
                string mensagem = string.Format("Não foi possivel localizar a Mensagem Sainte {0]", id);
                HttpError error = new HttpError(mensagem);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, error);
            }
        }

        /// <summary>
        /// Retorna uma lista de mensagens saintes
        /// </summary>
        /// <remarks>Retorna uma lista de msnagens saintes</remarks>
        [Route("API/ListaMensagemSainte")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                MensagemSainteBLL mensagemsainteBLL = new MensagemSainteBLL();
                var listaMensagem = mensagemsainteBLL.ListaMensagemSainte();

                if (listaMensagem.Count > 0)
                    return Request.CreateResponse(HttpStatusCode.OK, listaMensagem);
                else
                    throw new KeyNotFoundException();
            }
            catch (KeyNotFoundException )
            {
                string mensagem = string.Format("Não foi possivel localizar nenhuma Mensagem Sainte");
                HttpError error = new HttpError(mensagem);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, error);
            }
        }

        /// <summary>
        /// Insere uma nova mensagem sainte
        /// </summary>
        /// <param name="mensagemSainte">Informe os dados da mensagens sainte</param>
        /// <remarks>Retorna mensagem inserida</remarks>
        [Route("API/GravaMensagemSainte")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] MensagemSainte mensagemSainte)
        {
            MensagemSainteBLL MensagemSainteBLL = new MensagemSainteBLL();
            var msgSret = MensagemSainteBLL.Grava(mensagemSainte);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            string location = Url.Link("DefaultApi", new { Controller = "mensagemsainte", id = msgSret.Id });
            response.Headers.Location = new Uri(location);

            return response;
        }

        /// <summary>
        /// Exclui Mensagem Sainte
        /// </summary>
        /// <param name="id">Informe o código da mensagem a ser excluida</param>
        /// <remarks>Retorna mensagem excluida</remarks>
        [Route("API/DeletaMensagemSainte/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete([FromUri] int id)
        {
            MensagemSainteBLL mensagemsainteBLL = new MensagemSainteBLL();
            mensagemsainteBLL.Deleta(mensagemsainteBLL.BuscaPorCodigo(id));
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Atualiza Mensagem Sainte
        /// </summary>
        /// <param name="mensagemsainte">Informe os dados a serem atualizados</param>
        /// <param name="id">Informe o codigo a ser atualizado</param>
        /// <remarks>Retorna mensagem atualizada</remarks>
        [Route("API/AtualizaMensagemSainte/{id}")]
        [HttpPut]
        public HttpResponseMessage Put([FromBody]MensagemSainte mensagemsainte, [FromUri] int id)
        {
            MensagemSainteBLL MensagemSainteBLL = new MensagemSainteBLL();

            MensagemSainteBLL.Grava(mensagemsainte);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}