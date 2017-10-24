using elroy.crusade.dominio.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace elroy.crusade.dominio
{
    public class Eventos
    {        
        public int Id {get; set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(500, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(5000, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Descrição")]
        public string Descricao {get; set;}              

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(300, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Local")]        
        public string Local { get; set; }

        public DateTime? horario { get; set; }        
        
        public int? Banner {get; set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(1, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Privado")]
        public SimNao Privado {get; set;}

        public Ministerio Ministerio { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]        
        [Display(Name = "Ministério")]
        public int CodMinisterio { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(1, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Pastor Presente")]
        public SimNao PastorPresente { get; set; }        

        public Eventos()
        {
            Privado = SimNao.Sim;
            PastorPresente = SimNao.Sim;
            Ministerio = new Ministerio();
        }
    }
}
