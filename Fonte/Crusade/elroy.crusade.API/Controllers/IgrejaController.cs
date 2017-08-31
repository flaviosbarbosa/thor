using elroy.crusade.dominio;
using elroy.crusade.Infra;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace elroy.crusade.API.Controllers
{
    public class IgrejaController : ApiController
    {
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

        public HttpResponseMessage Post([FromBody] Igreja igreja)
        {
            IgrejaBLL igrejaBLL = new IgrejaBLL();
            igreja = igrejaBLL.Grava(igreja);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            string location = Url.Link("DefaultApi", new { Controller = "igreja", id = igreja.id });
            response.Headers.Location = new Uri(location);

            return response;
        }

        public HttpResponseMessage Delete([FromUri] int id)
        {
            IgrejaBLL igrejaBLL = new IgrejaBLL();            
            igrejaBLL.Deleta(igrejaBLL.BuscaPorCodigo(id));
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        
        public HttpResponseMessage Put([FromBody]Igreja igreja, [FromUri] int id)
        {
            IgrejaBLL igrejaBLL = new IgrejaBLL();

            igrejaBLL.Grava(igreja);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}