using elroy.crusade.dominio;
using elroy.crusade.Infra;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace elroy.crusade.API.Controllers
{
    /// <summary>
    /// Registro dos Eventos da igreja
    /// </summary>
    public class EventosController : ApiController
    {
        ///// <summary>
        ///// Retorna um Evento agendado por código
        ///// </summary>
        ///// <param name="id">Informe o codigo do evento</param>
        ///// <remarks>Retorna o evento informado</remarks>
        //[Route("API/BuscaEvento/{id}")]
        //[HttpGet]
        //public HttpResponseMessage Get(int id)
        //{
        //    try
        //    {
        //        EventosBLL eventosbll = new EventosBLL();
        //        var Eventos = eventosbll.BuscaPorCodigo(id);

        //        if (Eventos.id != 0)
        //            return Request.CreateResponse(HttpStatusCode.OK, Eventos);
        //        else
        //            throw new KeyNotFoundException();
        //    }
        //    catch (KeyNotFoundException )
        //    {
        //        string mensagem = string.Format("Não foi possivel localizar o Evento {0]", id);
        //        HttpError error = new HttpError(mensagem);
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, error);
        //    }
        //}

        ///// <summary>
        ///// Retorna uma lista de eventos agendados
        ///// </summary>
        ///// <remarks>Retorna uma lista de eventos agendados</remarks>
        //[Route("API/ListaEventos")]
        //[HttpGet]
        //public HttpResponseMessage Get()
        //{
        //    try
        //    {
        //        EventosBLL eventosBll = new EventosBLL();
        //        var listaEventos = eventosBll.ListaEventos();

        //        if (listaEventos.Count > 0)
        //            return Request.CreateResponse(HttpStatusCode.OK, listaEventos);
        //        else
        //            throw new KeyNotFoundException();
        //    }
        //    catch (KeyNotFoundException )
        //    {
        //        string mensagem = string.Format("Não foi possivel localizar nenhum evento");
        //        HttpError error = new HttpError(mensagem);
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, error);
        //    }
        //}

        /// <summary>
        /// Insere um novo evento
        /// </summary>
        /// <param name="eventos">Informe o evento a ser inserido</param>
        /// <remarks>Retorna Evento criado</remarks>
        [Route("API/GravaEvento")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Eventos eventos)
        {
            EventosBLL eventosBll = new EventosBLL();
            var eventoret = eventosBll.Grava(eventos);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            string location = Url.Link("DefaultApi", new { Controller = "eventos", id = eventoret.id });
            response.Headers.Location = new Uri(location);

            return response;
        }


        /// <summary>
        /// Exclui e evento
        /// </summary>
        /// <param name="id">Informe o codigo do evento a ser excluido</param>
        /// <remarks>Retorna Evento excluido</remarks>
        [Route("API/DeleteEvento/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete([FromUri] int id)
        {
            EventosBLL eventosBll = new EventosBLL();
            eventosBll.Deleta(eventosBll.BuscaPorCodigo(id));
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Atualiza evento
        /// </summary>
        /// <param name="Eventos">Informe os dados a serem atualizados</param>
        /// <param name="id">Informe o código do evento a ser atualizado</param>
        /// <remarks>Retorna evento atualizado</remarks>
        [Route("API/AtualizaEvento/{id}")]
        [HttpPut]
        public HttpResponseMessage Put([FromBody]Eventos Eventos, [FromUri] int id)
        {
            EventosBLL eventosBll = new EventosBLL();

            eventosBll.Grava(Eventos);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}