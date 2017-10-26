using elroy.crusade.dominio.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace elroy.crusade.dominio
{
    public class AgendaPastoral
    {        
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(5000, ErrorMessage = "Tamanho máximo para o {0} é de {1} caracteres.")]        
        [Display(Name = "Evento")]
        public string Evento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]        
        public DateTime Data { get; set; }

        //public DateTime horarioInicial { get; set; }

        //public DateTime horarioFinal { get; set; }

        //TODO: Estudar manipulação de hora no VS e SQLSERVER

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(300, ErrorMessage = "Tamanho máximo para o {0} é de {1} caracteres.")]
        [Display(Name = "Local")]
        public string Local { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]        
        [Display(Name = "Privado")]
        public SimNao Privado { get; set; }

        public AgendaPastoral()
        {
            Privado = SimNao.Sim;
        }
    }
}
