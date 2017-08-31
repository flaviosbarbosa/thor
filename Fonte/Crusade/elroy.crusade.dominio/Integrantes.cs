using System;
using System.ComponentModel.DataAnnotations;

namespace elroy.crusade.dominio
{
    public class Integrantes
    {        
        public int id { get; set; }

        public Ministerio ministerio { get; set; }

        [Required]        
        [Display(Name = "Ministério")]
        public int codMinisterio { get; set; }               

        public Beneficiario beneficiario { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]        
        [Display(Name ="Beneficiário")]
        public int codBeneficiario { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage ="O campo {0} não pode ser nulo")]
        [Display(Name ="Ativo")]
        public string ativo { get; set; } 

        public Integrantes()
        {
            ativo = "S";
        }
    }
}