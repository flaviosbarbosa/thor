using System;
using System.ComponentModel.DataAnnotations;

namespace elroy.crusade.dominio
{
    public class AgendaPastoral
    {        
        public int id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(5000, ErrorMessage = "Tamanho máximo para o {0} é de {1} caracteres.")]        
        [Display(Name = "Evento")]
        public string evento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]        
        public DateTime data { get; set; }

        //public DateTime horarioInicial { get; set; }

        //public DateTime horarioFinal { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(300, ErrorMessage = "Tamanho máximo para o {0} é de {1} caracteres.")]
        [Display(Name = "Local")]
        public string local { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(1, ErrorMessage = "Tamanho máximo para o {0} é de {1} caracteres.")]
        [Display(Name = "Privado")]
        public string privado { get; set; }

        public AgendaPastoral()
        {
            privado = "S";
        }
    }
}
