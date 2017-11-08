using Dapper;
using elroy.crusade.dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace elroy.crusade.Infra
{
    public class ProgramacaoBLL
    {
        public Programacao Grava(Programacao programacao)
        {
            // parei ontem criando a conexao com o banco
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {

                if (programacao.Id == "0")
                {
                    try
                    {
                        programacao.Id = (String)conn.ExecuteScalar(@"INSERT INTO PROGRAMACAO
                                           (CODIGREJA,
                                           TITULO,
                                           DESCRICAO)
                                           OUTPUT INSERTED.id 
                                     VALUES
                                           (
                                           @CODIGREJA,
                                           @TITULO,
                                           @DESCRICAO)", programacao);

                        return programacao;
                    }
                    catch (Exception e)
                    {
                        return new Programacao();
                        throw new Exception(e.Message);
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
                                            WHERE id = @id", programacao);

                        return conn.QueryFirst<Programacao>(@"SELECT ID,
                                                                    CODIGREJA,
                                                                    TITULO,
                                                                    DESCRICAO 
                                                                FROM Programacao
                                                             where id = @id", programacao);
                    }
                    catch (Exception)
                    {
                        return new Programacao();
                    }
            }
        }

        public Programacao BuscaPorCodigo(String id)
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
