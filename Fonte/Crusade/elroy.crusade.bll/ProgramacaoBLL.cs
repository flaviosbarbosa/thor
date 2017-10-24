using Dapper;
using elroy.crusade.dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace elroy.crusade.Infra
{
    public class ProgramacaoBLL
    {
        public Programacao Grava(Programacao Programacao)
        {
            // parei ontem criando a conexao com o banco
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {

                if (Programacao.Id == 0)
                {
                    try
                    {
                        conn.Execute(@"INSERT INTO PROGRAMACAO
                                           (CODIGREJA,
                                           TITULO,
                                           DESCRICAO)
                                     VALUES
                                           (
                                           @CODIGREJA,
                                           @TITULO,
                                           @DESCRICAO)", Programacao);

                        return conn.QueryFirst<Programacao>(@"SELECT ID,
                                                                    CODIGREJA,
                                                                    TITULO,
                                                                    DESCRICAO
                                                               FROM Programacao", Programacao);
                    }
                    catch (Exception )
                    {
                        return new Programacao();
                    }
                }
                else
                    try
                    {
                        var retorno =
                        conn.Execute(@"UPDATE PROGRAMACAO
                                          SET CODIGREJA = @CODIGREJA,
                                              TITULO = @TITULO,
                                              DESCRICAO = @DESCRICAO 
                                            WHERE id = @id", Programacao);

                        return conn.QueryFirst<Programacao>(@"SELECT ID,
                                                                    CODIGREJA,
                                                                    TITULO,
                                                                    DESCRICAO FROM Programacao", Programacao);
                    }
                    catch (Exception)
                    {
                        return new Programacao();
                    }
            }
        }

        public Programacao BuscaPorCodigo(int id)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    return conn.QueryFirst<Programacao>(@"SELECT ID,
                                                                    CODIGREJA,
                                                                    TITULO,
                                                                    DESCRICAO
                                                                FROM Programacao
                                                        WHERE ID = @ID", new { Id = id });
                }
                catch (Exception)
                {

                    return new Programacao();
                }
            }
        }

        public bool Deleta(Programacao Programacao)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    conn.QueryFirst<Programacao>(@"DELETE FROM Programacao                                                         
                                                        WHERE ID = @id", Programacao);
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }

        public List<Programacao> ListaProgramacao()
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                var retorno = conn.Query<Programacao>(@"SELECT ID,
                                                               CODIGREJA,
                                                               TITULO,
                                                               DESCRICAO FROM Programacao");
                return (List<Programacao>)retorno;
            }
        }
    }
}
