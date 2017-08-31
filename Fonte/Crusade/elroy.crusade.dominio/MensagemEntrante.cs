using System;
using System.ComponentModel.DataAnnotations;

namespace elroy.crusade.dominio
{
    public class MensagemEntrante
    {        
        public int id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(100, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Solicitante")]
        public string nomeSolicitante { get; set; }

        public TipoMensagem tipoMensagem { get; set; }

        public int codTipoMensagem { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(300, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Assunto")]
        public string assunto { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(8000, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Mensagem")]
        public string mensagem { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(150, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "e-Mail")]
        public string emailContato { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(1, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Permitir retorno")]
        public string permiteRetorno { get; set; }
                
        [MaxLength(16, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Telefone Contato")]
        public string telefoneContato { get; set; }
                
        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(1, ErrorMessage = "Tamanho máximo para o campo {0} é de 1 caracter.")]
        [Display(Name = "Frequenta?")]
        public string frequenta { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]        
        [Display(Name = "Data Contato")]
        public DateTime dataContato { get; set; }

        public MensagemEntrante()
        {
            permiteRetorno = "S";

            dataContato = DateTime.Now;

            frequenta = "S";
        }
    }
}