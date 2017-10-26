using elroy.crusade.dominio.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace elroy.crusade.dominio
{
    public class Beneficiario
    {         
        public int Id { get; set; }
                
        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(100, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
                
        [MaxLength(100, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "e-Mail")]
        public string Email { get; set; }

        [MaxLength(16, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [MaxLength(500, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Celular")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]        
        [Display(Name = "Data Cadastro")]
        public DateTime DataCadastro { get; set; }
      
        [Display(Name = "TipoBeneficiario")]
        public TipoBeneficiario TipoBeneficiario{ get; set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Ativo")]
        public SimNao Ativo { get; set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]        
        [Display(Name = "Tipo Pessoa")]
        public TipoPessoa TipoPessoa { get; set; }
                
        [MaxLength(18, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Documento I")]
        public string DocumentoI { get; set; }
                
        [MaxLength(18, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Documento II")]
        public string DocumentoII { get; set; }
                
        [MaxLength(60, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }
                
        [MaxLength(10, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Numero")]
        public string Numero { get; set; }
                
        [MaxLength(60, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }
                
        [MaxLength(60, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(2, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "UF")]
        public string UF { get; set; }

        public Profissao Profissao { get; set; }

        public int CodProfissao { get; set; }

        public SimNao AutorizaProfissao { get; set; }

        public Beneficiario()
        {
            DataCadastro = DateTime.Now;
            Profissao = new Profissao();
        }
    }
}