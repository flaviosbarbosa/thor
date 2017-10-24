using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using elroy.crusade.dominio.Enum;
using elroy.crusade.dominio;

namespace elroy.crusade.Aplicacao
{
    public class PessoaFisica : BeneficiarioApp
    {
        public string CPF { get; set; }
        public string RG { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public  TipoBeneficiario TipoBeneficiario{ get; set; }
        public Profissao Profissao { get; set; }
        public int CodProfissao { get; set; }
        public SimNao AutorizaProfissao { get; set; }

        public PessoaFisica()
        {
            TipoBeneficiario = TipoBeneficiario.Membro;
            TipoPessoa = TipoPessoa.Fisica;
            Profissao = new Profissao();
        }
    }
}
