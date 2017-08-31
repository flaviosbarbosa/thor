using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elroy.crusade.dominio
{
    public class Topico
    {        
        public int id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(100, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Assunto")]
        public string assunto { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(5000, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Descrição")]
        public string descricao { get; set; }

        public DateTime dataCadastro { get; set; }

        public virtual List<Postagem> Postagem { get; set; }

        public Topico()
        {
            Postagem = new List<Postagem>();
            dataCadastro = DateTime.Now;
        }
    }
}
