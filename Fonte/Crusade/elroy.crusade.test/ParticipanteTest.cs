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
    /// Descrição resumida para ParticipanteTest
    /// </summary>
    [TestClass]
    public class ParticipanteTest
    {
        private Participantes participante;
        private ParticipanteBLL conexao;

        /// <summary>
        /// Monta a estrutura necessária para o teste
        /// </summary>
        [TestInitialize()]
        public void CriParticipantes()
        {
          this.participante = new Factory().CriaParticipantes();            
          this.conexao = new ParticipanteBLL();
        }

        /// <summary>
        /// Limpa a tabela que está sendo testada
        /// </summary>
        [ClassCleanup()]
        public static void ZeraTabela()
        {
            IEnumerable<Participantes> lista = new ParticipanteBLL().ListaParticipante();
            foreach (var item in lista)
            {
                new ParticipanteBLL().Deleta(item);
            }
        }

        [TestMethod]
        public void SalvandoParticipante()
        {
            var retorno = conexao.Grava(participante);
            Assert.IsNotNull(retorno.Id, "Erro ao salvar Participante");
        }

        [TestMethod]
        public void BuscaParticipanteporCodigo()
        {
            //TODO: Revisar todos os retornos da BLL para em caso de erro não retonar um objeto nulo mas retorna outra coisa
            // que permita executarmos um teste válido.
            var partiretorno = conexao.Grava(participante);
            participante = conexao.BuscaPorCodigo(partiretorno.Id);
            Assert.AreEqual(partiretorno.Id, participante.Id, "Não foi possivel localizar o participante");
        }

        [TestMethod]
        public void AtualizaParticipante()
        {
            var partiretorno = conexao.Grava(participante);
            participante = conexao.BuscaPorCodigo(partiretorno.Id);

            var lembrete = SimNao.Nao;
            participante.Lembrete = lembrete;
            var retorno = conexao.Grava(participante);

            Assert.AreEqual(lembrete, retorno.Lembrete, "Não foi possivel atualizar o Participante");
        }

        [TestMethod]
        public void BuscaListadeParticipantes()
        {
            conexao.Grava(participante);
            conexao.Grava(participante);
            var lista = conexao.ListaParticipante();

            Assert.IsNotNull(lista, "A lista não contem os dois itens necessários");
        }
    }
}
