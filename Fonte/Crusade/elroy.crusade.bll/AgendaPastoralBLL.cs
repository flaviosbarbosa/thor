using Dapper;
using elroy.crusade.dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elroy.crusade.Infra
{
    public class AgendaPastoralBLL
    {
        public AgendaPastoral Grava(AgendaPastoral AgendaPastoral)
        {
            // parei ontem criando a conexao com o banco
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {

                if (AgendaPastoral.Id == 0)
                {
                    try
                    {                        
                    conn.Execute(@"INSERT INTO AGENDAPASTORAL
                                           (
                                           EVENTO,
                                           DATA,                                           
                                           LOCAL,
                                           PRIVADO)
                                     VALUES
                                           (
                                           @EVENTO,
                                           @DATA,                                           
                                           @LOCAL,
                                           @PRIVADO)", AgendaPastoral);

                    return conn.QueryFirst<AgendaPastoral>(@"SELECT ID,
                                                                    EVENTO,
                                                                    DATA,                                           
                                                                    LOCAL,
                                                                    PRIVADO
                                                               FROM AGENDAPASTORAL", AgendaPastoral);
                    }
                    catch (Exception )
                    {
                        return new AgendaPastoral();
                    }
                }
                else
                    try
                    {
                        var retorno =
                        conn.Execute(@"UPDATE AGENDAPASTORAL
                                           SET EVENTO = @EVENTO,
                                                DATA = @DATA,                                                
                                                LOCAL = @LOCAL,
                                                PRIVADO = @PRIVADO
                                            WHERE id = @id", AgendaPastoral);

                        return conn.QueryFirst<AgendaPastoral>(@"SELECT * FROM AgendaPastoral", AgendaPastoral);
                    }
                    catch (Exception)
                    {
                        return new AgendaPastoral();
                    }
            }
        }

        public AgendaPastoral BuscaPorCodigo(int id)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    return conn.QueryFirst<AgendaPastoral>(@"SELECT ID,
                                                                    EVENTO,
                                                                    DATA,                                                                  
                                                                    LOCAL,
                                                                    PRIVADO
                                                                FROM AGENDAPASTORAL
                                                        WHERE ID = @ID", new { Id = id });
                }
                catch (Exception)
                {

                    return new AgendaPastoral();
                }
            }
        }

        public bool Deleta(AgendaPastoral AgendaPastoral)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    conn.QueryFirst<AgendaPastoral>(@"DELETE FROM AgendaPastoral                                                         
                                                        WHERE ID = @id", AgendaPastoral);
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }

        public List<AgendaPastoral> ListaAgendaPastoral()
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                var retorno = conn.Query<AgendaPastoral>(@"SELECT * FROM AgendaPastoral");

                return (List<AgendaPastoral>)retorno;
            }
        }
    }
}
