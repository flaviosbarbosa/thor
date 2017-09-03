using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using elroy.crusade.dominio;
using elroy.crusade.Infra;
using System.Collections.Generic;

namespace elroy.crusade.test
{
    [TestClass]
    public class OcorrenciaTest
    {
        public OcorrenciaTest()
        {
        }

        private Ocorrencia ocorrencia;
        private OcorrenciaBLL conexao;

        /// <summary>
        /// Monta a estrutura necessária para o teste
        /// </summary>
        [TestInitialize()]
        public void CriaOcorrencia()
        {
            this.ocorrencia = new Ocorrencia();
            ocorrencia.id = 0;
            var beneficiario = new BeneficiarioBLL().Grava(new Factory().CriaBeneficiario());

            ocorrencia.beneficiario = beneficiario;
            ocorrencia.codbeneficiario = beneficiario.id;
            ocorrencia.descricao = "Evento Social para a comunidade";
            ocorrencia.data = new DateTime(2017, 10, 12);
            ocorrencia.codigoorigem = 1;
            ocorrencia.tipo = "P";         

            this.conexao = new OcorrenciaBLL();
        }

        /// <summary>
        /// Limpa a tabela que está sendo testada
        /// </summary>
        [ClassCleanup()]
        public static void ZeraTabela()
        {
            IEnumerable<Ocorrencia> lista = new OcorrenciaBLL().ListaOcorrencia();
            foreach (var item in lista)
            {
                new OcorrenciaBLL().Deleta(item);
            }
        }

        [TestMethod]
        public void SalvandoOcorrencia()
        {
            var retorno = conexao.Grava(ocorrencia);
            Assert.IsNotNull(retorno.id, "Erro ao salvar Ocorrencia");
        }

        [TestMethod]
        public void BuscaOcorrenciaporCodigo()
        {
            var usuretorno = conexao.Grava(ocorrencia);
            ocorrencia = conexao.BuscaPorCodigo(usuretorno.id);
            Assert.AreEqual(usuretorno.id, ocorrencia.id, "Não foi possivel localizar o Ocorrencia");
        }

        [TestMethod]
        public void AtualizaOcorrencia()
        {
            var usuretorno = conexao.Grava(ocorrencia);
            ocorrencia = conexao.BuscaPorCodigo(usuretorno.id);

            var descricao = "Sem noção";
            ocorrencia.descricao = descricao;
            var retorno = conexao.Grava(ocorrencia);

            Assert.AreEqual(descricao, retorno.descricao, "Não foi possivel atualizar a Ocorrencia");
        }

        [TestMethod]
        public void BuscaListadeOcorrencias()
        {

            conexao.Grava(ocorrencia);
            conexao.Grava(ocorrencia);
            var lista = conexao.ListaOcorrencia();

            Assert.IsNotNull(lista, "A lista não contem os dois itens necessários");
        }
    }
}
