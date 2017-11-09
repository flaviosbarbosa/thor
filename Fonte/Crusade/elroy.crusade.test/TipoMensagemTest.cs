using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using elroy.crusade.dominio;
using elroy.crusade.Infra;
using System.Collections.Generic;
using elroy.crusade.dominio.Enum;

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
            tipoMensagem.Id = "";
            tipoMensagem.Descricao = "Pedido de Oração";
            tipoMensagem.Tipo = TrataMensagem.EntradaPedidoOracao;            

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
            Assert.IsNotNull(retorno.Id, "Erro ao salvar TipoMensagem");
        }

        [TestMethod]
        public void BuscaTipoMensagemporCodigo()
        {
            var usuretorno = conexao.Grava(tipoMensagem);
            tipoMensagem = conexao.Busca(usuretorno.Id);
            Assert.AreEqual(usuretorno.Id, tipoMensagem.Id, "Não foi possivel localizar o TipoMensagem");
        }

        [TestMethod]
        public void AtualizaTipoMensagem()
        {
            var usuretorno = conexao.Grava(tipoMensagem);
            tipoMensagem = conexao.Busca(usuretorno.Id);

            var tipo = TrataMensagem.EntradaContatoPastor;
            tipoMensagem.Tipo = tipo;
            var retorno = conexao.Grava(tipoMensagem);

            Assert.AreEqual(tipo, retorno.Tipo, "Não foi possivel atualizar o TipoMensagem");
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
