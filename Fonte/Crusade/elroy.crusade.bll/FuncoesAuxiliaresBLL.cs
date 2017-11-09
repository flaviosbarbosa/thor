using Dapper;
using elroy.crusade.Infra;
using elroy.crusade.Infra.Enum;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elroy.crusade.Infra
{
    /// <summary>
    /// Classe de funcções que auxiliam a camada de Infra ou BLL
    /// </summary>
    public class FuncoesAuxiliaresBLL
    {
        public string GeraGuid()
        {
            return System.Guid.NewGuid().ToString();
        }

        public string DefineAcao(string table, string id)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {

                    var boExist = conn.Query(@"SELECT *
                                          FROM " + table.Substring(0, (table.Length -3)) + 
                                        " WHERE ID = @ID", new { Id = id }).Count() > 0;

                    if (boExist)
                    {
                        return Acoes.Update.ToString();
                    }
                    else
                    {
                        return Acoes.Inserir.ToString();
                    }
                }
                catch (Exception e)
                {
                    return "";
                    throw new Exception(e.Message);
                    
                }
            }
        }            
    }
}
