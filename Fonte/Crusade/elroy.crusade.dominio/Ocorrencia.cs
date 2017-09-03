using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elroy.crusade.dominio
{
    public class Ocorrencia
    {
        [Display(Description = "Código")]
        public int id { get; set; }

        public Beneficiario beneficiario { get; set; }

        public int codbeneficiario { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(1, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Tipo")]
        public string tipo { get; set; }

        [Display(Name = "Documento")]
        public int codigoorigem { get; set; }

        [Display(Name = "Data")]
        public DateTime data { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(500, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Descrição")]
        public string descricao { get; set; }

        public Ocorrencia()
        {
            this.data = DateTime.Now;
        }
    }           
}
