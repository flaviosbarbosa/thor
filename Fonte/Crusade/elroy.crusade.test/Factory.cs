using elroy.crusade.dominio;
using elroy.crusade.Infra;
using System;

namespace elroy.crusade.test
{
    public class Factory
    {
        public Igreja CriaIgreja()
        {
            Igreja igreja = new Igreja();
            
            igreja.razaosocial = "Igreja Presbiteriana do Brasil";
            igreja.cnpj = "07333707000195";
            igreja.uf = "ES";
            igreja.CEP = "29101595";
            igreja.Responsavel = "Eu mesmo";
            igreja.telefone = "992969013";

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
            beneficiario.id = 0;
            beneficiario.nome = "Flavio de Souza Barbosa";
            beneficiario.ativo = "S";
            beneficiario.tipo = "X";
            beneficiario.endereco = "Rua Central";
            beneficiario.numero = "1940";
            beneficiario.bairro = "Itapua";
            beneficiario.cidade = "Vila Velha";
            beneficiario.UF = "ES";
            beneficiario.email = "flavio@elroy.com.br";
            beneficiario.celular = "992969013";
            beneficiario.telefone = "30252812";
            beneficiario.dataCadastro = DateTime.Now;
            beneficiario.tipoPessoa = "F";
            beneficiario.documentoI = "03180155795";
            beneficiario.documentoII = "1214494";

            return new BeneficiarioBLL().Grava(beneficiario);
        }

        public Ministerio CriaMinisterio()
        {
            var ministerio = new Ministerio();
            ministerio.beneficiario = this.CriaBeneficiario();

            ministerio.id = 0;
            ministerio.nome = "Louvor";
            ministerio.codResponsavel = ministerio.beneficiario.id;
            ministerio.descricao = "Ministerio de Louvor";

            return new MinisterioBLL().Grava(ministerio);
        }
    }
}
