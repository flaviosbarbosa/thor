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
            parametro.id = 0;
            //Parametro.banner = "Flavio";
            parametro.exibirLocalizacao = "S";
            parametro.localizacao = "509040 809040";            

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
                if (item.id > 1)
                  new ParametroBLL().Deleta(item);
            }
        }

        [TestMethod]
        public void SalvandoParametro()
        {
            var retorno = conexao.Grava(parametro);
            Assert.IsNotNull(retorno.id, "Erro ao salvar Parametro");
        }

        [TestMethod]
        public void BuscaParametroporCodigo()
        {
            var usuretorno = conexao.Grava(parametro);
            parametro = conexao.BuscaPorCodigo(usuretorno.id);
            Assert.AreEqual(usuretorno.id, parametro.id, "Não foi possivel localizar o Parametro");
        }

        [TestMethod]
        public void AtualizaParametro()
        {
            var usuretorno = conexao.Grava(parametro);
            parametro = conexao.BuscaPorCodigo(usuretorno.id);

            var exibir = "N";
            parametro.exibirLocalizacao = exibir;
            var retorno = conexao.Grava(parametro);

            Assert.AreEqual(exibir, retorno.exibirLocalizacao, "Não foi possivel atualizar o Parametro");
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
