using System;
using System.ComponentModel.DataAnnotations;

namespace elroy.crusade.dominio
{
   public class Programacao
    {       
       public int id { get; set; }

        public Igreja igreja { get; set; }
                
        [Display(Name = "Igreja")]
        public int codIgreja { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(500, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Título")]
        public string titulo { get; set; }

        [Required(ErrorMessage = "O campo descrição é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(500, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Descrição")]
        public string descricao { get; set; }           

        public Programacao()
        {
            igreja = new Igreja();
        }
    }
}
