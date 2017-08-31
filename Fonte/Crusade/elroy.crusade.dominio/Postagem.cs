using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elroy.crusade.dominio
{
    public class Postagem
    {        
        public int id { get; set; }
        
        public Topico topico { get; set; }

        public int codTopico { get; set; }

        public Beneficiario beneficiario { get; set; }

        public int codBeneficiario { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(5000, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Mensagem")]
        public string mensagem { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]        
        [Display(Name = "Data Pulicação")]
        public DateTime dataPublicacao { get; set; }

        public Postagem()
        {
            
        }
    }
}
