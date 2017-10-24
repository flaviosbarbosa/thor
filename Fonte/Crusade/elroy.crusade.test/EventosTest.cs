﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using elroy.crusade.dominio;
using elroy.crusade.Infra;
using elroy.crusade.dominio.Enum;

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
            eventos.Id = 0;
            //eventos.banner = "Flavio";
            eventos.Titulo = "Dia de Lazer e Cultura";
            eventos.Descricao = "Evento Social para a comunidade";
            eventos.Data = new DateTime(2017, 10, 12);
            eventos.Local = "Igreja Presbiteriana Praia de Itapoã";
            eventos.horario = new DateTime(2017, 10, 12, 17, 00, 00);
            eventos.PastorPresente = SimNao.Sim;
            eventos.Privado = SimNao.Nao;
            eventos.Ministerio = new Factory().CriaMinisterio();
            eventos.CodMinisterio = eventos.Ministerio.Id;

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
            Assert.IsNotNull(retorno.Id, "Erro ao salvar Evento");
        }

        [TestMethod]
        public void BuscaEventosporCodigo()
        {
            var usuretorno = conexao.Grava(eventos);
            eventos = conexao.BuscaPorCodigo(usuretorno.Id);
            Assert.AreEqual(usuretorno.Id, eventos.Id, "Não foi possivel localizar o Evento");
        }

        [TestMethod]
        public void AtualizaEventos()
        {
            var usuretorno = conexao.Grava(eventos);
            eventos = conexao.BuscaPorCodigo(usuretorno.Id);

            var pastorpresente = SimNao.Sim; 
            eventos.PastorPresente = pastorpresente;
            var retorno = conexao.Grava(eventos);

            Assert.AreEqual(pastorpresente, retorno.PastorPresente, "Não foi possivel atualizar o Eventos");
        }

        //[TestMethod]
        //public void BuscaListadeEventoss()
        //{

        //    conexao.Grava(eventos);
        //    conexao.Grava(eventos);
        //    var lista = conexao.ListaEventos();

        //    Assert.IsNotNull(lista, "A lista não contem os dois itens necessários");
        //}
    }
}
