using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using elroy.crusade.dominio;
using elroy.crusade.Infra;
using System.Collections.Generic;

namespace elroy.crusade.test
{
    [TestClass]
    public class ParametrosTest
    {
        public ParametrosTest()
        {
        }

        private Parametros parametro;
        private ParametroBLL conexao;

        /// <summary>
        /// Monta a estrutura necessária para o teste
        /// </summary>
        [TestInitialize()]
        public void CriaParametro()
        {
            this.parametro = new Parametros();
            parametro.Id = "";
            //Parametro.banner = "Flavio";
            parametro.ExibirLocalizacao = "S";
            parametro.Localizacao = "509040 809040";            

            this.conexao = new ParametroBLL();
        }

        /// <summary>
        /// Limpa a tabela que está sendo testada
        /// </summary>
        [ClassCleanup()]
        public static void ZeraTabela()
        {
            IEnumerable<Parametros> lista = new ParametroBLL().ListaParametro();
            foreach (var item in lista)
            {
                // mantem um registro de parametro                
                new ParametroBLL().Deleta(item);
            }
        }

        [TestMethod]
        public void SalvandoParametro()
        {
            var retorno = conexao.Grava(parametro);
            Assert.IsNotNull(retorno.Id, "Erro ao salvar Parametro");
        }

        [TestMethod]
        public void BuscaParametroporCodigo()
        {
            var usuretorno = conexao.Grava(parametro);
            parametro = conexao.Busca(usuretorno.Id);
            Assert.AreEqual(usuretorno.Id, parametro.Id, "Não foi possivel localizar o Parametro");
        }

        [TestMethod]
        public void AtualizaParametro()
        {
            var usuretorno = conexao.Grava(parametro);
            parametro = conexao.Busca(usuretorno.Id);

            var exibir = "N";
            parametro.ExibirLocalizacao = exibir;
            var retorno = conexao.Grava(parametro);

            Assert.AreEqual(exibir, retorno.ExibirLocalizacao, "Não foi possivel atualizar o Parametro");
        }

        [TestMethod]
        public void BuscaListadeParametros()
        {

            conexao.Grava(parametro);
            conexao.Grava(parametro);
            var lista = conexao.ListaParametro();

            Assert.IsNotNull(lista, "A lista não contem os dois itens necessários");
        }
    }
}
