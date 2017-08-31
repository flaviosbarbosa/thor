using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using elroy.crusade.dominio;
using elroy.crusade.Infra;
using System.Collections.Generic;

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
            this.mensagemEntrante = new MensagemEntrante();
            
            mensagemEntrante.tipoMensagem = new TipoMensagemBLL().Grava(new Factory().CriaTipoMensagem());
                        
            mensagemEntrante.codTipoMensagem = mensagemEntrante.tipoMensagem.id;
            mensagemEntrante.dataContato = DateTime.Now;
            mensagemEntrante.assunto = "";
            mensagemEntrante.emailContato = "";
            mensagemEntrante.frequenta = "S";
            mensagemEntrante.mensagem = "Orem por mim";
            mensagemEntrante.nomeSolicitante = "Joaquim Jose da Silva Xavier";
            mensagemEntrante.permiteRetorno = "S";
            mensagemEntrante.telefoneContato = "27992969013";

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
            Assert.IsNotNull(retorno.id, "Erro ao salvar MensagemEntrante");
        }

        [TestMethod]
        public void BuscaMensagemEntranteporCodigo()
        {
            var MensagemEntranteretorno = conexao.Grava(mensagemEntrante);
            mensagemEntrante = conexao.BuscaPorCodigo(MensagemEntranteretorno.id);
            Assert.AreEqual(MensagemEntranteretorno.id, mensagemEntrante.id, "Não foi possivel localizar o MensagemEntranter");
        }

        [TestMethod]
        public void AtualizaMensagemEntrante()
        {
            var MEretorno = conexao.Grava(mensagemEntrante);
            mensagemEntrante = conexao.BuscaPorCodigo(MEretorno.id);

            var mensagem = "Dia de lazer e cultura";
            mensagemEntrante.mensagem = mensagem;
            var retorno = conexao.Grava(mensagemEntrante);

            Assert.AreEqual(mensagem, retorno.mensagem, "Não foi possivel atualizar o MensagemEntrante");
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