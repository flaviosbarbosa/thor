using elroy.crusade.bll;
using elroy.crusade.dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace elroy.crusade.test
{
    /// <summary>
    /// Summary description for ProfissaoTest
    /// </summary>
    [TestClass]
    public class ProfissaoTest
    {
        public ProfissaoTest()
        {
        }

        private Profissao profissao;
        private ProfissaoBLL conexao;

        [TestInitialize()]
        public void CriaProfissao()
        {
            this.profissao = new Profissao();
            profissao.Descricao = "Uber";
            profissao.Id = "";            

            this.conexao = new ProfissaoBLL();
        }

        /// <summary>
        /// Limpa a tabela que está sendo testada
        /// </summary>
        [ClassCleanup()]
        public static void ZeraTabela()
        {
            IEnumerable<Profissao> lista = new ProfissaoBLL().Busca();
            foreach (var item in lista)
            {
                new ProfissaoBLL().Deleta(item);
            }
        }

        [TestMethod]
        public void SalvandoProfissao()
        {
            var retorno = conexao.Grava(profissao);
            Assert.IsNotNull(retorno.Id, "Erro ao salvar profissão");
        }

        [TestMethod]
        public void BuscaProfissaoPorCodigo()
        {
            var profissaoretorno = conexao.Grava(profissao);
            profissao = conexao.Busca(profissaoretorno.Id);
            Assert.AreEqual(profissaoretorno.Id, profissao.Id, "Não foi possivel localizar o profissão");
        }

        [TestMethod]
        public void Atualizaprofissao()
        {
            var profissaoretorno = conexao.Grava(profissao);
            profissao = conexao.Busca(profissaoretorno.Id);

            var descricao = "UBER SELECT ";
            profissao.Descricao = descricao;
            var retorno = conexao.Grava(profissao);

            Assert.AreEqual(descricao, retorno.Descricao, "Não foi possivel atualizar o Profissão");
        }

        [TestMethod]
        public void BuscaListadeProfissoes()
        {

            conexao.Grava(profissao);
            conexao.Grava(profissao);
            var lista = conexao.Busca();

            Assert.IsNotNull(lista, "A lista não contem os dois itens necessários");
        }
        
    }
}
