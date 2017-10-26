using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using elroy.crusade.dominio;
using elroy.crusade.Infra;
using System.Collections.Generic;
using elroy.crusade.dominio.Enum;

namespace elroy.crusade.test
{
    [TestClass]
    public class MensagemEntranteTest
    {
        private MensagemEntrante mensagemEntrante;
        private MensagemEntranteBLL conexao;

        [TestInitialize()]
        public void CriaMensagemEntrante()
        {
            this.mensagemEntrante = new Factory().CriaMensagemEntrante();
            this.conexao = new MensagemEntranteBLL();
        }

        /// <summary>
        /// Limpa a tabela que está sendo testada
        /// </summary>
        [ClassCleanup()]
        public static void ZeraTabela()
        {
            IEnumerable<MensagemEntrante> lista = new MensagemEntranteBLL().ListaMensagemEntrante();
            foreach (var item in lista)
            {
                new MensagemEntranteBLL().Deleta(item);
            }
        }

        [TestMethod]
        public void SalvandoMensagemEntrante()
        {
            var retorno = conexao.Grava(mensagemEntrante);
            Assert.IsNotNull(retorno.Id, "Erro ao salvar MensagemEntrante");
        }

        [TestMethod]
        public void BuscaMensagemEntranteporCodigo()
        {
            var MensagemEntranteretorno = conexao.Grava(mensagemEntrante);
            mensagemEntrante = conexao.BuscaPorCodigo(MensagemEntranteretorno.Id);
            Assert.AreEqual(MensagemEntranteretorno.Id, mensagemEntrante.Id, "Não foi possivel localizar o MensagemEntranter");
        }

        [TestMethod]
        public void AtualizaMensagemEntrante()
        {
            var MEretorno = conexao.Grava(mensagemEntrante);
            mensagemEntrante = conexao.BuscaPorCodigo(MEretorno.Id);

            var mensagem = "Dia de lazer e cultura";
            mensagemEntrante.Mensagem = mensagem;
            var retorno = conexao.Grava(mensagemEntrante);

            Assert.AreEqual(mensagem, retorno.Mensagem, "Não foi possivel atualizar o MensagemEntrante");
        }

        [TestMethod]
        public void BuscaListadeMensagemEntrantes()
        {
            conexao.Grava(mensagemEntrante);
            conexao.Grava(mensagemEntrante);
            var lista = conexao.ListaMensagemEntrante();

            Assert.IsNotNull(lista, "A lista não contem os dois itens necessários");
        }
    }
}