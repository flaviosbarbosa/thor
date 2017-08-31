using System;
using System.ComponentModel.DataAnnotations;

namespace elroy.crusade.dominio
{
    public class Beneficiario
    {         
        public int id { get; set; }
                
        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(100, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Nome")]
        public string nome { get; set; }
                
        [MaxLength(100, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "e-Mail")]
        public string email { get; set; }

        [MaxLength(16, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Telefone")]
        public string telefone { get; set; }

        [MaxLength(500, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Celular")]
        public string celular { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]        
        [Display(Name = "Data Cadastro")]
        public DateTime dataCadastro { get; set; }
        
        [MaxLength(10, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Tipo")]
        public string tipo { get; set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(1, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Ativo")]
        public string ativo { get; set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(1, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Tipo Pessoa")]
        public string tipoPessoa { get; set; }
                
        [MaxLength(18, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Documento I")]
        public string documentoI { get; set; }
                
        [MaxLength(18, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Documento II")]
        public string documentoII { get; set; }
                
        [MaxLength(60, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Endereço")]
        public string endereco { get; set; }
                
        [MaxLength(10, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Numero")]
        public string numero { get; set; }
                
        [MaxLength(60, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Bairro")]
        public string bairro { get; set; }
                
        [MaxLength(60, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Cidade")]
        public string cidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(2, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "UF")]
        public string UF { get; set; }

        public Beneficiario()
        {
            dataCadastro = DateTime.Now;
        }
    }
}