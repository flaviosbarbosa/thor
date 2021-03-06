﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using elroy.crusade.dominio;
using elroy.crusade.Infra;
using System.Collections.Generic;

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
            ministerio.beneficiario = beneficiario;
            ministerio.codResponsavel = beneficiario.id;
            ministerio = new MinisterioBLL().Grava(ministerio);

            integrantes.id = 0;
            integrantes.beneficiario = beneficiario;
            integrantes.codBeneficiario = integrantes.beneficiario.id;
            integrantes.ministerio = ministerio;
            integrantes.codMinisterio = integrantes.ministerio.id;
            integrantes.ativo = "S";            

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
            Assert.IsNotNull(retorno.id, "Erro ao salvar Integrante");
        }

        [TestMethod]
        public void BuscaIntegrantesporCodigo()
        {
            var usuretorno = conexao.Grava(integrantes);
            integrantes = conexao.BuscaPorCodigo(usuretorno.id);
            Assert.AreEqual(usuretorno.id, integrantes.id, "Não foi possivel localizar o Integrante");
        }

        [TestMethod]
        public void AtualizaIntegrantes()
        {
            var intretorno = conexao.Grava(integrantes);
            integrantes = conexao.BuscaPorCodigo(intretorno.id);

            var ativo = "N";
            integrantes.ativo = ativo;
            var retorno = conexao.Grava(integrantes);

            Assert.AreEqual(ativo, retorno.ativo, "Não foi possivel atualizar o Integrantes");
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
