using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using elroy.crusade.dominio;
using elroy.crusade.Infra;
using System.Collections.Generic;

namespace elroy.crusade.test
{
    [TestClass]
    public class AgendaPastoralTest
    {
        
        public AgendaPastoralTest()
        {

        }

        private AgendaPastoral agenda;
        private AgendaPastoralBLL conexao;

        [TestInitialize]
        public void CriaAgenda()
        {
            this.agenda = new AgendaPastoral();
            agenda.evento = "Culto Vespertino";
            agenda.data =  DateTime.Now;
            //agenda.horarioInicial = DateTime.Now;
            //agenda.horarioFinal = DateTime.Today;
            agenda.local = "IPPI";
            agenda.privado = "S";

            this.conexao = new AgendaPastoralBLL();
        }

        /// <summary>
        /// Limpa a tabela que está sendo testada
        /// </summary>
        [ClassCleanup()]
        public static void ZeraTabela()
        {
            IEnumerable<AgendaPastoral> lista = new AgendaPastoralBLL().ListaAgendaPastoral();
            foreach (var item in lista)
            {
                new AgendaPastoralBLL().Deleta(item);
            }
        }

        [TestMethod]
        public void SalvandoAgendaPastoral()
        {
            var retorno = conexao.Grava(agenda);
            Assert.IsNotNull(retorno, " Não salvou o registro");
        }

        [TestMethod]
        public void BuscaAgendaPastoralporCodigo()
        {
            var agendaretorno = conexao.Grava(agenda);
            agenda = conexao.BuscaPorCodigo(agendaretorno.id);
            Assert.AreEqual(agendaretorno.id, agenda.id, "Não foi possivel localizar o usuário");
        }

        [TestMethod]
        public void AtualizaAgendaPastoral()
        {
            var agendaretorno = conexao.Grava(agenda);
                        
            var local = "cerimonial fechado";
            agendaretorno.local = local;
            var retorno = conexao.Grava(agendaretorno);

            Assert.AreEqual(local, retorno.local, "Não foi possivel atualizar o AgendaPastoral");
        }

        [TestMethod]
        public void BuscaListadeAgendaPastorals()
        {

            conexao.Grava(agenda);
            conexao.Grava(agenda);
            var lista = conexao.ListaAgendaPastoral();

            Assert.IsNotNull(lista, "A lista não contem os dois itens necessários");
        }
    }
}
