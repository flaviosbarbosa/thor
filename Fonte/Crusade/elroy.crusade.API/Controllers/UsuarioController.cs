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
    /// Registro dos usuarios do sistema
    /// </summary>
    public class UsuarioController : ApiController
    {

        /// <summary>
        /// Busca um usuário por ID
        /// </summary>               
        /// <param name="id">Informe o codigo do usuario desejado</param>
        /// <remarks>Retorna um objeto usuario</remarks>        
        [Route("API/BuscaUsuario/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                UsuarioBLL usuariobll = new UsuarioBLL();
                var usuarios = usuariobll.BuscaPorCodigo(id);

                if (usuarios.Id != 0)
                    return Request.CreateResponse(HttpStatusCode.OK, usuarios);
                else
                    throw new KeyNotFoundException();
            }
            catch (KeyNotFoundException )
            {
                //TODO: Falha ao consultar um usuario que não existe. Revise isto.
                string mensagem = string.Format("Não foi possivel localizar o usuário {0]", id);                
                HttpError error = new HttpError(mensagem);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, error);
            }
        }

        /// <summary>
        /// Retorna lista de Tipos de Mensagens
        /// </summary>
        /// <remarks>Retorna lista de mensagens</remarks>
        [Route("API/ListaUsuarios")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                UsuarioBLL usuariosBll = new UsuarioBLL();
                var listaUsuarios = usuariosBll.ListaUsuario();

                if (listaUsuarios.Count > 0)
                    return Request.CreateResponse(HttpStatusCode.OK, listaUsuarios);
                else
                    throw new KeyNotFoundException();
            }
            catch (KeyNotFoundException )
            {
                string mensagem = string.Format("Não foi possivel localizar nenhum usuário");
                HttpError error = new HttpError(mensagem);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, error);
            }
        }

        /// <summary>
        /// Insere novo Usuario
        /// </summary>
        /// <param name="usuario">Informe os dados</param>
        /// <remarks>Retorna usuario inserido</remarks>
        [Route("API/GravaUsuario")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Usuario usuario)
        {
            UsuarioBLL UsuariosBll = new UsuarioBLL();
            var usuret = UsuariosBll.Grava(usuario);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            string location = Url.Link("DefaultApi", new { Controller = "usuarios", id = usuret.Id });
            response.Headers.Location = new Uri(location);

            return response;
        }


        /// <summary>
        /// Exclui usuario
        /// </summary>
        /// <param name="id">Informe os novos dados</param>
        /// <remarks>Retorna usuario inserido</remarks>
        [Route("API/DeletaUsuario/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete([FromUri] int id)
        {
            UsuarioBLL usuariosBll = new UsuarioBLL();
            usuariosBll.Deleta(usuariosBll.BuscaPorCodigo(id));
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Atualiza usuario
        /// </summary>
        /// <param name="usuarios">Informe os dados a serem atulizados</param>
        /// <param name="id">Informe o codigo a ser atualizado</param>
        /// <remarks>Retorna usuario atualizado</remarks>
        [Route("API/AtualizaUsuario/{id}")]
        [HttpPut]
        public HttpResponseMessage Put([FromBody]Usuario usuarios, [FromUri] int id)
        {
            UsuarioBLL usuariosBll = new UsuarioBLL();

            usuariosBll.Grava(usuarios);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}