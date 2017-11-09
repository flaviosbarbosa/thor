using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using elroy.crusade.dominio;
using elroy.crusade.Infra;
using System.Data.SqlClient;
using elroy.crusade.dominio.Enum;

namespace elroy.crusade.test
{
    /// <summary>
    /// Validando Usuarios
    /// </summary>
    [TestClass]
    public class UsuarioTest
    {        
        public UsuarioTest()
        {                       
        }

        private Usuario usuario;
        private UsuarioBLL conexao;

        /// <summary>
        /// Monta a estrutura necessária para o teste
        /// </summary>
        [TestInitialize()]
        public void CriaUsuario()
        {
            this.usuario = new Usuario();
            usuario.Id = "";
            usuario.Nome = "Flavio";
            usuario.Login = "flavio.barbosa";
            usuario.Senha = "123";
            usuario.Email = "flavio@elroy.com.br";
            usuario.Cpf = "03180155795";
            usuario.Ativo = SimNao.Nao;         

            this.conexao = new UsuarioBLL();
        }

        /// <summary>
        /// Limpa a tabela que está sendo testada
        /// </summary>
        [ClassCleanup()]
        public static void ZeraTabela()
        {
            IEnumerable<Usuario> lista = new UsuarioBLL().ListaUsuario();
            foreach (var item in lista)
            {
                new UsuarioBLL().Deleta(item);
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion



        [TestMethod]
        public void SalvandoUsuario()
        {                     
            var retorno = conexao.Grava(usuario);
            Assert.IsNotNull(retorno.Id, "Erro ao salvar usuário");
        }

        [TestMethod]
        public void BuscaUsuarioporCodigo()
        {
            var usuretorno = conexao.Grava(usuario);
            usuario = conexao.Busca(usuretorno.Id);
            Assert.AreEqual(usuretorno.Id, usuario.Id, "Não foi possivel localizar o usuário");
        }

        [TestMethod]
        public void AtualizaUsuario()
        {
            var usuretorno = conexao.Grava(usuario);
            usuario = conexao.Busca(usuretorno.Id);

            var email = "flavio.barbosa@autoglass.com.br";
            usuario.Email = email;
            var retorno = conexao.Grava(usuario);

            Assert.AreEqual(email, retorno.Email, "Não foi possivel atualizar o usuario");
        }

        [TestMethod]
        public void BuscaListadeUsuarios()
        {

            conexao.Grava(usuario);
            conexao.Grava(usuario);
            var lista = conexao.ListaUsuario();

            Assert.IsNotNull(lista, "A lista não contem os dois itens necessários");
        }
    }
}
