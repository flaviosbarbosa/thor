using elroy.crusade.dominio.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace elroy.crusade.dominio
{
    public class MensagemEntrante
    {        
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(100, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Solicitante")]
        public string NomeSolicitante { get; set; }

        public TipoMensagem TipoMensagem { get; set; }

        public int CodTipoMensagem { get; set; }

        public Beneficiario Responsavel { get; set; }

        public int CodResponsavel { get; set; }

        public Beneficiario Solicitante { get; set; }

        public int CodSolicitante { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(300, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Assunto")]
        public string Assunto { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(8000, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Mensagem")]
        public string Mensagem { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(150, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "e-Mail")]
        public string EmailContato { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]        
        [Display(Name = "Permitir retorno")]
        public SimNao PermiteRetorno { get; set; }
                
        [MaxLength(16, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Telefone Contato")]
        public string TelefoneContato { get; set; }
                
        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]        
        [Display(Name = "Frequenta?")]
        public SimNao Frequenta { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]        
        [Display(Name = "Data Contato")]
        public DateTime DataContato { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Situação")]
        public SituacaoMensagemEntrante Situacao{ get; set; }

        public MensagemEntrante()
        {
            PermiteRetorno = SimNao.Sim;
            DataContato = DateTime.Now;
            Frequenta = SimNao.Sim;
            Situacao = SituacaoMensagemEntrante.Ativo;
            TipoMensagem = new TipoMensagem();
            Responsavel = new Beneficiario();
            Solicitante = new Beneficiario();
        }
    }
}