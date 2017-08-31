using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using elroy.crusade.dominio;
using elroy.crusade.Infra;
using System.Collections.Generic;

namespace elroy.crusade.test
{
    [TestClass]
    public class TipoMensagemTest
    {
        private TipoMensagem tipoMensagem;
        private TipoMensagemBLL conexao;

        /// <summary>
        /// Monta a estrutura necessária para o teste
        /// </summary>
        [TestInitialize()]
        public void CriaTipoMensagem()
        {
            this.tipoMensagem = new TipoMensagem();
            tipoMensagem.id = 0;
            tipoMensagem.descricao = "Pedido de Oração";
            tipoMensagem.tipo = "P";            

            this.conexao = new TipoMensagemBLL();
        }

        /// <summary>
        /// Limpa a tabela que está sendo testada
        /// </summary>
        [ClassCleanup()]
        public static void ZeraTabela()
        {
            IEnumerable<TipoMensagem> lista = new TipoMensagemBLL().ListaTipoMensagem();
            foreach (var item in lista)
            {
                new TipoMensagemBLL().Deleta(item);
            }
        }

        [TestMethod]
        public void SalvandoTipoMensagem()
        {
            var retorno = conexao.Grava(tipoMensagem);
            Assert.IsNotNull(retorno.id, "Erro ao salvar TipoMensagem");
        }

        [TestMethod]
        public void BuscaTipoMensagemporCodigo()
        {
            var usuretorno = conexao.Grava(tipoMensagem);
            tipoMensagem = conexao.BuscaPorCodigo(usuretorno.id);
            Assert.AreEqual(usuretorno.id, tipoMensagem.id, "Não foi possivel localizar o TipoMensagem");
        }

        [TestMethod]
        public void AtualizaTipoMensagem()
        {
            var usuretorno = conexao.Grava(tipoMensagem);
            tipoMensagem = conexao.BuscaPorCodigo(usuretorno.id);

            var tipo = "A";
            tipoMensagem.tipo = tipo;
            var retorno = conexao.Grava(tipoMensagem);

            Assert.AreEqual(tipo, retorno.tipo, "Não foi possivel atualizar o TipoMensagem");
        }

        [TestMethod]
        public void BuscaListadeTipoMensagems()
        {
            conexao.Grava(tipoMensagem);
            conexao.Grava(tipoMensagem);
            var lista = conexao.ListaTipoMensagem();

            Assert.IsNotNull(lista, "A lista não contem os dois itens necessários");
        }
    }
}
