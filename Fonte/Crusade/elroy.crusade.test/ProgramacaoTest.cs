using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using elroy.crusade.dominio;
using elroy.crusade.Infra;
using System.Collections.Generic;

namespace elroy.crusade.test
{
    [TestClass]
    public class ProgramacaoTest
    {
        private Programacao programacao;
        private ProgramacaoBLL conexao;

        [TestInitialize]
        public void CriaAgenda()
        {          
            var igrejaretorno = new IgrejaBLL().Grava(new Factory().CriaIgreja());


            this.programacao = new Programacao();
            programacao.Descricao = "Culto Vespertino";
            programacao.Titulo = "Noite de Louvour";
            programacao.CodIgreja = igrejaretorno.Id;
            programacao.Igreja = igrejaretorno;

            this.conexao = new ProgramacaoBLL();
        }

        /// <summary>
        /// Limpa a tabela que está sendo testada
        /// </summary>
        [ClassCleanup()]
        public static void ZeraTabela()
        {
            IEnumerable<Programacao> lista = new ProgramacaoBLL().ListaProgramacao();
            foreach (var item in lista)
            {
                new ProgramacaoBLL().Deleta(item);
            }
        }
        

        [TestMethod]
        public void SalvandoProgramacao()
        {
            var retorno = conexao.Grava(programacao);
            Assert.IsNotNull(retorno, " Não salvou o registro");
        }

        [TestMethod]
        public void BuscaProgramacaoporCodigo()
        {
            var agendaretorno = conexao.Grava(programacao);
            programacao = conexao.Busca(agendaretorno.Id);
            Assert.AreEqual(agendaretorno.Id, programacao.Id, "Não foi possivel localizar o registro");
        }

        [TestMethod]
        public void AtualizaProgramacao()
        {
            var agendaretorno = conexao.Grava(programacao);

            var descricao = "novo local";
            agendaretorno.Descricao = descricao;
            var retorno = conexao.Grava(agendaretorno);

            Assert.AreEqual(descricao, retorno.Descricao, "Não foi possivel atualizar o Programacao");
        }

        [TestMethod]
        public void BuscaListadeProgramacaos()
        {
            conexao.Grava(programacao);
            conexao.Grava(programacao);
            var lista = conexao.ListaProgramacao();

            Assert.IsNotNull(lista, "A lista não contem os dois itens necessários");
        }
    }
}
