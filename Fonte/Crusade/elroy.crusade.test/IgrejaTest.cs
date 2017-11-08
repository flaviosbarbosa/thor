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
            igreja.Id = new FuncoesAuxiliaresBLL().GeraGuid();
            igreja.Razaosocial = "Igreja da Gloria";
            igreja.Nomefantasia= "Igreja da Gloria Divina";
            igreja.Cnpj = "07354222000160";
            igreja.Endereco = "Rua dos carvalhos, 123";
            igreja.Numero = "150";
            igreja.Telefone = "30251478";
            igreja.Celular = "992966012";
            igreja.Bairro = "Praia de Itapuã";
            igreja.Cidade = "Vila Velha";
            igreja.CEP = "29101595";
            igreja.Responsavel = "Marcos Nolasco";
            igreja.UF = "ES";

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
            Assert.IsNotNull(retorno.Id, "Erro ao salvar igreja");
        }

        [TestMethod]
        public void BuscaIgrejaporCodigo()
        {
            var usuretorno = conexao.Grava(igreja);
            igreja = conexao.Busca(usuretorno.Id);
            Assert.AreEqual(usuretorno.Id, igreja.Id, "Não foi possivel localizar o igreja");
        }

        [TestMethod]
        public void AtualizaIgreja()
        {
            var usuretorno = conexao.Grava(igreja);
            igreja = conexao.Busca(usuretorno.Id);

            var fantasia = "alterando fantasia";
            igreja.Nomefantasia = fantasia;
            var retorno = conexao.Grava(igreja);

            Assert.AreEqual(fantasia, retorno.Nomefantasia, "Não foi possivel atualizar o igreja");
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
