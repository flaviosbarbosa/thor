using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using elroy.crusade.dominio;
using elroy.crusade.Infra;

namespace elroy.crusade.test
{
    [TestClass]
    public class EventosTest
    {
        public EventosTest()
        {
        }

        private Eventos eventos;
        private EventosBLL conexao;

        /// <summary>
        /// Monta a estrutura necessária para o teste
        /// </summary>
        [TestInitialize()]
        public void CriaEventos()
        {
            this.eventos = new Eventos();
            eventos.id = 0;
            //eventos.banner = "Flavio";
            eventos.titulo = "Dia de Lazer e Cultura";
            eventos.descricao = "Evento Social para a comunidade";
            eventos.data = new DateTime(2017, 10, 12);
            eventos.local = "Igreja Presbiteriana Praia de Itapoã";
            eventos.horario = new DateTime(2017, 10, 12, 17, 00, 00);
            eventos.pastorPresente = "S";
            eventos.privado = "N";
            eventos.ministerio = new Factory().CriaMinisterio();
            eventos.codMinisterio = eventos.ministerio.id;

            this.conexao = new EventosBLL();
        }

        /// <summary>
        /// Limpa a tabela que está sendo testada
        /// </summary>
        [ClassCleanup()]
        public static void ZeraTabela()
        {
            IEnumerable<Eventos> lista = new EventosBLL().ListaEventos();
            foreach (var item in lista)
            {
                new EventosBLL().Deleta(item);
            }
        }

        [TestMethod]
        public void SalvandoEventos()
        {
            var retorno = conexao.Grava(eventos);
            Assert.IsNotNull(retorno.id, "Erro ao salvar Evento");
        }

        [TestMethod]
        public void BuscaEventosporCodigo()
        {
            var usuretorno = conexao.Grava(eventos);
            eventos = conexao.BuscaPorCodigo(usuretorno.id);
            Assert.AreEqual(usuretorno.id, eventos.id, "Não foi possivel localizar o Evento");
        }

        [TestMethod]
        public void AtualizaEventos()
        {
            var usuretorno = conexao.Grava(eventos);
            eventos = conexao.BuscaPorCodigo(usuretorno.id);

            var pastorpresente = "S";
            eventos.pastorPresente = pastorpresente;
            var retorno = conexao.Grava(eventos);

            Assert.AreEqual(pastorpresente, retorno.pastorPresente, "Não foi possivel atualizar o Eventos");
        }

        [TestMethod]
        public void BuscaListadeEventoss()
        {

            conexao.Grava(eventos);
            conexao.Grava(eventos);
            var lista = conexao.ListaEventos();

            Assert.IsNotNull(lista, "A lista não contem os dois itens necessários");
        }
    }
}
