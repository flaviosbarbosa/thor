using Dapper;
using elroy.crusade.dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace elroy.crusade.Infra
{
    public class IntegrantesBLL
    {
        public Integrantes Grava(Integrantes integrantes)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {

                if (integrantes.id == 0)
                {
                    try
                    {
                        conn.Execute(@"INSERT INTO INTEGRANTES
                                               (CODBENEFICIARIO,
                                               CODMINISTERIO,
                                               ATIVO)
                                         VALUES
                                               (@CODBENEFICIARIO,
                                                @CODMINISTERIO,
                                                @ATIVO)", integrantes);

                        return conn.QueryFirst<Integrantes>(@"SELECT ID,
                                                                     CODBENEFICIARIO,
                                                                     CODMINISTERIO,
                                                                     ATIVO
                                                                FROM INTEGRANTES", integrantes);
                    }
                    catch (Exception )
                    {
                        return new Integrantes();
                    }
                }
                else
                    try
                    {
                        var retorno =
                        conn.Execute(@"UPDATE INTEGRANTES
                                           SET CODBENEFICIARIO = @CODBENEFICIARIO,
                                              CODMINISTERIO = @CODMINISTERIO,
                                              ATIVO = @ATIVO
                                         WHERE id = @id", integrantes);

                        return conn.QueryFirst<Integrantes>(@"SELECT ID,
                                                                     CODBENEFICIARIO,
                                                                     CODMINISTERIO,
                                                                     ATIVO
                                                                FROM INTEGRANTES", integrantes);
                    }
                    catch (Exception)
                    {
                        return new Integrantes();
                    }
            }
        }

        public Integrantes BuscaPorCodigo(int id)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    return conn.QueryFirst<Integrantes>(@"SELECT ID,
                                                                    CODBENEFICIARIO,
                                                                    CODMINISTERIO,
                                                                    ATIVO
                                                                FROM INTEGRANTES", new { Id = id });


                }
                catch (Exception)
                {

                    return new Integrantes();
                }
            }
        }

        public bool Deleta(Integrantes Integrantes)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    conn.QueryFirst<Integrantes>(@"DELETE FROM Integrantes                                                         
                                                        WHERE ID = @id", Integrantes);
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }

        public List<Integrantes> ListaIntegrantes()
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                var retorno = conn.Query<Integrantes>(@"SELECT ID,
                                                                  CODBENEFICIARIO,
                                                                  CODMINISTERIO,
                                                                  ATIVO
                                                              FROM INTEGRANTES");

                return (List<Integrantes>)retorno;
            }
        }
    }
}