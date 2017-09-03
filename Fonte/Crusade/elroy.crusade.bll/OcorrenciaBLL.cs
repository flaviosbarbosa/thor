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
        public Ocorrencia Grava(Ocorrencia ocorrencia)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {

                if (ocorrencia.id == 0)
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

                        return conn.QueryFirst<Ocorrencia>(@"SELECT ID,
                                                                      CODBENEFICIARIO,
                                                                      TIPO,
                                                                      CODIGOORIGEM,
                                                                      DATA,
                                                                      DESCRICAO
                                                                  FROM OCORRENCIA", ocorrencia);
                    }
                    catch (Exception )
                    {
                        return new Ocorrencia();
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

                        return conn.QueryFirst<Ocorrencia>(@"SELECT ID,
                                                                      CODBENEFICIARIO,
                                                                      TIPO,
                                                                      CODIGOORIGEM,
                                                                      DATA,
                                                                      DESCRICAO
                                                                  FROM OCORRENCIA", ocorrencia);
                    }
                    catch (Exception)
                    {
                        return new Ocorrencia();
                    }
            }
        }

        public Ocorrencia BuscaPorCodigo(int id)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    return conn.QueryFirst<Ocorrencia>(@"SELECT ID,
                                                                  CODBENEFICIARIO,
                                                                  TIPO,
                                                                  CODIGOORIGEM,
                                                                  DATA,
                                                                  DESCRICAO
                                                              FROM OCORRENCIA", new { Id = id });


                }
                catch (Exception)
                {

                    return new Ocorrencia();
                }
            }
        }

        public bool Deleta(Ocorrencia ocorrencia)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    conn.QueryFirst<Ocorrencia>(@"DELETE FROM OCORRENCIA                                                         
                                                        WHERE ID = @id", ocorrencia);
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }

        public List<Ocorrencia> ListaOcorrencia()
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                var retorno = conn.Query<Ocorrencia>(@"SELECT ID,
                                                              CODBENEFICIARIO,
                                                              TIPO,
                                                              CODIGOORIGEM,
                                                              DATA,
                                                              DESCRICAO
                                                          FROM OCORRENCIA");

                return (List<Ocorrencia>)retorno;
            }
        }
    }
}