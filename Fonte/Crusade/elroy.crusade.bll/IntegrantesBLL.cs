using Dapper;
using elroy.crusade.dominio;
using elroy.crusade.Infra.Enum;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace elroy.crusade.Infra
{
    public class IntegrantesBLL
    {
        public Integrantes Grava(Integrantes integrantes)
        {
            string acao;
            FuncoesAuxiliaresBLL funcoes = new FuncoesAuxiliaresBLL();

            using (SqlConnection conn = new SqlConnection(Repositorio.Conexao()))
            {
                // se ID não for nulo
                if (!string.IsNullOrEmpty(integrantes.Id))
                    acao = funcoes.DefineAcao(this.GetType().Name, integrantes.Id);
                else
                {
                    integrantes.Id = funcoes.GeraGuid();
                    acao = Acoes.Inserir.ToString();
                }

                if (acao == Acoes.Inserir.ToString())

                {
                    try
                    {
                        conn.Execute(@"INSERT INTO INTEGRANTES
                                               (ID, CODBENEFICIARIO,
                                               CODMINISTERIO,
                                               ATIVO)
                                          OUTPUT INSERTED.id  
                                         VALUES
                                               (@ID, @CODBENEFICIARIO,
                                                @CODMINISTERIO,
                                                @ATIVO)", integrantes);

                        return integrantes;
                    }
                    catch (Exception e)
                    {
                        return new Integrantes();
                        throw new Exception(e.Message);
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
                                                                FROM INTEGRANTES
                                                                  where id = @id", new { id = integrantes.Id });                        
                    }
                    catch (Exception e)
                    {
                        return new Integrantes();
                        throw new Exception(e.Message);
                    }
            }
        }

        public Integrantes Busca(String id)
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
                catch (Exception e)
                {
                    return new Integrantes();
                    throw new Exception(e.Message);
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
                catch (Exception e)
                {
                    return false;
                    throw new Exception(e.Message);                    
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