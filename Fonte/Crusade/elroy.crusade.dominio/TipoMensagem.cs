using elroy.crusade.dominio.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace elroy.crusade.dominio
{
    public class TipoMensagem
    {        
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]        
        [Display(Name = "Tipo")]
        public TrataMensagem Tipo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(60, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }        

        public TipoMensagem()
        {        
        }           
    }
}
