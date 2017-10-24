using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using elroy.crusade.dominio;
using elroy.crusade.Infra;
using System.Collections.Generic;

namespace elroy.crusade.test
{
    [TestClass]
    public class MinisterioTest
    {
        public MinisterioTest()
        {
        }

        private Ministerio ministerio;
        private MinisterioBLL conexao;
                
        [TestInitialize()]
        public void CriaMinisterio()
        {
            this.ministerio = new Ministerio();
            ministerio.Responsavel =  new BeneficiarioBLL().Grava(new Factory().CriaBeneficiario());

            ministerio.Id = 0;
            ministerio.Nome = "Louvor";
            ministerio.CodResponsavel = ministerio.Responsavel.Id;
            ministerio.Descricao = "Ministerio de Louvor";                       

            this.conexao = new MinisterioBLL();
        }

        /// <summary>
        /// Limpa a tabela que está sendo testada
        /// </summary>
        [ClassCleanup()]
        public static void ZeraTabela()
        {
            IEnumerable<Ministerio> lista = new MinisterioBLL().ListaMinisterio();
            foreach (var item in lista)
            {
                new MinisterioBLL().Deleta(item);
            }
        }

        [TestMethod]
        public void SalvandoMinisterio()
        {
            var retorno = conexao.Grava(ministerio);
            Assert.IsNotNull(retorno.Id, "Erro ao salvar ministerio");
        }

        [TestMethod]
        public void BuscaMinisterioporCodigo()
        {
            var ministerioretorno = conexao.Grava(ministerio);
            ministerio = conexao.BuscaPorCodigo(ministerioretorno.Id);
            Assert.AreEqual(ministerioretorno.Id, ministerio.Id, "Não foi possivel localizar o ministerior");
        }

        [TestMethod]
        public void AtualizaMinisterio()
        {
            var usuretorno = conexao.Grava(ministerio);
            ministerio = conexao.BuscaPorCodigo(usuretorno.Id);

            var nome = "flavio.barbosa@autoglass.com.br";
            ministerio.Nome = nome;
            var retorno = conexao.Grava(ministerio);

            Assert.AreEqual(nome, retorno.Nome, "Não foi possivel atualizar o Ministerio");
        }

        [TestMethod]
        public void BuscaListadeMinisterios()
        {

            conexao.Grava(ministerio);
            conexao.Grava(ministerio);
            var lista = conexao.ListaMinisterio();

            Assert.IsNotNull(lista, "A lista não contem os dois itens necessários");
        }
    }
}
