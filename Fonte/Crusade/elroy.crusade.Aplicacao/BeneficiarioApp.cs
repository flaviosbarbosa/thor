using elroy.crusade.dominio;
using elroy.crusade.dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elroy.crusade.Aplicacao
{
    public class BeneficiarioApp
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Celular { get; set; }

        public DateTime DataCadastro { get; set; }        

        public SimNao Ativo { get; set; }            

        public string Endereco { get; set; }

        public string Numero { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string UF { get; set; }

        public BeneficiarioApp()
        {
            DataCadastro = DateTime.Now;            
        }
    }
}
