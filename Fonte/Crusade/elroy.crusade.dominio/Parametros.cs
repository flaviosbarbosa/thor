using System;
using System.ComponentModel.DataAnnotations;

namespace elroy.crusade.dominio
{
    public class Parametros
    {                       
        public string Id { get; set; }
                
        [MaxLength(200, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Localização")]
        public string Localizacao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(1, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Assunto")]
        public string ExibirLocalizacao { get; set; }

        public Beneficiario Pastor { get; set; }

        public string CodPastor { get; set; }

        public Beneficiario AtendenteNivelUm { get; set; }

        public string CodAtedenteNivelUm { get; set; }

        public string EmailEntrante { get; set; }

        public string ContatoSomenteMembros { get; set; }

        public Parametros()
        {
            ExibirLocalizacao = "S";
            Pastor = new Beneficiario();
            AtendenteNivelUm = new Beneficiario();
        }      
    }
}
