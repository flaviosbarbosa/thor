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
                        conn.Execute(@"INSERT INTO OCORRENCIA
                                                   (CODBENEFICIARIO,
                                                   TIPO,
                                                   CODIGOORIGEM,
                                                   DATA,
                                                   DESCRICAO)
                                             VALUES
                                                   (@CODBENEFICIARIO, 
                                                   @TIPO, 
                                                   @CODIGOORIGEM, 
                                                   @DATA, 
                                                   @DESCRICAO)", ocorrencia);

                        return conn.QueryFirst<OcorrenciaEntrante>(@"SELECT ID,
                                                                      CODBENEFICIARIO,
                                                                      TIPO,
                                                                      CODIGOORIGEM,
                                                                      DATA,
                                                                      DESCRICAO
                                                                  FROM OCORRENCIA", ocorrencia);
                    }
                    catch (Exception )
                    {
                        return new OcorrenciaEntrante();
                    }
                }
                else
                    try
                    {
                        var retorno =
                        conn.Execute(@"UPDATE OCORRENCIA
                                           SET CODBENEFICIARIO = @CODBENEFICIARIO,
                                              TIPO = @TIPO,
                                              CODIGOORIGEM = @CODIGOORIGEM,
                                              DATA = @DATA,
                                              DESCRICAO = @DESCRICAO
                                         WHERE id = @id", ocorrencia);

                        return conn.QueryFirst<OcorrenciaEntrante>(@"SELECT ID,
                                                                      CODBENEFICIARIO,
                                                                      TIPO,
                                                                      CODIGOORIGEM,
                                                                      DATA,
                                                                      DESCRICAO
                                                                  FROM OCORRENCIA", ocorrencia);
                    }
                    catch (Exception)
                    {
                        return new OcorrenciaEntrante();
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
                                                                  CODBENEFICIARIO,
                                                                  TIPO,
                                                                  CODIGOORIGEM,
                                                                  DATA,
                                                                  DESCRICAO
                                                              FROM OCORRENCIA", new { Id = id });


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
                    conn.QueryFirst<OcorrenciaEntrante>(@"DELETE FROM OCORRENCIA                                                         
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
                                                              CODBENEFICIARIO,
                                                              TIPO,
                                                              CODIGOORIGEM,
                                                              DATA,
                                                              DESCRICAO
                                                          FROM OCORRENCIA");

                return (List<OcorrenciaEntrante>)retorno;
            }
        }
    }
}