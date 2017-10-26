using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using elroy.crusade.dominio;
using elroy.crusade.Infra;
using System.Collections.Generic;

namespace elroy.crusade.test
{
    [TestClass]
    public class MensagemSainteTest
    {

        private MensagemSainte mensagemsainte;
        private MensagemSainteBLL conexao;

        [TestInitialize()]
        public void CriaMensagemSainte()
        {
            this.mensagemsainte = new MensagemSainte();

            mensagemsainte.Ministerio = new MinisterioBLL().Grava(new Factory().CriaMinisterio());
            mensagemsainte.TipoMensagem = new TipoMensagemBLL().Grava(new Factory().CriaTipoMensagem());
            mensagemsainte.MensagemEntrante = new MensagemEntranteBLL().Grava(new Factory().CriaMensagemEntrante());
            mensagemsainte.CodMensagemEntrante = mensagemsainte.MensagemEntrante.Id;
            mensagemsainte.CodMinisterio = mensagemsainte.Ministerio.Id;
            mensagemsainte.CodTipoMensagem = mensagemsainte.TipoMensagem.Id;
            mensagemsainte.DataEnvio = DateTime.Now;
            mensagemsainte.Mensagem = "Ensaio no sabado";

            this.conexao = new MensagemSainteBLL();
        }

        /// <summary>
        /// Limpa a tabela que está sendo testada
        /// </summary>
        [ClassCleanup()]
        public static void ZeraTabela()
        {
            IEnumerable<MensagemSainte> lista = new MensagemSainteBLL().ListaMensagemSainte();
            foreach (var item in lista)
            {
                new MensagemSainteBLL().Deleta(item);
            }
        }

        [TestMethod]
        public void SalvandoMensagemSainte()
        {
            var retorno = conexao.Grava(mensagemsainte);
            Assert.IsNotNull(retorno.Id, "Erro ao salvar MensagemSainte");
        }

        [TestMethod]
        public void BuscaMensagemSainteporCodigo()
        {
            var MensagemSainteretorno = conexao.Grava(mensagemsainte);
            mensagemsainte = conexao.BuscaPorCodigo(MensagemSainteretorno.Id);
            Assert.AreEqual(MensagemSainteretorno.Id, mensagemsainte.Id, "Não foi possivel localizar o MensagemSainter");
        }

        [TestMethod]
        public void AtualizaMensagemSainte()
        {
            var usuretorno = conexao.Grava(mensagemsainte);
            mensagemsainte = conexao.BuscaPorCodigo(usuretorno.Id);

            var mensagem = "Dia de lazer e cultura";
            mensagemsainte.Mensagem = mensagem;
            var retorno = conexao.Grava(mensagemsainte);

            Assert.AreEqual(mensagem, retorno.Mensagem, "Não foi possivel atualizar o MensagemSainte");
        }

        [TestMethod]
        public void BuscaListadeMensagemSaintes()
        {
            conexao.Grava(mensagemsainte);
            conexao.Grava(mensagemsainte);
            var lista = conexao.ListaMensagemSainte();

            Assert.IsNotNull(lista, "A lista não contem os dois itens necessários");
        }
    }
}