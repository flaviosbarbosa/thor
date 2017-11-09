
using elroy.crusade.bll;
using elroy.crusade.dominio;
using elroy.crusade.dominio.Enum;
using elroy.crusade.Infra;
using System;
using System.Collections.Generic;

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
            tipomensagem.Id = "";
            tipomensagem.Descricao = "Pedido de Oração";
            tipomensagem.Tipo = TrataMensagem.EntradaPedidoOracao;

            return new TipoMensagemBLL().Grava(tipomensagem);
        }

        public Beneficiario CriaBeneficiario()
        {
            var PF = new Beneficiario();
            PF.Id = "";
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

            ministerio.Id = "";
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

        public Eventos CriaEvento()
        {
            var evento = new Eventos();
            evento.Id = "";
            //eventos.banner = "Flavio";
            evento.Titulo = "Dia de Lazer e Cultura";
            evento.Descricao = "Evento Social para a comunidade";
            evento.Data = new DateTime(2017, 10, 12);
            evento.Local = "Igreja Presbiteriana Praia de Itapoã";
            evento.PastorPresente = SimNao.Sim;
            evento.Privado = SimNao.Nao;
            evento.Ministerio = this.CriaMinisterio();
            evento.CodMinisterio = evento.Ministerio.Id;

            return evento;
        }

        public Participantes CriaParticipantes()
        {         
            var p1 = new Participantes();
            p1.Id = "";
            p1.Eventos = new EventosBLL().Grava(this.CriaEvento());
            p1.CodEvento = p1.Eventos.Id;
            p1.Membro = new BeneficiarioBLL().Grava(this.CriaBeneficiario());
            p1.CodMembro = p1.Membro.Id;
            p1.Situacao = SituacaoParticipante.Confirmada;
            p1.Lembrete = SimNao.Sim;

            return p1;
        }

        public PedidoOracao CriaPedidoOracao()
        {
            var pedidoOracao = new PedidoOracao();

            pedidoOracao.Id = "";
            pedidoOracao.Assunto = "Motivo de Doença";
            pedidoOracao.Descricao = "Meu irmão está doente e carece de suas orações";
            pedidoOracao.DescricaoRevisada = "Favor orar pelo irmão";

            pedidoOracao.MensagemEntrate = new MensagemEntranteBLL().Grava(this.CriaMensagemEntrante());
            pedidoOracao.CodMensagemEntrante = pedidoOracao.MensagemEntrate.Id;
            pedidoOracao.Solicitante = new BeneficiarioBLL().Grava(this.CriaBeneficiario());
            pedidoOracao.CodSolicitante = pedidoOracao.Solicitante.Id;
            pedidoOracao.DataSolicitacao = new DateTime(2017, 10, 12);
            pedidoOracao.NomeSolicitante = pedidoOracao.Solicitante.Nome;
            pedidoOracao.Situacao = SituacaoPedidoOracao.Ativo;

            return pedidoOracao;
        }
    }
}
