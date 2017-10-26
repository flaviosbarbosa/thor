
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

        public Beneficiario CriaBeneficiario()
        {
            var PF = new Beneficiario();
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
            PF.DocumentoI = "03180155795";
            PF.DocumentoII = "1214494";            

            return PF;
        }
        
        public Ministerio CriaMinisterio()
        {
            var ministerio = new Ministerio();
            ministerio.Responsavel = new BeneficiarioBLL().Grava(this.CriaBeneficiario());

            ministerio.Id = 0;
            ministerio.Nome = "Louvor";
            ministerio.CodResponsavel = ministerio.Responsavel.Id;
            ministerio.Descricao = "Ministerio de Louvor";

            return new MinisterioBLL().Grava(ministerio);
        }

        public MensagemEntrante CriaMensagemEntrante()
        {
            var mensagemEntrante = new MensagemEntrante();

            mensagemEntrante.TipoMensagem = new TipoMensagemBLL().Grava(this.CriaTipoMensagem());
            mensagemEntrante.Responsavel = new BeneficiarioBLL().Grava(this.CriaBeneficiario());
            mensagemEntrante.Solicitante = new BeneficiarioBLL().Grava(this.CriaBeneficiario());

            mensagemEntrante.CodTipoMensagem = mensagemEntrante.TipoMensagem.Id;
            mensagemEntrante.CodResponsavel = mensagemEntrante.Responsavel.Id;
            mensagemEntrante.CodSolicitante = mensagemEntrante.Solicitante.Id;
            mensagemEntrante.DataContato = DateTime.Now;
            mensagemEntrante.Assunto = "Pedido de Oração";
            mensagemEntrante.EmailContato = "teste@teste.com.br";
            mensagemEntrante.Frequenta = SimNao.Sim;
            mensagemEntrante.Mensagem = "Orem por mim";
            mensagemEntrante.NomeSolicitante = "Joaquim Jose da Silva Xavier";
            mensagemEntrante.PermiteRetorno = SimNao.Sim;
            mensagemEntrante.TelefoneContato = "27992969013";

            return mensagemEntrante;
        }
    }
}
