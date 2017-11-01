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
    public class OcorrenciaBLL
    {
        public OcorrenciaEntrante Grava(OcorrenciaEntrante ocorrencia)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {

                if (ocorrencia.Id == 0)
                {
                    try
                    {
                        ocorrencia.Id = (int)conn.ExecuteScalar(@"INSERT INTO OCORRENCIAENTRANTE
                                                   ( CODMENSAGEMENTRANTE,
                                                     CODRESPONSAVEL,
                                                     DESCRICAO,
                                                     DATA)
                                                    OUTPUT INSERTED.id    
                                             VALUES
                                                   (@CODMENSAGEMENTRANTE,
                                                    @CODRESPONSAVEL,
                                                    @DESCRICAO,
                                                    @DATA)", ocorrencia);                      
                         
                         return ocorrencia;
                    }
                    catch (Exception e)
                    {
                        return new OcorrenciaEntrante();
                        throw new Exception(e.Message);
                    }
                }
                else
                    try
                    {
                        var retorno =
                        conn.Execute(@"UPDATE OCORRENCIAENTRANTE
                                           SET CODMENSAGEMENTRANTE = @CODMENSAGEMENTRANTE,
                                               CODRESPONSAVEL = @CODRESPONSAVEL,
                                               DESCRICAO = @DESCRICAO,
                                               DATA = @DATA
                                         WHERE id = @id", ocorrencia);

                        return conn.QueryFirst<OcorrenciaEntrante>(@"SELECT ID,
                                                                             CODMENSAGEMENTRANTE,
                                                                             CODRESPONSAVEL,
                                                                             DESCRICAO,
                                                                             DATA
                                                                        FROM OCORRENCIAENTRANTE
                                                                  where id = @id", new { id = ocorrencia.Id });                        
                    }
                    catch (Exception e)
                    {
                        return new OcorrenciaEntrante();
                        throw new Exception(e.Message);

                    }
            }
        }

        public OcorrenciaEntrante BuscaPorCodigo(int id)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    return conn.QueryFirst<OcorrenciaEntrante>(@"SELECT ID,
                                                                        CODMENSAGEMENTRANTE,
                                                                        CODRESPONSAVEL,
                                                                        DESCRICAO,
                                                                        DATA
                                                                FROM OCORRENCIAENTRANTE", new { Id = id });


                }
                catch (Exception)
                {

                    return new OcorrenciaEntrante();
                }
            }
        }

        public bool Deleta(OcorrenciaEntrante ocorrencia)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    conn.QueryFirst<OcorrenciaEntrante>(@"DELETE FROM OCORRENCIAENTRANTE                                                         
                                                        WHERE ID = @id", ocorrencia);
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }

        public List<OcorrenciaEntrante> ListaOcorrencia()
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                var retorno = conn.Query<OcorrenciaEntrante>(@"SELECT ID,
                                                                      CODMENSAGEMENTRANTE,
                                                                      CODRESPONSAVEL,
                                                                      DESCRICAO,
                                                                      DATA
                                                                FROM OCORRENCIAENTRANTE");

                return (List<OcorrenciaEntrante>)retorno;
            }
        }
    }
}