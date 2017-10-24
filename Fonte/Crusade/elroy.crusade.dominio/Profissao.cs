using System.ComponentModel.DataAnnotations;

namespace elroy.crusade.dominio
{
    public class Profissao
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(200, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Nome")]
        public string Descricao { get; set; }


        public Profissao()
        {

        }
    }
}
