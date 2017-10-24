using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using elroy.crusade.dominio;
using elroy.crusade.Infra;
using System.Collections.Generic;
using elroy.crusade.dominio.Enum;

namespace elroy.crusade.test
{
    [TestClass]
    public class IntegrantesTest
    {
        public IntegrantesTest()
        {
        }

        private Integrantes integrantes;
        private IntegrantesBLL conexao;

        /// <summary>
        /// Monta a estrutura necessária para o teste
        /// </summary>
        [TestInitialize()]
        public void CriaIntegrantes()
        {
            this.integrantes = new Integrantes();

            var beneficiario = new Factory().CriaBeneficiario();
            beneficiario = new BeneficiarioBLL().Grava(beneficiario);

            var ministerio = new Factory().CriaMinisterio();
            ministerio.Responsavel = beneficiario;
            ministerio.CodResponsavel = beneficiario.Id;
            ministerio = new MinisterioBLL().Grava(ministerio);

            integrantes.Id = 0;
            integrantes.Beneficiario = beneficiario;
            integrantes.CodBeneficiario = integrantes.Beneficiario.Id;
            integrantes.Ministerio = ministerio;
            integrantes.CodMinisterio = integrantes.Ministerio.Id;
            integrantes.Ativo = SimNao.Sim;            

            this.conexao = new IntegrantesBLL();
        }

        /// <summary>
        /// Limpa a tabela que está sendo testada
        /// </summary>
        [ClassCleanup()]
        public static void ZeraTabela()
        {
            IEnumerable<Integrantes> lista = new IntegrantesBLL().ListaIntegrantes();            
            foreach (var item in lista)
            {
                new IntegrantesBLL().Deleta(item);
            }
        }

        [TestMethod]
        public void SalvandoIntegrantes()
        {
            var retorno = conexao.Grava(integrantes);
            Assert.IsNotNull(retorno.Id, "Erro ao salvar Integrante");
        }

        [TestMethod]
        public void BuscaIntegrantesporCodigo()
        {
            var usuretorno = conexao.Grava(integrantes);
            integrantes = conexao.BuscaPorCodigo(usuretorno.Id);
            Assert.AreEqual(usuretorno.Id, integrantes.Id, "Não foi possivel localizar o Integrante");
        }

        [TestMethod]
        public void AtualizaIntegrantes()
        {
            var intretorno = conexao.Grava(integrantes);
            integrantes = conexao.BuscaPorCodigo(intretorno.Id);

            var ativo = SimNao.Sim;
            integrantes.Ativo = ativo;
            var retorno = conexao.Grava(integrantes);

            Assert.AreEqual(ativo, retorno.Ativo, "Não foi possivel atualizar o Integrantes");
        }

        [TestMethod]
        public void BuscaListadeIntegrantess()
        {

            conexao.Grava(integrantes);
            conexao.Grava(integrantes);
            var lista = conexao.ListaIntegrantes();

            Assert.IsNotNull(lista, "A lista não contem os dois itens necessários");
        }
    }
}
