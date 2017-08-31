using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using elroy.crusade.dominio;
using elroy.crusade.Infra;
using System.Collections.Generic;

namespace elroy.crusade.test
{
    [TestClass]
    public class IgrejaTest
    {
  
        private Igreja igreja;
        private IgrejaBLL conexao;

        /// <summary>
        /// Monta a estrutura necessária para o teste
        /// </summary>
        [TestInitialize()]
        public void CriaIgreja()
        {
            this.igreja = new Igreja();
            igreja.id = 0;
            igreja.razaosocial = "Igreja da Gloria";
            igreja.nomefantasia= "Igreja da Gloria Divina";
            igreja.cnpj = "07354222000160";
            igreja.endereco = "Rua dos carvalhos, 123";
            igreja.numero = "150";
            igreja.telefone = "30251478";
            igreja.celular = "992966012";
            igreja.bairro = "Praia de Itapuã";
            igreja.cidade = "Vila Velha";
            igreja.CEP = "29101595";
            igreja.Responsavel = "Marcos Nolasco";
            igreja.uf = "ES";

            this.conexao = new IgrejaBLL();
        }

        /// <summary>
        /// Limpa a tabela que está sendo testada
        /// </summary>
        [ClassCleanup()]
        public static void ZeraTabela()
        {
            IEnumerable<Igreja> lista = new IgrejaBLL().ListaIgreja();
            foreach (var item in lista)
            {
                new IgrejaBLL().Deleta(item);
            }
        }

        [TestMethod]
        public void SalvandoIgreja()
        {
            var retorno = conexao.Grava(igreja);
            Assert.IsNotNull(retorno.id, "Erro ao salvar igreja");
        }

        [TestMethod]
        public void BuscaIgrejaporCodigo()
        {
            var usuretorno = conexao.Grava(igreja);
            igreja = conexao.BuscaPorCodigo(usuretorno.id);
            Assert.AreEqual(usuretorno.id, igreja.id, "Não foi possivel localizar o igreja");
        }

        [TestMethod]
        public void AtualizaIgreja()
        {
            var usuretorno = conexao.Grava(igreja);
            igreja = conexao.BuscaPorCodigo(usuretorno.id);

            var fantasia = "alterando fantasia";
            igreja.nomefantasia = fantasia;
            var retorno = conexao.Grava(igreja);

            Assert.AreEqual(fantasia, retorno.nomefantasia, "Não foi possivel atualizar o igreja");
        }

        [TestMethod]
        public void BuscaListadeIgrejas()
        {
            conexao.Grava(igreja);
            conexao.Grava(igreja);
            var lista = conexao.ListaIgreja();

            Assert.IsNotNull(lista, "A lista não contem os dois itens necessários");
        }
    }
}
