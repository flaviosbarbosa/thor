using elroy.crusade.dominio.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace elroy.crusade.dominio
{
    public class Integrantes
    {        
        public int Id { get; set; }

        public Ministerio Ministerio { get; set; }

        [Required]        
        [Display(Name = "Ministério")]
        public int CodMinisterio { get; set; }               

        public Beneficiario Beneficiario { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]        
        [Display(Name ="Beneficiário")]
        public int CodBeneficiario { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage ="O campo {0} não pode ser nulo")]
        [Display(Name ="Ativo")]
        public SimNao Ativo { get; set; } 

        public Integrantes()
        {
            Ativo = SimNao.Sim;
        }
    }
}