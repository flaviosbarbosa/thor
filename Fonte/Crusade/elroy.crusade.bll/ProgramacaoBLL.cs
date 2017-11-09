using Dapper;
using elroy.crusade.dominio;
using elroy.crusade.Infra.Enum;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace elroy.crusade.Infra
{
    public class ProgramacaoBLL
    {
        public Programacao Grava(Programacao programacao)
        {
            string acao;
            FuncoesAuxiliaresBLL funcoes = new FuncoesAuxiliaresBLL();

            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                // se ID não for nulo
                if (!string.IsNullOrEmpty(programacao.Id))
                    acao = funcoes.DefineAcao(this.GetType().Name, programacao.Id);
                else
                {
                    programacao.Id = funcoes.GeraGuid();
                    acao = Acoes.Inserir.ToString();
                }

                if (acao == Acoes.Inserir.ToString())

                {
                    try
                    {
                        conn.Execute(@"INSERT INTO PROGRAMACAO
                                           (ID, CODIGREJA,
                                           TITULO,
                                           DESCRICAO)                                    
                                     VALUES
                                           (@ID,
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

        public Programacao Busca(String id)
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
                catch (Exception e)
                {
                    return new Programacao();
                    throw new Exception(e.Message);
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
