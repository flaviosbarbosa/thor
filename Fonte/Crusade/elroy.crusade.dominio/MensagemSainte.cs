
using System;
using System.ComponentModel.DataAnnotations;

namespace elroy.crusade.dominio
{
    public class MensagemSainte
    {        
        public int id { get; set; }

        public Ministerio ministerio { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]        
        [Display(Name = "Ministério")]
        public int codMinisterio { get; set; }

        public TipoMensagem tipoMensagem { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]        
        [Display(Name = "Tipo Mensagem")]
        public int codTipoMensagem { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(4000, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Mensagem")]
        public string mensagem { get; set; }

        public DateTime dataEnvio { get; set; }

        public MensagemSainte()
        {
            ministerio = new Ministerio();
            tipoMensagem = new TipoMensagem();
            dataEnvio = DateTime.Now;
        }
    }
}
