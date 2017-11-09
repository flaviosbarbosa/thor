using elroy.crusade.dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elroy.crusade.dominio
{
    public class PedidoOracao
    {
        public string Id { get; set; }

        public MensagemEntrante MensagemEntrate { get; set; }
        public string CodMensagemEntrante { get; set; }

        public Beneficiario Solicitante { get; set; }
        public string CodSolicitante { get; set; }

        public string NomeSolicitante { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public String Assunto { get; set; }
        public String Descricao { get; set; }
        public String DescricaoRevisada { get; set; }
        public SituacaoPedidoOracao Situacao { get; set; }

        public PedidoOracao()
        {
            Situacao = SituacaoPedidoOracao.Ativo;            
        }        
    }
}
