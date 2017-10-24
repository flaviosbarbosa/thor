using System;
using System.ComponentModel.DataAnnotations;

namespace elroy.crusade.dominio
{
    public class Parametros
    {                       
        public int id { get; set; }
                
        [MaxLength(200, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Localização")]
        public string localizacao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(1, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Assunto")]
        public string exibirLocalizacao { get; set; }

        public Beneficiario Pastor { get; set; }

        public int CodPastor { get; set; }

        public Beneficiario AtendenteNivelUm { get; set; }

        public int CodAtedenteNivelUm { get; set; }

        public string EmailEntrante { get; set; }

        public string ContatoSomenteMembros { get; set; }

        public Parametros()
        {
            exibirLocalizacao = "S";
            Pastor = new Beneficiario();
            AtendenteNivelUm = new Beneficiario();
        }      
    }
}
