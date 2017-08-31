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

            mensagemsainte.ministerio = new MinisterioBLL().Grava(new Factory().CriaMinisterio());
            mensagemsainte.tipoMensagem = new TipoMensagemBLL().Grava(new Factory().CriaTipoMensagem());

            mensagemsainte.codMinisterio = mensagemsainte.ministerio.id;
            mensagemsainte.codTipoMensagem = mensagemsainte.tipoMensagem.id;
            mensagemsainte.dataEnvio = DateTime.Now;
            mensagemsainte.mensagem = "Ensaio no sabado";

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
            Assert.IsNotNull(retorno.id, "Erro ao salvar MensagemSainte");
        }

        [TestMethod]
        public void BuscaMensagemSainteporCodigo()
        {
            var MensagemSainteretorno = conexao.Grava(mensagemsainte);
            mensagemsainte = conexao.BuscaPorCodigo(MensagemSainteretorno.id);
            Assert.AreEqual(MensagemSainteretorno.id, mensagemsainte.id, "Não foi possivel localizar o MensagemSainter");
        }

        [TestMethod]
        public void AtualizaMensagemSainte()
        {
            var usuretorno = conexao.Grava(mensagemsainte);
            mensagemsainte = conexao.BuscaPorCodigo(usuretorno.id);

            var mensagem = "Dia de lazer e cultura";
            mensagemsainte.mensagem = mensagem;
            var retorno = conexao.Grava(mensagemsainte);

            Assert.AreEqual(mensagem, retorno.mensagem, "Não foi possivel atualizar o MensagemSainte");
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