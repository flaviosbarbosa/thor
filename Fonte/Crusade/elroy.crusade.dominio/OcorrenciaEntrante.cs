using System;
using System.ComponentModel.DataAnnotations;

namespace elroy.crusade.dominio
{
    public class OcorrenciaEntrante
    {
        [Display(Description = "Código")]
        public int Id { get; set; }

        public Beneficiario Responsavel { get; set; }

        public int CodResponsavel{ get; set; }        

        public MensagemEntrante MensagemEntrante { get; set; }

        [Display(Name = "Mensagem")]
        public int CodMensagemEntrante { get; set; }

        [Display(Name = "Data")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(500, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public OcorrenciaEntrante()
        {
            this.Data = DateTime.Now;
        }
    }
}
