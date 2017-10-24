using elroy.crusade.dominio;
using elroy.crusade.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace elroy.crusade.API.Controllers
{
    /// <summary>
    /// Controle das ações da Agenda Pastoral
    /// </summary>
    public class AgendaPastoralController : ApiController
    {
        /// <summary>
        /// Retorna um evento da agenda pastoral por código do evento
        /// </summary>
        /// <param name="id">Informe o codigo do compromisso</param>        
        /// <remarks>Retorna um compromisso da igreja</remarks>        
        [Route("Api/BuscaAgendaPastoral/{id}")]
        [ResponseType(typeof(int))]
        [HttpGet]
            public HttpResponseMessage Get(int id)
        {
            try
            {
                AgendaPastoralBLL agendapastoral = new AgendaPastoralBLL();
                var agenda = agendapastoral.BuscaPorCodigo(id);

                if (agenda.Id != 0)
                    return Request.CreateResponse(HttpStatusCode.OK, agenda);
                else
                    throw new KeyNotFoundException();
            }
            catch (KeyNotFoundException)
            {
                string mensagem = string.Format("O compromisso {0} não foi encontrada", id);
                HttpError error = new HttpError(mensagem);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, error);
            }
        }

        /// <summary>
        /// Retorna uma lista de eventos da agenda pastoral
        /// </summary>
        /// <remarks>Retorna um lsita de agenda pastoral</remarks>        
        [Route("Api/ListaAgendaPastoral")]        
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                AgendaPastoralBLL AgendaPastoral = new AgendaPastoralBLL();
                IEnumerable<AgendaPastoral> listaagenda = AgendaPastoral.ListaAgendaPastoral();

                if (listaagenda.Count() > 0)
                    return Request.CreateResponse(HttpStatusCode.OK, listaagenda);
                else
                    throw new KeyNotFoundException();
            }
            catch (KeyNotFoundException)
            {
                string mensagem = string.Format("Não há compromissos agendados");
                HttpError error = new HttpError(mensagem);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, error);
            }

        }

        /// <summary>
        /// Insere um evento na agenda pastoral
        /// </summary>
        /// <param name="agenda">Informe um objeto agenda</param>
        /// <remarks>Insere um evento na agenda pastoral</remarks>        
        [Route("Api/GravaAgendaPastoral")]
        [ResponseType(typeof(AgendaPastoral))]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] AgendaPastoral agenda)
        {
            AgendaPastoralBLL agendabll = new AgendaPastoralBLL();
            var agendaret = agendabll.Grava(agenda);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            string location = Url.Link("DefaultApi", new { Controller = "agendapastoral", id = agendaret.Id });
            response.Headers.Location = new Uri(location);

            return response;
        }

        /// <summary>
        /// Exclui um evento da agenda pastoral
        /// </summary>
        /// <param name="id">Informe o código do evento a ser excluído</param>        
        /// <remarks>Retorna uma mensagem http de sucesso ou falha</remarks>        
        [Route("Api/DeletaAgendaPastoral/{id}")]
        [ResponseType(typeof(int))]
        [HttpDelete]
        public HttpResponseMessage Delete([FromUri] int id)
        {
            AgendaPastoralBLL agendabll = new AgendaPastoralBLL();
            agendabll.Deleta(agendabll.BuscaPorCodigo(id));
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Atualiza um evento da agenda pastoral
        /// </summary>
        /// <param name="agenda">Informe um objeto agenda</param>
        /// <param name="id">Informe o codigo da agenda a ser atualizada</param>
        /// <remarks>Retorna uma mensagem http de sucesso ou falha</remarks>        
        [Route("Api/AtualizaAgendaPastoral/{id}")]
        [ResponseType(typeof(AgendaPastoral))]
        [HttpPut]
        public HttpResponseMessage Put([FromBody]AgendaPastoral agenda, [FromUri] int id)
        {
            AgendaPastoralBLL agendabll = new AgendaPastoralBLL();

            agendabll.Grava(agenda);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}