using Dapper;
using elroy.crusade.dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace elroy.crusade.Infra
{
    public class MinisterioBLL
    {
        public Ministerio Grava(Ministerio Ministerio)
        {
            // parei ontem criando a conexao com o banco
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {

                if (Ministerio.Id == 0)
                {
                    try
                    {
                        conn.Execute(@"INSERT INTO MINISTERIOS
                                           (
                                           CODRESPONSAVEL,
                                           NOME,
                                           DESCRICAO)
                                     VALUES
                                           (
                                           @CODRESPONSAVEL,
                                           @NOME,
                                           @DESCRICAO)", Ministerio);

                        return conn.QueryFirst<Ministerio>(@"SELECT ID,
                                                                      CODRESPONSAVEL,
                                                                      NOME,
                                                                      DESCRICAO
                                                                  FROM MINISTERIOS", Ministerio);
                    }
                    catch (Exception e )
                    {
                        return new Ministerio();
                        throw new Exception(e.Message);
                    }
                }
                else
                    try
                    {
                        var retorno =
                        conn.Execute(@"UPDATE MINISTERIOS
                                       SET CODRESPONSAVEL = @CODRESPONSAVEL,
                                          NOME = @NOME,
                                          DESCRICAO = @DESCRICAO
                                            WHERE id = @id", Ministerio);

                        return conn.QueryFirst<Ministerio>(@"SELECT ID,
                                                                      CODRESPONSAVEL,
                                                                      NOME,
                                                                      DESCRICAO
                                                                  FROM MINISTERIOS", Ministerio);
                    }
                    catch (Exception)
                    {
                        return new Ministerio();
                    }
            }
        }

        public Ministerio BuscaPorCodigo(int id)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    return conn.QueryFirst<Ministerio>(@"SELECT ID,
                                                                  CODRESPONSAVEL,
                                                                  NOME,
                                                                  DESCRICAO
                                                              FROM MINISTERIOS", new { Id = id });
                }
                catch (Exception e)
                {
                    return new Ministerio();
                    throw new Exception(e.Message);
                }
            }
        }

        public bool Deleta(Ministerio Ministerio)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    conn.QueryFirst<Ministerio>(@"DELETE FROM MINISTERIOS                                                         
                                                        WHERE ID = @id", new { Id = Ministerio.Id });
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                    throw new Exception(e.Message);                    
                }
            }
        }

        public List<Ministerio> ListaMinisterio()
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                var retorno = conn.Query<Ministerio>(@"SELECT ID,
                                                              CODRESPONSAVEL,
                                                              NOME,
                                                              DESCRICAO
                                                          FROM MINISTERIOS");
                return (List<Ministerio>)retorno;
            }
        }
    }
}
