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
    /// Registro de beneficiarios (Membros, Pastor e Fornecedores de Serviços
    /// </summary>
    public class BeneficiarioController : ApiController
    {

        /// <summary>
        /// Retorna um beneficíario por código
        /// </summary>
        /// <param name="id">Informe o codigo do beneficiario</param>
        /// <remarks>Retona um objeto beneficiario valido</remarks>             
        [Route("Api/BuscaBeneficiario/{id}")]
        [ResponseType(typeof(int))]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                BeneficiarioBLL beneficiariobll = new BeneficiarioBLL();
                var beneficiario = beneficiariobll.BuscaPorCodigo(id);

                if (beneficiario.id != 0)
                    return Request.CreateResponse(HttpStatusCode.OK, beneficiario);
                else
                    throw new KeyNotFoundException();
            }
            catch (KeyNotFoundException)
            {
                string mensagem = string.Format("Não foi possivel localizar o beneficiario {0]", id);
                HttpError error = new HttpError(mensagem);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, error);
            }
        }

        /// <summary>
        /// Retorna uma lista de beneficiarios
        /// </summary>
        /// <remarks>Retorna uma lista de beneficiarios</remarks>        
        [Route("Api/ListaBeneficiarios")]
        [ResponseType(typeof(int))]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                BeneficiarioBLL beneficiarioBll = new BeneficiarioBLL();
                var listaBeneficiario = beneficiarioBll.ListaBeneficiario();

                if (listaBeneficiario.Count > 0)
                    return Request.CreateResponse(HttpStatusCode.OK, listaBeneficiario);
                else
                    throw new KeyNotFoundException();
            }
            catch (KeyNotFoundException )
            {
                string mensagem = string.Format("Não foi possivel localizar nenhum beneficiário");
                HttpError error = new HttpError(mensagem);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, error);
            }
        }

        /// <summary>
        /// Insere um beneficiario
        /// </summary>
        /// <param name="beneficiario"></param>        
        /// <remarks>Retorna Beneficiario criado</remarks>        
        [Route("API/GravaBeneficiario")]
        [ResponseType(typeof(Beneficiario))]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Beneficiario beneficiario)
        {
            BeneficiarioBLL beneficiarioBll = new BeneficiarioBLL();
            var beneret = beneficiarioBll.Grava(beneficiario);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            string location = Url.Link("DefaultApi", new { Controller = "beneficiario", id = beneret.id });
            response.Headers.Location = new Uri(location);

            return response;
        }

        /// <summary>
        /// Exclui um beneficiario
        /// </summary>
        /// <param name="id">Informe o codigo do beneficiario</param>
        /// <remarks>Retorna Beneficiario excluido</remarks>
        [Route("API/DeletaBeneficiario/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete([FromUri] int id)
        {
            BeneficiarioBLL beneficiarioBll = new BeneficiarioBLL();
            beneficiarioBll.Deleta(beneficiarioBll.BuscaPorCodigo(id));
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Atualiza um beneficiario
        /// </summary>
        /// <param name="beneficiario">Informe os dados do beneficiario a ser atualizado</param>
        /// <param name="id">Informe o codigo do beneficiario</param>
        /// <returns>Retorna Beneficiario atualizado</returns>
        [Route("API/AtualizaBeneficiario/{id}")]
        [HttpPut]
        public HttpResponseMessage Put([FromBody]Beneficiario beneficiario, [FromUri] int id)
        {
            BeneficiarioBLL beneficiarioBll = new BeneficiarioBLL();

            beneficiarioBll.Grava(beneficiario);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
