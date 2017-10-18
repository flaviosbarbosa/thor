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
    /// Registro da programação da igreja a ser enviada via mensagem para a app mobile
    /// </summary>
    public class ProgramacaoController : ApiController
    {
        /// <summary>
        /// Retorna uma Programacao por codigo
        /// </summary>
        /// <param name="id">Informe o codigo</param>
        /// <remarks>Retorna Programacao</remarks>
        [Route("API/BuscaProgramacao/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                ProgramacaoBLL progbll = new ProgramacaoBLL();
                var programacao = progbll.BuscaPorCodigo(id);

                if (programacao.id != 0)
                    return Request.CreateResponse(HttpStatusCode.OK, programacao);
                else
                    throw new KeyNotFoundException();
            }
            catch (KeyNotFoundException )
            {
                string mensagem = string.Format("Não foi possivel localizar a programação {0]", id);
                HttpError error = new HttpError(mensagem);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, error);
            }
        }

        /// <summary>
        /// Retorna lista de programações
        /// </summary>
        /// <remarks>Retorna lista de programações</remarks>
        [Route("API/ListaProgramacoes")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                ProgramacaoBLL progbll = new ProgramacaoBLL();
                var listaprogramacao = progbll.ListaProgramacao();

                if (listaprogramacao.Count > 0)
                    return Request.CreateResponse(HttpStatusCode.OK, listaprogramacao);
                else
                    throw new KeyNotFoundException();
            }
            catch (KeyNotFoundException )
            {
                string mensagem = string.Format("Não foi possivel localizar nenhuma programacao");
                HttpError error = new HttpError(mensagem);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, error);
            }
        }

        /// <summary>
        /// Insere uma nova programação
        /// </summary>
        /// <param name="programacao">Informe os dados a serem incluidos</param>
        /// <remarks>Retorna programa registrada</remarks>
        [Route("API/GravaProgramacao")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Programacao programacao)
        {
            ProgramacaoBLL PROGBll = new ProgramacaoBLL();
            var progret = PROGBll.Grava(programacao);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            string location = Url.Link("DefaultApi", new { Controller = "programacao", id = progret.id });
            response.Headers.Location = new Uri(location);

            return response;
        }

        /// <summary>
        /// Exclui programação
        /// </summary>
        /// <param name="id">Informe o codigo da programação</param>
        /// <remarks>Retorna Programação excluida</remarks>
        [Route("API/DeletaProgramacao/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete([FromUri] int id)
        {
            ProgramacaoBLL PROGBll = new ProgramacaoBLL();
            PROGBll.Deleta(PROGBll.BuscaPorCodigo(id));
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Atualiza Programação
        /// </summary>
        /// <param name="programacao">Informe os dados da programação</param>
        /// <param name="id">Informe o código</param>
        /// <remarks>Retorna Programação atualizada</remarks>
        [Route("API/AtualizaProgramacao/{id}")]
        [HttpPut]
        public HttpResponseMessage Put([FromBody]Programacao programacao, [FromUri] int id)
        {
            ProgramacaoBLL progBll = new ProgramacaoBLL();

            progBll.Grava(programacao);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
