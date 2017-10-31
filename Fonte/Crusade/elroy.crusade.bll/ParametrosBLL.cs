using Dapper;
using elroy.crusade.dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace elroy.crusade.Infra
{
    public class ParametroBLL
    {
        public Parametros Grava(Parametros parametros)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {

                if (parametros.id == 0)
                {
                    try
                    {
                        parametros.id = (int)conn.ExecuteScalar(@"INSERT INTO PARAMETROS
                                        (
                                              LOCALIZACAO,
                                              EXIBIRLOCALIZACAO)
                                            OUTPUT INSERTED.id
                                             VALUES
                                        (
                                              @LOCALIZACAO,
                                              @EXIBIRLOCALIZACAO)", parametros);

                        return parametros;
                    }
                    catch (Exception e)
                    {
                        return new Parametros();
                        throw new Exception(e.Message);
                    }
                }
                else
                    try
                    {
                        var retorno =
                        conn.Execute(@"UPDATE ParametroS
                                       SET LOCALIZACAO = @LOCALIZACAO,
                                           EXIBIRLOCALIZACAO = @EXIBIRLOCALIZACAO
                                     WHERE id = @id", parametros);

                        return conn.QueryFirst<Parametros>(@"SELECT ID,
                                                                   LOCALIZACAO,
                                                                   EXIBIRLOCALIZACAO
                                                    FROM PARAMETROS", parametros);
                    }
                    catch (Exception)
                    {
                        return new Parametros();
                    }
            }
        }

        public Parametros BuscaPorCodigo(int id)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    return conn.QueryFirst<Parametros>(@"SELECT ID,
                                                                   LOCALIZACAO,
                                                                   EXIBIRLOCALIZACAO
                                                           FROM PARAMETROS
                                                           WHERE id = @id", new { Id = id });


                }
                catch (Exception)
                {

                    return new Parametros();
                }
            }
        }

        public bool Deleta(Parametros parametros)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    conn.QueryFirst<Parametros>(@"DELETE FROM ParametroS                                                         
                                                        WHERE ID = @id", parametros);
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }

        public List<Parametros> ListaParametro()
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                var retorno = conn.Query<Parametros>(@"SELECT ID,
                                                                   LOCALIZACAO,
                                                                   EXIBIRLOCALIZACAO
                                                    FROM PARAMETROS");

                return (List<Parametros>)retorno;
            }
        }
    }
}