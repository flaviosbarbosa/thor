using elroy.crusade.bll;
using elroy.crusade.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace elroy.crusade.API.Controllers
{
    /// <summary>
    /// Registra os participantes que confirmam presença nos eventos
    /// </summary>
    public class ParticipantesController : ApiController
    {
        /// <summary>
        /// Retorna um Participante por codigo
        /// </summary>
        /// <param name="id">Informe o codigo</param>
        /// <remarks>Retorna Participante do Evento</remarks>
        [Route("API/BuscaParticipante/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(String id)
        {
            try
            {
                ParticipanteBLL participantebll = new ParticipanteBLL();
                var participante = participantebll.Busca(id);

                if (!string.IsNullOrEmpty(participante.Id))
                    return Request.CreateResponse(HttpStatusCode.OK, participante);
                else
                    throw new KeyNotFoundException();
            }
            catch (KeyNotFoundException)
            {
                string mensagem = string.Format("Não foi possivel localizar o Participante {0]", id);
                HttpError error = new HttpError(mensagem);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, error);
            }
        }

        /// <summary>
        /// Retorna lista de Participantes de Eventos
        /// </summary>
        /// <remarks>Retorna lista de Participantes de Eventos</remarks>
        [Route("API/ListaParticipantes")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                ParticipanteBLL progbll = new ParticipanteBLL();
                var listaparticipante = progbll.ListaParticipante();

                if (listaparticipante.Count > 0)
                    return Request.CreateResponse(HttpStatusCode.OK, listaparticipante);
                else
                    throw new KeyNotFoundException();
            }
            catch (KeyNotFoundException)
            {
                string mensagem = string.Format("Não há nenhum participante");
                HttpError error = new HttpError(mensagem);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, error);
            }
        }

        /// <summary>
        /// Insere uma novo Participante
        /// </summary>
        /// <param name="participantes">Informe os dados a serem incluidos</param>
        /// <remarks>Retorna participantes de um evento</remarks>
        [Route("API/GravaParticipante")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Participantes participantes)
        {
            ParticipanteBLL participanteBll = new ParticipanteBLL();
            var progret = participanteBll.Grava(participantes);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            string location = Url.Link("DefaultApi", new { Controller = "participantes", id = progret.Id });
            response.Headers.Location = new Uri(location);

            return response;
        }

        /// <summary>
        /// Exclui Participante 
        /// </summary>
        /// <param name="id">Informe o codigo do Particioante</param>
        /// <remarks>Retorna Participantes excluido</remarks>
        [Route("API/DeletaParticipante/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete([FromUri] String id)
        {
            ParticipanteBLL PedidoBLL = new ParticipanteBLL();
            PedidoBLL.Deleta(PedidoBLL.Busca(id));
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Atualiza Participante 
        /// </summary>
        /// <param name="participantes">Informe os dados do Participante</param>
        /// <param name="id">Informe o código</param>
        /// <remarks>Retorna Participante</remarks>
        [Route("API/AtualizaParticipante/{id}")]
        [HttpPut]
        public HttpResponseMessage Put([FromBody]Participantes participantes, [FromUri] int id)
        {
            ParticipanteBLL participanteBll = new ParticipanteBLL();

            participanteBll.Grava(participantes);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
