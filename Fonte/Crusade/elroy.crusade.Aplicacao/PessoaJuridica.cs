using elroy.crusade.dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elroy.crusade.Aplicacao
{
    public class PessoaJuridica : BeneficiarioApp
    {
        public string CNPJ { get; set; }
        public string InscricaoEstadual { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public TipoBeneficiario TipoBeneficiario { get; set; }        

        public PessoaJuridica()
        {
            TipoBeneficiario = TipoBeneficiario.Fornecedores;
            TipoPessoa = TipoPessoa.Juridica;            
        }
    }
}
