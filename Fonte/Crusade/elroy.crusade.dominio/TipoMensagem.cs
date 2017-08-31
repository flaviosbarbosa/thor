using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace elroy.crusade.dominio
{
    public class TipoMensagem
    {        
        public int id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(1, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Tipo")]
        public string tipo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(60, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Descrição")]
        public string descricao { get; set; }        

        public TipoMensagem()
        {        
        }           
    }
}
