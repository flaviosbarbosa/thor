﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace elroy.crusade.dominio
{
    public class Ministerio
    {         
        
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(1000, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(100, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        public Beneficiario Beneficiario { get; set; }

        public int CodResponsavel { get; set; }

        public virtual List<Integrantes> Integrantes { get; set; }

        public Ministerio()
        {
            Integrantes = new List<Integrantes>();
            Beneficiario = new Beneficiario();
        }
    }
}