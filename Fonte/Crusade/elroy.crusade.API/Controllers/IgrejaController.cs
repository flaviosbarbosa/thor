using elroy.crusade.dominio;
using elroy.crusade.Infra;
using Newtonsoft.Json;
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
    /// Controle sobre as ações da Igreja
    /// </summary>
    public class IgrejaController : ApiController
    {
        /// <summary>
        /// Retorna uma igreja pelo codigo
        /// </summary>
        /// <param name="id">Informe o codigo</param>
        /// <remarks>Adds new user to application and grant access</remarks>
        /// <response code="400">Falha ao buscar igreja</response>
        /// <response code="500">Não foi possivel localizar a igreja desejada</response>        
        [Route("Api/BuscaIgreja/{id}")]
        [ResponseType(typeof(int))]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                IgrejaBLL igrejaBLL = new IgrejaBLL();
                var igreja = igrejaBLL.BuscaPorCodigo(id);

                if (igreja.id != 0)
                    return Request.CreateResponse(HttpStatusCode.OK, igreja);
                else
                    throw new KeyNotFoundException();
            }
            catch (KeyNotFoundException)
            {
                string mensagem = string.Format("A Igreja {0} não foi encontrada", id);
                HttpError error = new HttpError(mensagem);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, error);
            }
            
        }

        /// <summary>
        /// Retorna uma lista de igrejas
        /// </summary>        
        /// <remarks>Lista de Igrejas</remarks>
        /// <response code="400">Falha ao buscar lista de igrejas</response>
        /// <response code="500">Não foi possivel buscar a lista de igrejas</response>        
        [Route("Api/ListaIgreja")]
        [ResponseType(typeof(int))]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                IgrejaBLL igrejaBLL = new IgrejaBLL();
                IEnumerable<Igreja>listaigreja = igrejaBLL.ListaIgreja();

                if (listaigreja.Count() > 0)
                    return Request.CreateResponse(HttpStatusCode.OK, listaigreja);
                else
                    throw new KeyNotFoundException();
            }
            catch (KeyNotFoundException)
            {
                string mensagem = string.Format("Não há igrejas cadastradas");
                HttpError error = new HttpError(mensagem);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, error);
            }

        }

        /// <summary>
        /// Adiciona uma nova igreja
        /// </summary>
        /// <param name="igreja">Informe os dados de uma igreja</param>
        /// <remarks>Lista de Igrejas</remarks>
        /// <response code="400">Falha ao enviar os dados ao servidor</response>
        /// <response code="500">Não foi possível salvar os dados no servidor</response>        
        [Route("Api/GravaIgreja")]
        [ResponseType(typeof(int))]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Igreja igreja)
        {
            IgrejaBLL igrejaBLL = new IgrejaBLL();
            igreja = igrejaBLL.Grava(igreja);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            string location = Url.Link("DefaultApi", new { Controller = "igreja", id = igreja.id });
            response.Headers.Location = new Uri(location);

            return response;
        }

        /// <summary>
        /// Exclui Igreja
        /// </summary>
        /// <param name="id">Informe o código</param>
        /// <remarks>Exclui igrejas</remarks>
        /// <response code="400">Falha ao excluir os dados do servidor</response>
        /// <response code="500">Não foi possível excluir os dados no servidor</response>        
        [Route("Api/DeletaIgreja")]
        [ResponseType(typeof(int))]
        [HttpDelete]
        public HttpResponseMessage Delete([FromUri] int id)
        {
            IgrejaBLL igrejaBLL = new IgrejaBLL();            
            igrejaBLL.Deleta(igrejaBLL.BuscaPorCodigo(id));
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        /// <summary>
        /// Atualiza Igreja
        /// </summary>
        /// <param name="igreja">Informe os dados da Igreja</param>
        /// <param name="id">Informe o Código da igreja</param>
        /// <response code="400">Falha ao enviar os dados para atualização</response>
        /// <response code="500">Não foi possível atualizar os dados no servidor</response>        
        [Route("Api/AtualizaIgreja")]
        [ResponseType(typeof(int))]
        [HttpPut]
        public HttpResponseMessage Put([FromBody]Igreja igreja, [FromUri] int id)
        {
            IgrejaBLL igrejaBLL = new IgrejaBLL();

            igrejaBLL.Grava(igreja);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}