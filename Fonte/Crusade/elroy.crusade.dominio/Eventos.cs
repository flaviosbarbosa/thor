using System;
using System.ComponentModel.DataAnnotations;

namespace elroy.crusade.dominio
{
    public class Eventos
    {        
        public int id {get; set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(500, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Título")]
        public string titulo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(5000, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Descrição")]
        public string descricao {get; set;}              

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        public DateTime data { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(300, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Local")]        
        public string local { get; set; }

        public DateTime? horario { get; set; }        
        
        public int? banner {get; set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(1, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Privado")]
        public string privado {get; set;}

        public Ministerio ministerio { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]        
        [Display(Name = "Ministério")]
        public int codMinisterio { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(1, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Pastor Presente")]
        public string pastorPresente { get; set; }        

        public Eventos()
        {
            privado = "S";
            pastorPresente = "S";
            ministerio = new Ministerio();
        }
    }
}
