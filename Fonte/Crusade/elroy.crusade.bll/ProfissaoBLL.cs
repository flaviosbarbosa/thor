using Dapper;
using elroy.crusade.dominio;
using elroy.crusade.Infra;
using elroy.crusade.Infra.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace elroy.crusade.bll
{
    public class ProfissaoBLL
    {
        public Profissao Grava(Profissao profissao)
        {
            string acao;
            FuncoesAuxiliaresBLL funcoes = new FuncoesAuxiliaresBLL();

            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                // se ID não for nulo
                if (!string.IsNullOrEmpty(profissao.Id))
                    acao = funcoes.DefineAcao(this.GetType().Name, profissao.Id);
                else
                {
                    profissao.Id = funcoes.GeraGuid();
                    acao = Acoes.Inserir.ToString();
                }

                if (acao == Acoes.Inserir.ToString())

                {
                    try
                    {
                        conn.Execute(@"INSERT INTO PROFISSAO (ID, DESCRICAO) VALUES (@ID, @Descricao)", profissao);

                        return profissao;
                    }
                    catch (Exception e)
                    {
                        return new Profissao();
                        throw new Exception(e.Message);
                    }
                }                
                else
                    try
                    {
                        var retorno =
                        conn.Execute(@"UPDATE PROFISSAO
                                          SET DESCRICAO = @DESCRICAO
                                        WHERE id = @id", profissao);

                        return this.Busca(profissao.Id);
                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.Message);
                    }
            }
        }

        public Profissao Busca(int id)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    return conn.QueryFirst<Profissao>(@"SELECT ID,
                                                               DESCRICAO
                                                          FROM PROFISSAO where id = @id", new { id = id});
                }
                catch (Exception)
                {

                    return new Profissao();
                }
            }
        }

        public Profissao Busca(string descricao)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    return conn.QueryFirst<Profissao>(@"SELECT ID,
                                                               DESCRICAO
                                                          FROM PROFISSAO", new { Descricao = descricao });
                }
                catch (Exception e)
                {

                    throw new Exception(e.Message);
                }
            }
        }

        public List<Profissao> Busca()
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                var retorno = conn.Query<Profissao>(@"SELECT ID,
                                                             DESCRICAO
                                                        FROM PROFISSAO");
                return (List<Profissao>)retorno;
            }
        }

        public bool Deleta(Profissao profissao)
        {
            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                try
                {
                    conn.QueryFirst<Profissao>(@"DELETE FROM PROFISSAO
                                                  WHERE ID = @id", profissao);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}