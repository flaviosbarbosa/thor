﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using elroy.crusade.dominio;
using elroy.crusade.Infra;
using System.Collections.Generic;

namespace elroy.crusade.test
{
    [TestClass]
    public class MinisterioTest
    {
        public MinisterioTest()
        {
        }

        private Ministerio ministerio;
        private MinisterioBLL conexao;
                
        [TestInitialize()]
        public void CriaMinisterio()
        {
            this.ministerio = new Ministerio();
            ministerio.beneficiario =  new BeneficiarioBLL().Grava(new Factory().CriaBeneficiario());

            ministerio.id = 0;
            ministerio.nome = "Louvor";
            ministerio.codResponsavel = ministerio.beneficiario.id;
            ministerio.descricao = "Ministerio de Louvor";                       

            this.conexao = new MinisterioBLL();
        }

        /// <summary>
        /// Limpa a tabela que está sendo testada
        /// </summary>
        [ClassCleanup()]
        public static void ZeraTabela()
        {
            IEnumerable<Ministerio> lista = new MinisterioBLL().ListaMinisterio();
            foreach (var item in lista)
            {
                new MinisterioBLL().Deleta(item);
            }
        }

        [TestMethod]
        public void SalvandoMinisterio()
        {
            var retorno = conexao.Grava(ministerio);
            Assert.IsNotNull(retorno.id, "Erro ao salvar ministerio");
        }

        [TestMethod]
        public void BuscaMinisterioporCodigo()
        {
            var ministerioretorno = conexao.Grava(ministerio);
            ministerio = conexao.BuscaPorCodigo(ministerioretorno.id);
            Assert.AreEqual(ministerioretorno.id, ministerio.id, "Não foi possivel localizar o ministerior");
        }

        [TestMethod]
        public void AtualizaMinisterio()
        {
            var usuretorno = conexao.Grava(ministerio);
            ministerio = conexao.BuscaPorCodigo(usuretorno.id);

            var nome = "flavio.barbosa@autoglass.com.br";
            ministerio.nome = nome;
            var retorno = conexao.Grava(ministerio);

            Assert.AreEqual(nome, retorno.nome, "Não foi possivel atualizar o Ministerio");
        }

        [TestMethod]
        public void BuscaListadeMinisterios()
        {

            conexao.Grava(ministerio);
            conexao.Grava(ministerio);
            var lista = conexao.ListaMinisterio();

            Assert.IsNotNull(lista, "A lista não contem os dois itens necessários");
        }
    }
}
