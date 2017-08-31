using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace elroy.crusade.dominio
{
    public class Ministerio
    {         
        
        public int id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(1000, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Descrição")]
        public string descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(100, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Nome")]
        public string nome { get; set; }

        public Beneficiario beneficiario { get; set; }

        public int codResponsavel { get; set; }

        public virtual List<Integrantes> integrantes { get; set; }

        public virtual List<Eventos> eventos { get; set; }

        public Ministerio()
        {
            integrantes = new List<Integrantes>();
            eventos = new List<Eventos>();
            beneficiario = new Beneficiario();
        }
    }
}