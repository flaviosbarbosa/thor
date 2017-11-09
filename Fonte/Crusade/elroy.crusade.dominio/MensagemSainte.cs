﻿
using System;
using System.ComponentModel.DataAnnotations;

namespace elroy.crusade.dominio
{
    public class MensagemSainte
    {        
        public string Id { get; set; }

        public Ministerio Ministerio { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]        
        [Display(Name = "Ministério")]
        public string CodMinisterio { get; set; }

        public TipoMensagem TipoMensagem { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]        
        [Display(Name = "Tipo Mensagem")]
        public string CodTipoMensagem { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(4000, ErrorMessage = "Tamanho máximo para o campo {0} é de {1} caracteres.")]
        [Display(Name = "Mensagem")]
        public string Mensagem { get; set; }

        public DateTime DataEnvio { get; set; }

        public MensagemEntrante MensagemEntrante { get; set; }

        public string CodMensagemEntrante { get; set; }

        public MensagemSainte()
        {
            Ministerio = new Ministerio();
            TipoMensagem = new TipoMensagem();
            DataEnvio = DateTime.Now;

            TipoMensagem = new TipoMensagem();
            MensagemEntrante = new MensagemEntrante();
        }
    }
}
