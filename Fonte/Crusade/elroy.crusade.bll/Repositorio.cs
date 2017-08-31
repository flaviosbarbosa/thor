using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elroy.crusade.Infra
{
    public static class Repositorio
    {

        public static string Conexao()
        {
            string stringConexao = ConfigurationManager.ConnectionStrings["DPContexto"].ConnectionString;            

            return stringConexao;
        }
    }
}
