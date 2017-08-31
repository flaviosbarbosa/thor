using System;
using System.ComponentModel.DataAnnotations;

namespace elroy.crusade.dominio
{
    public class Igreja
    {              
        [Display(Description = "Código")]
        public int id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(60, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Fantasia")]
        public string nomefantasia { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(5000, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Razão Social")]        
        public string razaosocial { get; set; }
                
        [MaxLength(5000, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "CNPJ")]
        public string cnpj { get; set; }
                
        [MaxLength(100, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Endereço")]
        public string endereco { get; set; }
                
        [MaxLength(8, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Numero")]
        public string numero { get; set; }
                
        [MaxLength(60, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Bairro")]
        public string bairro { get; set; }
                
        [MaxLength(60, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Cidade")]
        public string cidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(10, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "CEP")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(2, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "UF")]
        public string uf { get; set; }
                
        [MaxLength(9, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Telefone")]
        public string telefone { get; set; }
                
        [MaxLength(9, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Celular")]
        public string celular { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(100, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Responsavel")]
        public string Responsavel { get; set; }        

        public Igreja()
        {
        
        }
    }
}