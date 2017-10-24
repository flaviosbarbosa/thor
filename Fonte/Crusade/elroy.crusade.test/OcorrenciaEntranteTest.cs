using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using elroy.crusade.dominio;
using elroy.crusade.Infra;
using System.Collections.Generic;

namespace elroy.crusade.test
{
    [TestClass]
    public class OcorrenciaEntranteTest
    {
        public OcorrenciaEntranteTest()
        {
        }

        private OcorrenciaEntrante ocorrenciaEntrante;
        private OcorrenciaBLL conexao;

        /// <summary>
        /// Monta a estrutura necessária para o teste
        /// </summary>
        [TestInitialize()]
        public void CriaOcorrencia()
        {
            this.ocorrenciaEntrante = new OcorrenciaEntrante();
            ocorrenciaEntrante.Id = 0;
            var beneficiario = new BeneficiarioBLL().Grava(new Factory().CriaBeneficiario());

            ocorrenciaEntrante.Responsavel = beneficiario;
            ocorrenciaEntrante.CodResponsavel = beneficiario.Id;
            ocorrenciaEntrante.Descricao = "Evento Social para a comunidade";
            ocorrenciaEntrante.Data = new DateTime(2017, 10, 12);          
            

            this.conexao = new OcorrenciaBLL();
        }

        /// <summary>
        /// Limpa a tabela que está sendo testada
        /// </summary>
        [ClassCleanup()]
        public static void ZeraTabela()
        {
            IEnumerable<OcorrenciaEntrante> lista = new OcorrenciaBLL().ListaOcorrencia();
            foreach (var item in lista)
            {
                new OcorrenciaBLL().Deleta(item);
            }
        }

        [TestMethod]
        public void SalvandoOcorrencia()
        {
            var retorno = conexao.Grava(ocorrenciaEntrante);
            Assert.IsNotNull(retorno.Id, "Erro ao salvar Ocorrencia");
        }

        [TestMethod]
        public void BuscaOcorrenciaporCodigo()
        {
            var usuretorno = conexao.Grava(ocorrenciaEntrante);
            ocorrenciaEntrante = conexao.BuscaPorCodigo(usuretorno.Id);
            Assert.AreEqual(usuretorno.Id, ocorrenciaEntrante.Id, "Não foi possivel localizar o Ocorrencia");
        }

        [TestMethod]
        public void AtualizaOcorrencia()
        {
            var usuretorno = conexao.Grava(ocorrenciaEntrante);
            ocorrenciaEntrante = conexao.BuscaPorCodigo(usuretorno.Id);

            var descricao = "Sem noção";
            ocorrenciaEntrante.Descricao = descricao;
            var retorno = conexao.Grava(ocorrenciaEntrante);

            Assert.AreEqual(descricao, retorno.Descricao, "Não foi possivel atualizar a Ocorrencia");
        }

        [TestMethod]
        public void BuscaListadeOcorrencias()
        {
            conexao.Grava(ocorrenciaEntrante);
            conexao.Grava(ocorrenciaEntrante);
            var lista = conexao.ListaOcorrencia();

            Assert.IsNotNull(lista, "A lista não contem os dois itens necessários");
        }
    }
}
