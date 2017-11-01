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
    /// Registram os pedidos de oração enviados pela app mobile
    /// </summary>
    public class PedidoOracaoController : ApiController
    {
        /// <summary>
        /// Retorna um Pedido de Oração por codigo
        /// </summary>
        /// <param name="id">Informe o codigo</param>
        /// <remarks>Retorna Pedido de Oração</remarks>
        [Route("API/BuscaPedidoOracao/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                PedidoOracaoBLL pedidobll = new PedidoOracaoBLL();
                var pedido = pedidobll.BuscaPorCodigo(id);

                if (pedido.Id != 0)
                    return Request.CreateResponse(HttpStatusCode.OK, pedido);
                else
                    throw new KeyNotFoundException();
            }
            catch (KeyNotFoundException)
            {
                string mensagem = string.Format("Não foi possivel localizar o Pedido de Orção {0]", id);
                HttpError error = new HttpError(mensagem);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, error);
            }
        }

        /// <summary>
        /// Retorna lista de Pedidos de Oração 
        /// </summary>
        /// <remarks>Retorna lista de Pedidos de Oração</remarks>
        [Route("API/ListaPedidosOracao")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                PedidoOracaoBLL pedidobll = new PedidoOracaoBLL();
                var listaprogramacao = pedidobll.ListaPedidoOracao();

                if (listaprogramacao.Count > 0)
                    return Request.CreateResponse(HttpStatusCode.OK, listaprogramacao);
                else
                    throw new KeyNotFoundException();
            }
            catch (KeyNotFoundException)
            {
                string mensagem = string.Format("Não foi possivel localizar nenhum pedido de oração");
                HttpError error = new HttpError(mensagem);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, error);
            }
        }

        /// <summary>
        /// Insere uma novo Pedido de Oração 
        /// </summary>
        /// <param name="pedidoOracao">Informe os dados a serem incluidos</param>
        /// <remarks>Retorna pedidos registrada</remarks>
        [Route("API/GravaPedidoOracao")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] PedidoOracao pedidoOracao)
        {
            PedidoOracaoBLL pedidobll = new PedidoOracaoBLL();
            var progret = pedidobll.Grava(pedidoOracao);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            string location = Url.Link("DefaultApi", new { Controller = "pedidoOracao", id = progret.Id });
            response.Headers.Location = new Uri(location);

            return response;
        }

        /// <summary>
        /// Exclui Pedido de Oração
        /// </summary>
        /// <param name="id">Informe o codigo do Pedido de Oração</param>
        /// <remarks>Retorna Pedido de Oração excluido</remarks>
        [Route("API/DeletaPedidoOracao/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete([FromUri] int id)
        {
            PedidoOracaoBLL PedidoBLL = new PedidoOracaoBLL();
            PedidoBLL.Deleta(PedidoBLL.BuscaPorCodigo(id));
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Atualiza Pedido Oração
        /// </summary>
        /// <param name="pedidoOracao">Informe os dados do Pedido de Oração</param>
        /// <param name="id">Informe o código</param>
        /// <remarks>Retorna Pedido de Oração atualizados</remarks>
        [Route("API/AtualizaPedidoOracao/{id}")]
        [HttpPut]
        public HttpResponseMessage Put([FromBody]PedidoOracao pedidoOracao, [FromUri] int id)
        {
            PedidoOracaoBLL pedidoBll = new PedidoOracaoBLL();

            pedidoBll.Grava(pedidoOracao);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
