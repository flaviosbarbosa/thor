﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using elroy.crusade.dominio;
using elroy.crusade.Infra;
using System.Collections.Generic;

namespace elroy.crusade.test
{
    [TestClass]
    public class BeneficiarioTest
    {
        public BeneficiarioTest()
        {
        }

        private Beneficiario beneficiario;
        private BeneficiarioBLL conexao;

        /// <summary>
        /// Monta a estrutura necessária para o teste
        /// </summary>
        [TestInitialize()]
        public void CriaBeneficiario()
        {
            this.beneficiario = new Factory().CriaBeneficiario();            

            this.conexao = new BeneficiarioBLL();
        }

        /// <summary>
        /// Limpa a tabela que está sendo testada
        /// </summary>
        [ClassCleanup()]
        public static void ZeraTabela()
        {
            IEnumerable<Beneficiario> lista = new BeneficiarioBLL().ListaBeneficiario();
            foreach (var item in lista)
            {
                new BeneficiarioBLL().Deleta(item);
            }
        }

        [TestMethod]
        public void SalvandoBeneficiario()
        {
            var retorno = conexao.Grava(beneficiario);
            Assert.IsNotNull(retorno.id, "Erro ao salvar usuário");
        }

        [TestMethod]
        public void BuscaBeneficiarioporCodigo()
        {
            var usuretorno = conexao.Grava(beneficiario);
            beneficiario = conexao.BuscaPorCodigo(usuretorno.id);
            Assert.AreEqual(usuretorno.id, beneficiario.id, "Não foi possivel localizar o usuário");
        }

        [TestMethod]
        public void AtualizaBeneficiario()
        {
            var usuretorno = conexao.Grava(beneficiario);
            beneficiario = conexao.BuscaPorCodigo(usuretorno.id);

            var email = "flavio.barbosa@autoglass.com.br";
            beneficiario.email = email;
            var retorno = conexao.Grava(beneficiario);

            Assert.AreEqual(email, retorno.email, "Não foi possivel atualizar o Beneficiario");
        }

        [TestMethod]
        public void BuscaListadeBeneficiarios()
        {

            conexao.Grava(beneficiario);
            conexao.Grava(beneficiario);
            var lista = conexao.ListaBeneficiario();

            Assert.IsNotNull(lista, "A lista não contem os dois itens necessários");
        }
    }
}
