using elroy.crusade.Aplicacao;
using elroy.crusade.dominio;
using elroy.crusade.dominio.Enum;
using elroy.crusade.Infra;
using System;

namespace elroy.crusade.test
{
    public class Factory
    {
        public Igreja CriaIgreja()
        {
            Igreja igreja = new Igreja();
            
            igreja.Razaosocial = "Igreja Presbiteriana do Brasil";
            igreja.Cnpj = "07333707000195";
            igreja.UF = "ES";
            igreja.CEP = "29101595";
            igreja.Responsavel = "Eu mesmo";
            igreja.Telefone = "992969013";

            return new IgrejaBLL().Grava(igreja);
        }

        public TipoMensagem CriaTipoMensagem()
        {
            var tipomensagem = new TipoMensagem();
            tipomensagem.Id = 0;
            tipomensagem.Descricao = "Pedido de Oração";
            tipomensagem.Tipo = TrataMensagem.EntradaPedidoOracao;

            return new TipoMensagemBLL().Grava(tipomensagem);
        }

        public PessoaFisica CriaBeneficiarioPF()
        {
            var PF = new PessoaFisica();
            PF.Id = 0;
            PF.Nome = "Flavio de Souza Barbosa";
            PF.Ativo = SimNao.Sim;
            PF.TipoBeneficiario = TipoBeneficiario.Membro;
            PF.Endereco = "Rua Central";
            PF.Numero = "1940";
            PF.Bairro = "Itapua";
            PF.Cidade = "Vila Velha";
            PF.UF = "ES";
            PF.Email = "flavio@elroy.com.br";
            PF.Celular = "992969013";
            PF.Telefone = "30252812";
            PF.DataCadastro = DateTime.Now;
            PF.TipoPessoa = TipoPessoa.Fisica;
            PF.CPF = "03180155795";
            PF.RG = "1214494";            

            return PF;
        }

        public PessoaJuridica CriaBeneficiarioPJ()
        {
            var PJ = new PessoaJuridica();
            PJ.Id = 0;
            PJ.Nome = "Industrias ACME SA";
            PJ.Ativo = SimNao.Sim;
            PJ.TipoBeneficiario = TipoBeneficiario.Fornecedores;
            PJ.Endereco = "Rua das Empresas";
            PJ.Numero = "1000";
            PJ.Bairro = "Centro";
            PJ.Cidade = "Vitória";
            PJ.UF = "ES";
            PJ.Email = "flavio@gmail.com.br";
            PJ.Celular = "992969015";
            PJ.Telefone = "30252811";
            PJ.DataCadastro = DateTime.Now;
            PJ.TipoPessoa = TipoPessoa.Juridica;
            PJ.CNPJ = "09443333000160";
            PJ.InscricaoEstadual = "ISENTO";

            return PJ;
        }

        public Ministerio CriaMinisterio()
        {
            var ministerio = new Ministerio();
            ministerio.Responsavel = this.CriaBeneficiario();

            ministerio.Id = 0;
            ministerio.Nome = "Louvor";
            ministerio.CodResponsavel = ministerio.Responsavel.Id;
            ministerio.Descricao = "Ministerio de Louvor";

            return new MinisterioBLL().Grava(ministerio);
        }
    }
}
