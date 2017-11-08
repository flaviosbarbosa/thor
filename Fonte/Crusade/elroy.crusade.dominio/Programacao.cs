using System;
using System.ComponentModel.DataAnnotations;

namespace elroy.crusade.dominio
{
   public class Programacao
    {       
       public String Id { get; set; }

        public Igreja Igreja { get; set; }
                
        [Display(Name = "Igreja")]
        public String CodIgreja { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(500, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo descrição é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(500, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }           

        public Programacao()
        {
            Igreja = new Igreja();
        }
    }
}
