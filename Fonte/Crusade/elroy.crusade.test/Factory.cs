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
            tipomensagem.id = 0;
            tipomensagem.descricao = "Pedido de Oração";
            tipomensagem.tipo = "P";

            return new TipoMensagemBLL().Grava(tipomensagem);
        }

        public Beneficiario CriaBeneficiario()
        {
            var beneficiario = new Beneficiario();
            beneficiario.Id = 0;
            beneficiario.Nome = "Flavio de Souza Barbosa";
            beneficiario.Ativo = SimNao.Sim;
            beneficiario.TipoBeneficiario = TipoBeneficiario.Membro;
            beneficiario.Endereco = "Rua Central";
            beneficiario.Numero = "1940";
            beneficiario.Bairro = "Itapua";
            beneficiario.Cidade = "Vila Velha";
            beneficiario.UF = "ES";
            beneficiario.Email = "flavio@elroy.com.br";
            beneficiario.Celular = "992969013";
            beneficiario.Telefone = "30252812";
            beneficiario.DataCadastro = DateTime.Now;
            beneficiario.TipoPessoa = TipoPessoa.Fisica;
            beneficiario.DocumentoI = "03180155795";
            beneficiario.DocumentoII = "1214494";

            return beneficiario;
        }

        public Ministerio CriaMinisterio()
        {
            var ministerio = new Ministerio();
            ministerio.Beneficiario = this.CriaBeneficiario();

            ministerio.Id = 0;
            ministerio.Nome = "Louvor";
            ministerio.CodResponsavel = ministerio.Beneficiario.Id;
            ministerio.Descricao = "Ministerio de Louvor";

            return new MinisterioBLL().Grava(ministerio);
        }
    }
}
