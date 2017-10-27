using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using elroy.crusade.dominio;
using elroy.crusade.bll;
using elroy.crusade.dominio.Enum;

namespace elroy.crusade.test
{
    /// <summary>
    /// Descrição resumida para PedidoOracaoTest
    /// </summary>
    [TestClass]
    public class PedidoOracaoTest
    {
        private PedidoOracao pedidoOracao;
        private PedidoOracaoBLL conexao;

        /// <summary>
        /// Monta a estrutura necessária para o teste
        /// </summary>
        [TestInitialize()]
        public void CriaPedidoOracao()
        {
            this.pedidoOracao = new Factory().CriaPedidoOracao();            

            this.conexao = new PedidoOracaoBLL();
        }

        /// <summary>
        /// Limpa a tabela que está sendo testada
        /// </summary>
        [ClassCleanup()]
        public static void ZeraTabela()
        {
            IEnumerable<PedidoOracao> lista = new PedidoOracaoBLL().ListaPedidoOracao();
            foreach (var item in lista)
            {
                new PedidoOracaoBLL().Deleta(item);
            }
        }

        [TestMethod]
        public void SalvandoPedidoOracao()
        {
            var retorno = conexao.Grava(pedidoOracao);
            Assert.IsNotNull(retorno.Id, "Erro ao salvar PedidoOracao");
        }

        [TestMethod]
        public void BuscaPedidoOracaoporCodigo()
        {
            var pedidoretorno = conexao.Grava(pedidoOracao);
            pedidoOracao = conexao.BuscaPorCodigo(pedidoretorno.Id);
            Assert.AreEqual(pedidoretorno.Id, pedidoOracao.Id, "Não foi possivel localizar o Pedido de Oracao");
        }

        [TestMethod]
        public void AtualizaPedidoOracao()
        {
            var pedidoretorno = conexao.Grava(pedidoOracao);
            pedidoOracao = conexao.BuscaPorCodigo(pedidoretorno.Id);

            var descricao = "alterando descrição do pedido de oração";
            pedidoOracao.Descricao = descricao;
            var retorno = conexao.Grava(pedidoOracao);

            Assert.AreEqual(descricao, retorno.Descricao, "Não foi possivel atualizar o PedidoOracao");
        }

        [TestMethod]
        public void BuscaListadePedidoOracaos()
        {
            conexao.Grava(pedidoOracao);
            conexao.Grava(pedidoOracao);
            var lista = conexao.ListaPedidoOracao();

            Assert.IsNotNull(lista, "A lista não contem os dois itens necessários");
        }
    }
}
